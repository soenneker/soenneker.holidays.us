using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Soenneker.Holidays.Us;

/// <summary>Offline calculations for a catalog of U.S. federal, state, local, and optional holiday dates.</summary>
/// <remarks>This is a date-rule catalog, not a telemarketing policy or a historical legal-status database.
/// Select the rules appropriate to your jurisdiction. Observance is explicit because states and institutions
/// use different substitution rules. Proclamations and other externally determined dates must be supplied.</remarks>
/// <example>
/// <code>
/// var goodFriday = UsHolidays.GetDates(UsHolidayId.GoodFriday, 2026)[0];
/// var calendar = UsHolidays.GetCalendar(2026,
///     [UsHolidayId.GoodFriday, UsHolidayId.FlagDay, UsHolidayId.ElectionDay]);
/// bool matches = calendar.IsHoliday(new DateOnly(2026, 4, 3));
/// </code>
/// </example>
public static partial class UsHolidays
{
    private static readonly IReadOnlyDictionary<UsHolidayId, UsHolidayDefinition> _byId;

    static UsHolidays() => _byId = _definitions.ToDictionary(d => d.Id);

    /// <summary>The immutable catalog, including rules that require external dates.</summary>
    public static IReadOnlyList<UsHolidayDefinition> Definitions => _definitions;

    /// <summary>Returns metadata for a holiday rule.</summary>
    /// <exception cref="ArgumentOutOfRangeException">The identifier is not in the catalog.</exception>
    public static UsHolidayDefinition GetDefinition(UsHolidayId holiday) => _byId.TryGetValue(holiday, out UsHolidayDefinition? definition)
        ? definition
        : throw new ArgumentOutOfRangeException(nameof(holiday));

    /// <summary>Calculates actual dates for one rule. An empty result means a periodic rule does not occur that year.</summary>
    /// <remarks>Uses the current date formula irrespective of the year in which the holiday was legally established.
    /// Rosh Hashanah returns two dates; weekly holidays return every matching weekday.</remarks>
    /// <exception cref="ArgumentOutOfRangeException">The identifier or year is unsupported.</exception>
    /// <exception cref="InvalidOperationException">The rule requires externally supplied dates.</exception>
    public static IReadOnlyList<DateOnly> GetDates(UsHolidayId holiday, int year)
    {
        ValidateYear(year);
        UsHolidayDefinition definition = GetDefinition(holiday);
        if (definition.RequiresExternalDates)
            throw new InvalidOperationException($"{definition.Name} requires externally supplied dates.");
        if (year < definition.MinimumYear || year > definition.MaximumYear)
            throw new ArgumentOutOfRangeException(nameof(year), $"{definition.Name} supports {definition.MinimumYear} through {definition.MaximumYear}.");
        return Array.AsReadOnly(definition.Calculate!(year).ToArray());
    }

    /// <summary>Calculates occurrences falling in the requested calendar year, with optional substituted dates.</summary>
    /// <param name="year">Gregorian year, 1583 through 9998.</param>
    /// <param name="holidays">Selected rules, or null for the entire catalog. A full catalog includes weekly and unresolved rules.</param>
    /// <param name="observance">A substitution policy chosen by the caller; actual dates are always retained.</param>
    /// <param name="additionalHolidays">Authoritative occurrences to add, including dates for externally determined rules.
    /// Supply substituted dates explicitly for these occurrences. A supplied occurrence resolves that external rule for the year.</param>
    /// <remarks>Different holidays on the same date are retained. Adjacent-year holidays whose substituted dates fall
    /// in this year are included. No substitutions are made for weekly or partial-day rules. Inauguration Day
    /// substitutes Sunday only. Check UnresolvedHolidays before treating the generated calendar as resolved.</remarks>
    public static UsHolidayCalendar GetCalendar(int year, IEnumerable<UsHolidayId>? holidays = null,
        HolidayObservance observance = HolidayObservance.None, IEnumerable<UsHolidayOccurrence>? additionalHolidays = null)
    {
        ValidateYear(year);
        ValidateObservance(observance);
        UsHolidayDefinition[] selected = (holidays ?? _definitions.Select(d => d.Id)).Distinct().Select(GetDefinition).ToArray();
        var occurrences = new List<UsHolidayOccurrence>();
        var unresolved = new List<UsHolidayDefinition>();
        var supplied = new HashSet<UsHolidayId>();

        if (additionalHolidays is not null)
        {
            foreach (UsHolidayOccurrence occurrence in additionalHolidays)
            {
                ArgumentNullException.ThrowIfNull(occurrence);
                GetDefinition(occurrence.Id);
                ArgumentException.ThrowIfNullOrWhiteSpace(occurrence.Name);
                if (occurrence.StartTime.HasValue && occurrence.EndTime.HasValue && occurrence.StartTime >= occurrence.EndTime)
                    throw new ArgumentException("Partial-day intervals must have an end after their start.", nameof(additionalHolidays));
                if (occurrence.Date.Year != year)
                    continue;
                occurrences.Add(occurrence);
                supplied.Add(occurrence.Id);
            }
        }

        foreach (UsHolidayDefinition definition in selected)
        {
            if (definition.RequiresExternalDates || year < definition.MinimumYear || year > definition.MaximumYear)
            {
                if (!supplied.Contains(definition.Id))
                    unresolved.Add(definition);
                continue;
            }

            // Include December 31 observances of the next year's January 1, and vice versa.
            int firstYear = observance == HolidayObservance.None ? year : Math.Max(definition.MinimumYear, year - 1);
            int lastYear = observance == HolidayObservance.None ? year : Math.Min(definition.MaximumYear, year + 1);
            foreach (int actualYear in Enumerable.Range(firstYear, lastYear - firstYear + 1))
            {
                foreach (DateOnly actual in definition.Calculate!(actualYear))
                {
                    if (actual.Year == year)
                        occurrences.Add(new(definition.Id, definition.Name, actual, actual, definition.StartTime, definition.EndTime));

                    HolidayObservance effectiveObservance = definition.Id switch
                    {
                        UsHolidayId.Sunday or UsHolidayId.SaturdayHoliday or UsHolidayId.SaturdayHalfHoliday or
                            UsHolidayId.WednesdayHalfHoliday => HolidayObservance.None,
                        UsHolidayId.InaugurationDay when observance != HolidayObservance.None => HolidayObservance.SundayToMonday,
                        _ when definition.StartTime.HasValue || definition.EndTime.HasValue => HolidayObservance.None,
                        _ => observance
                    };
                    DateOnly observed = GetObservedDate(actual, effectiveObservance);
                    if (observed != actual && observed.Year == year)
                        occurrences.Add(new(definition.Id, definition.Name, observed, actual));
                }
            }
        }

        return new UsHolidayCalendar(year, occurrences, unresolved);
    }

    /// <summary>Checks selected holiday rules against a local date. Unresolved rules prevent a negative answer.</summary>
    /// <remarks>Reuse GetCalendar for repeated checks in the same year.</remarks>
    public static bool IsHoliday(DateOnly date, IEnumerable<UsHolidayId> holidays, HolidayObservance observance = HolidayObservance.None)
    {
        ArgumentNullException.ThrowIfNull(holidays);
        return GetCalendar(date.Year, holidays, observance).IsHoliday(date);
    }

    /// <summary>Calculates Western Easter using the Meeus/Jones/Butcher Gregorian computus.</summary>
    /// <remarks>This is ecclesiastical Gregorian Easter, not Orthodox Easter or an astronomical full-moon calculation.</remarks>
    /// <exception cref="ArgumentOutOfRangeException">The year is outside 1583 through 9998.</exception>
    public static DateOnly GetEasterDate(int year)
    {
        ValidateYear(year);
        int a = year % 19;
        int b = year / 100;
        int c = year % 100;
        int d = b / 4;
        int e = b % 4;
        int f = (b + 8) / 25;
        int g = (b - f + 1) / 3;
        int h = (19 * a + b - d - g + 15) % 30;
        int i = c / 4;
        int k = c % 4;
        int l = (32 + 2 * e + 2 * i - h - k) % 7;
        int m = (a + 11 * h + 22 * l) / 451;
        int value = h + l - 7 * m + 114;
        return new DateOnly(year, value / 31, value % 31 + 1);
    }

    /// <summary>Applies an explicit weekend substitution rule to one date.</summary>
    /// <exception cref="ArgumentOutOfRangeException">The policy is invalid or the result exceeds DateOnly's range.</exception>
    public static DateOnly GetObservedDate(DateOnly date, HolidayObservance observance)
    {
        ValidateObservance(observance);
        int offset = (observance, date.DayOfWeek) switch
        {
            (HolidayObservance.SundayToMonday or HolidayObservance.NearestWeekday or HolidayObservance.WeekendToMonday, DayOfWeek.Sunday) => 1,
            (HolidayObservance.NearestWeekday, DayOfWeek.Saturday) => -1,
            (HolidayObservance.WeekendToMonday, DayOfWeek.Saturday) => 2,
            _ => 0
        };
        return date.AddDays(offset);
    }

    private static void ValidateYear(int year)
    {
        if (year is < 1583 or > 9998)
            throw new ArgumentOutOfRangeException(nameof(year), "Supported Gregorian years are 1583 through 9998.");
    }

    private static void ValidateObservance(HolidayObservance observance)
    {
        if (!Enum.IsDefined(observance))
            throw new ArgumentOutOfRangeException(nameof(observance));
    }

    private static IReadOnlyList<DateOnly> Fixed(int year, int month, int day) => [new(year, month, day)];

    private static IReadOnlyList<DateOnly> Nth(int year, int month, DayOfWeek weekday, int ordinal)
    {
        var first = new DateOnly(year, month, 1);
        return [first.AddDays(((int)weekday - (int)first.DayOfWeek + 7) % 7 + (ordinal - 1) * 7)];
    }

    private static IReadOnlyList<DateOnly> Last(int year, int month, DayOfWeek weekday)
    {
        var last = new DateOnly(year, month, DateTime.DaysInMonth(year, month));
        return [last.AddDays(-((int)last.DayOfWeek - (int)weekday + 7) % 7)];
    }

    private static IReadOnlyList<DateOnly> Offset(IReadOnlyList<DateOnly> dates, int days) => [dates[0].AddDays(days)];
    private static IReadOnlyList<DateOnly> Easter(int year, int offset) => [GetEasterDate(year).AddDays(offset)];

    private static IReadOnlyList<DateOnly> Weekly(int year, DayOfWeek weekday)
    {
        DateOnly date = Nth(year, 1, weekday, 1)[0];
        var result = new List<DateOnly>(53);
        while (date.Year == year)
        {
            result.Add(date);
            date = date.AddDays(7);
        }
        return result;
    }

    private static IReadOnlyList<DateOnly> Hebrew(int year, int month, int day, int length)
    {
        var calendar = new HebrewCalendar();
        int hebrewYear = calendar.GetYear(new DateTime(year, 7, 1)) + 1;
        DateOnly first = DateOnly.FromDateTime(calendar.ToDateTime(hebrewYear, month, day, 0, 0, 0, 0));
        var result = new DateOnly[length];
        for (int index = 0; index < length; index++)
            result[index] = first.AddDays(index);
        return result;
    }

    private static IReadOnlyList<DateOnly> LunarNewYear(int year)
    {
        var calendar = new ChineseLunisolarCalendar();
        return [DateOnly.FromDateTime(calendar.ToDateTime(year, 1, 1, 0, 0, 0, 0))];
    }

    private static IReadOnlyList<DateOnly> UtahJuneteenth(int year)
    {
        var date = new DateOnly(year, 6, 19);
        int offset = date.DayOfWeek switch
        {
            DayOfWeek.Saturday => 2,
            DayOfWeek.Sunday => 1,
            _ => (int)DayOfWeek.Monday - (int)date.DayOfWeek
        };
        return [date.AddDays(offset)];
    }
}
