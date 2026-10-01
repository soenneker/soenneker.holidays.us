using System;
using System.Collections.Generic;
using System.Linq;

namespace Soenneker.Holidays.Us.Tests;

public sealed class UsHolidaysTests
{
    // Published 2026 OPM, Hawaii, Alabama, Maryland, and Texas calendars provide independent fixtures.
    [Test]
    [Arguments(UsHolidayId.NewYearsDay, 1, 1)]
    [Arguments(UsHolidayId.MartinLutherKingJrDay, 1, 19)]
    [Arguments(UsHolidayId.WashingtonsBirthday, 2, 16)]
    [Arguments(UsHolidayId.MemorialDay, 5, 25)]
    [Arguments(UsHolidayId.Juneteenth, 6, 19)]
    [Arguments(UsHolidayId.IndependenceDay, 7, 4)]
    [Arguments(UsHolidayId.LaborDay, 9, 7)]
    [Arguments(UsHolidayId.ColumbusDay, 10, 12)]
    [Arguments(UsHolidayId.VeteransDay, 11, 11)]
    [Arguments(UsHolidayId.ThanksgivingDay, 11, 26)]
    [Arguments(UsHolidayId.ChristmasDay, 12, 25)]
    [Arguments(UsHolidayId.MardiGras, 2, 17)]
    [Arguments(UsHolidayId.GoodFriday, 4, 3)]
    [Arguments(UsHolidayId.PrinceKuhioDay, 3, 26)]
    [Arguments(UsHolidayId.KingKamehamehaDay, 6, 11)]
    [Arguments(UsHolidayId.HawaiiStatehoodDay, 8, 21)]
    [Arguments(UsHolidayId.TexasIndependenceDay, 3, 2)]
    [Arguments(UsHolidayId.SanJacintoDay, 4, 21)]
    [Arguments(UsHolidayId.LyndonBainesJohnsonDay, 8, 27)]
    [Arguments(UsHolidayId.ConfederateMemorialDayFourthMonday, 4, 27)]
    [Arguments(UsHolidayId.JeffersonDavisBirthdayFirstMonday, 6, 1)]
    [Arguments(UsHolidayId.DefendersDay, 9, 12)]
    [Arguments(UsHolidayId.MarylandDay, 3, 25)]
    [Arguments(UsHolidayId.AmericanIndianHeritageDay, 11, 27)]
    [Arguments(UsHolidayId.FlagDay, 6, 14)]
    [Arguments(UsHolidayId.ElectionDay, 11, 3)]
    public void Published2026Dates(UsHolidayId holiday, int month, int day)
    {
        Equal(new DateOnly(2026, month, day), UsHolidays.GetDates(holiday, 2026).Single());
    }

    [Test]
    [Arguments(1818, 3, 22)] // Earliest possible Easter.
    [Arguments(1943, 4, 25)] // Latest possible Easter.
    [Arguments(1954, 4, 18)] // Gregorian correction case.
    [Arguments(1981, 4, 19)] // Gregorian correction case.
    [Arguments(2000, 4, 23)]
    [Arguments(2024, 3, 31)]
    [Arguments(2025, 4, 20)]
    [Arguments(2026, 4, 5)]
    [Arguments(2038, 4, 25)]
    [Arguments(2100, 3, 28)]
    public void EasterKnownDates(int year, int month, int day)
    {
        Equal(new DateOnly(year, month, day), UsHolidays.GetEasterDate(year));
    }

    [Test]
    public void PennsylvaniaMissingDatesAreCalculatedInOddAndEvenYears()
    {
        UsHolidayId[] selected = [UsHolidayId.GoodFriday, UsHolidayId.FlagDay, UsHolidayId.ElectionDay];
        UsHolidayCalendar calendar = UsHolidays.GetCalendar(2025, selected);
        Check(calendar.IsHoliday(new(2025, 4, 18)));
        Check(calendar.IsHoliday(new(2025, 6, 14)));
        Check(calendar.IsHoliday(new(2025, 11, 4)));
        Check(!calendar.IsHoliday(new(2025, 11, 5)));
        Equal(0, UsHolidays.GetDates(UsHolidayId.GeneralElectionDay, 2025).Count);
        Equal(new DateOnly(2026, 11, 3), UsHolidays.GetDates(UsHolidayId.GeneralElectionDay, 2026).Single());
    }

    [Test]
    public void ElectionDayIsNotAlwaysTheFirstTuesday()
    {
        Equal(new DateOnly(2022, 11, 8), UsHolidays.GetDates(UsHolidayId.ElectionDay, 2022).Single());
    }

    [Test]
    public void FourthAndLastMondayAreDifferentRules()
    {
        Equal(new DateOnly(2024, 4, 22), UsHolidays.GetDates(UsHolidayId.ConfederateMemorialDayFourthMonday, 2024).Single());
        Equal(new DateOnly(2024, 4, 29), UsHolidays.GetDates(UsHolidayId.ConfederateMemorialDayLastMonday, 2024).Single());
    }

    [Test]
    public void DayAfterThanksgivingCanBeTheFifthFriday()
    {
        Equal(new DateOnly(2024, 11, 29), UsHolidays.GetDates(UsHolidayId.AmericanIndianHeritageDay, 2024).Single());
    }

    [Test]
    public void JuneteenthVariantsRemainDistinct()
    {
        Equal(new DateOnly(2025, 6, 19), UsHolidays.GetDates(UsHolidayId.Juneteenth, 2025).Single());
        Equal(new DateOnly(2025, 6, 20), UsHolidays.GetDates(UsHolidayId.JuneteenthThirdFriday, 2025).Single());
    }

    [Test]
    [Arguments(2021, 21)]
    [Arguments(2022, 20)]
    [Arguments(2023, 19)]
    [Arguments(2024, 17)]
    [Arguments(2025, 16)]
    [Arguments(2026, 15)]
    [Arguments(2029, 18)]
    public void UtahJuneteenthHandlesEveryWeekday(int year, int day)
    {
        Equal(new DateOnly(year, 6, day), UsHolidays.GetDates(UsHolidayId.UtahJuneteenth, year).Single());
    }

    [Test]
    public void ObservedNewYearIsIncludedInPreviousCalendarYear()
    {
        UsHolidayCalendar calendar = UsHolidays.GetCalendar(2021, [UsHolidayId.NewYearsDay], HolidayObservance.NearestWeekday);
        UsHolidayOccurrence observed = calendar.Occurrences.Single(h => h.Date == new DateOnly(2021, 12, 31));
        Equal(new DateOnly(2022, 1, 1), observed.ActualDate);
        Check(observed.IsObserved);
        Check(calendar.Occurrences.All(h => h.Date.Year == 2021));
        Check(UsHolidays.IsHoliday(new(2021, 12, 31), [UsHolidayId.NewYearsDay], HolidayObservance.NearestWeekday));
    }

    [Test]
    public void ObservedNewYearsEveCanFallInFollowingYear()
    {
        UsHolidayCalendar calendar = UsHolidays.GetCalendar(2024, [UsHolidayId.NewYearsEve], HolidayObservance.SundayToMonday);
        Equal(new DateOnly(2023, 12, 31), calendar.Occurrences.Single(h => h.Date == new DateOnly(2024, 1, 1)).ActualDate);
    }

    [Test]
    public void ActualAndObservedDatesAreBothKept()
    {
        UsHolidayCalendar calendar = UsHolidays.GetCalendar(2026, [UsHolidayId.IndependenceDay], HolidayObservance.NearestWeekday);
        Check(calendar.IsHoliday(new(2026, 7, 3)));
        Check(calendar.IsHoliday(new(2026, 7, 4)));
        Equal(2, calendar.Occurrences.Count);
        Equal(1, UsHolidays.GetCalendar(2026, [UsHolidayId.IndependenceDay]).Occurrences.Count);
    }

    [Test]
    public void WeekendPoliciesAreExplicit()
    {
        var saturday = new DateOnly(2026, 7, 4);
        Equal(saturday, UsHolidays.GetObservedDate(saturday, HolidayObservance.None));
        Equal(saturday, UsHolidays.GetObservedDate(saturday, HolidayObservance.SundayToMonday));
        Equal(new DateOnly(2026, 7, 3), UsHolidays.GetObservedDate(saturday, HolidayObservance.NearestWeekday));
        Equal(new DateOnly(2026, 7, 6), UsHolidays.GetObservedDate(saturday, HolidayObservance.WeekendToMonday));
        Equal(new DateOnly(2027, 7, 5), UsHolidays.GetObservedDate(new(2027, 7, 4), HolidayObservance.SundayToMonday));
    }

    [Test]
    public void InaugurationIsPeriodicAndNeverMovesSaturdayToFriday()
    {
        Equal(0, UsHolidays.GetDates(UsHolidayId.InaugurationDay, 2026).Count);
        Equal(new DateOnly(2025, 1, 20), UsHolidays.GetDates(UsHolidayId.InaugurationDay, 2025).Single());
        Equal(1, UsHolidays.GetCalendar(2029, [UsHolidayId.InaugurationDay], HolidayObservance.NearestWeekday).Occurrences.Count);
        Check(UsHolidays.GetCalendar(2013, [UsHolidayId.InaugurationDay], HolidayObservance.NearestWeekday).IsHoliday(new(2013, 1, 21)));
    }

    [Test]
    public void CoincidentHolidaysAreRetainedAndDuplicateSelectionsAreRemoved()
    {
        UsHolidayCalendar calendar = UsHolidays.GetCalendar(2026,
            [UsHolidayId.MartinLutherKingJrDay, UsHolidayId.ConfederateHeroesDay, UsHolidayId.MartinLutherKingJrDay]);
        Equal(2, calendar.Occurrences.Count);
        Check(calendar.Occurrences.All(h => h.Date == new DateOnly(2026, 1, 19)));
    }

    [Test]
    public void HebrewHolidaysMatchTexasPublished2025Calendar()
    {
        Check(UsHolidays.GetDates(UsHolidayId.RoshHashanah, 2025).SequenceEqual([new DateOnly(2025, 9, 23), new DateOnly(2025, 9, 24)]));
        Equal(new DateOnly(2025, 10, 2), UsHolidays.GetDates(UsHolidayId.YomKippur, 2025).Single());
    }

    [Test]
    [Arguments(2024, 2, 10)]
    [Arguments(2025, 1, 29)]
    [Arguments(2026, 2, 17)]
    [Arguments(2033, 1, 31)] // Chinese intercalary-month edge case.
    public void LunarNewYearDates(int year, int month, int day)
    {
        Equal(new DateOnly(year, month, day), UsHolidays.GetDates(UsHolidayId.LunarNewYear, year).Single());
    }

    [Test]
    public void PartialHolidaysRespectExclusiveEndAndDoNotShift()
    {
        UsHolidayCalendar saturdays = UsHolidays.GetCalendar(2026, [UsHolidayId.SaturdayHalfHoliday], HolidayObservance.NearestWeekday);
        Check(saturdays.IsHoliday(new(2026, 1, 3)));
        Check(!saturdays.IsHoliday(new(2026, 1, 3), new(11, 59)));
        Check(saturdays.IsHoliday(new(2026, 1, 3), new(12, 0)));
        Check(saturdays.IsHoliday(new(2026, 1, 3), new(23, 59)));
        Check(!saturdays.IsHoliday(new(2026, 1, 2)));
        UsHolidayCalendar goodFriday = UsHolidays.GetCalendar(2026, [UsHolidayId.CaliforniaGoodFridayPartial]);
        Check(goodFriday.IsHoliday(new(2026, 4, 3), new(14, 59)));
        Check(!goodFriday.IsHoliday(new(2026, 4, 3), new(15, 0)));
    }

    [Test]
    public void WeeklyDatesHandleLeapYearsAndNeverLeaveTheYear()
    {
        IReadOnlyList<DateOnly> sundays = UsHolidays.GetDates(UsHolidayId.Sunday, 2012);
        Equal(53, sundays.Count);
        Check(sundays.All(d => d.Year == 2012 && d.DayOfWeek == DayOfWeek.Sunday));
        Equal(new DateOnly(2012, 1, 1), sundays[0]);
        Equal(new DateOnly(2012, 12, 30), sundays[^1]);
    }

    [Test]
    public void ExternalDatesNeverProduceASilentNegative()
    {
        Throws<InvalidOperationException>(() => UsHolidays.GetDates(UsHolidayId.Diwali, 2026));
        UsHolidayCalendar unresolved = UsHolidays.GetCalendar(2026, [UsHolidayId.Diwali]);
        Equal(UsHolidayId.Diwali, unresolved.UnresolvedHolidays.Single().Id);
        Throws<InvalidOperationException>(() => unresolved.IsHoliday(new(2026, 11, 8)));

        // A caller-supplied fixture exercises ingestion; it does not establish legal applicability.
        var supplied = new UsHolidayOccurrence(UsHolidayId.Diwali, "Diwali", new(2026, 11, 8), new(2026, 11, 8));
        UsHolidayCalendar resolved = UsHolidays.GetCalendar(2026, [UsHolidayId.Diwali], additionalHolidays: [supplied]);
        Equal(0, resolved.UnresolvedHolidays.Count);
        Check(resolved.IsHoliday(new(2026, 11, 8)));
        Check(!resolved.IsHoliday(new(2026, 11, 9)));
    }

    [Test]
    public void MissingDatesCannotHideAKnownPositive()
    {
        UsHolidayCalendar calendar = UsHolidays.GetCalendar(2026, [UsHolidayId.NewYearsDay, UsHolidayId.ProclaimedHoliday]);
        Check(calendar.IsHoliday(new(2026, 1, 1)));
        Throws<InvalidOperationException>(() => calendar.IsHoliday(new(2026, 1, 2)));
    }

    [Test]
    public void CalendarLimitationsAreReported()
    {
        UsHolidayCalendar calendar = UsHolidays.GetCalendar(2500, [UsHolidayId.YomKippur, UsHolidayId.LunarNewYear, UsHolidayId.ChristmasDay]);
        Equal(2, calendar.UnresolvedHolidays.Count);
        Check(calendar.IsHoliday(new(2500, 12, 25)));
        Throws<ArgumentOutOfRangeException>(() => UsHolidays.GetDates(UsHolidayId.LunarNewYear, 2500));
    }

    [Test]
    public void EveryRuleCalculatesAtItsDeclaredBoundaries()
    {
        foreach (UsHolidayDefinition definition in UsHolidays.Definitions.Where(d => !d.RequiresExternalDates))
        {
            foreach (int year in new[] { definition.MinimumYear, definition.MaximumYear })
                Check(UsHolidays.GetDates(definition.Id, year).All(d => d.Year == year), $"{definition.Id}: {year}");
        }
    }

    [Test]
    public void CatalogRulesStayInYearAndEasterRangeAcrossACentury()
    {
        for (int year = 2000; year < 2100; year++)
        {
            DateOnly easter = UsHolidays.GetEasterDate(year);
            Equal(DayOfWeek.Sunday, easter.DayOfWeek);
            Check(easter >= new DateOnly(year, 3, 22) && easter <= new DateOnly(year, 4, 25));
            foreach (UsHolidayDefinition definition in UsHolidays.Definitions.Where(d => !d.RequiresExternalDates))
                Check(UsHolidays.GetDates(definition.Id, year).All(d => d.Year == year), $"{definition.Id}: {year}");
        }
    }

    [Test]
    public void InvalidInputsAndWrongCalendarYearFailClearly()
    {
        Throws<ArgumentOutOfRangeException>(() => UsHolidays.GetCalendar(1582));
        Throws<ArgumentOutOfRangeException>(() => UsHolidays.GetCalendar(9999));
        Throws<ArgumentOutOfRangeException>(() => UsHolidays.GetDefinition((UsHolidayId)0));
        Throws<ArgumentOutOfRangeException>(() => UsHolidays.GetCalendar(2026, [(UsHolidayId)123456]));
        Throws<ArgumentOutOfRangeException>(() => UsHolidays.GetObservedDate(new(2026, 1, 1), (HolidayObservance)100));
        Throws<ArgumentNullException>(() => UsHolidays.IsHoliday(new(2026, 1, 1), null!));
        Throws<ArgumentOutOfRangeException>(() => UsHolidays.GetCalendar(2026, []).IsHoliday(new(2027, 1, 1)));
        var invalid = new UsHolidayOccurrence(UsHolidayId.ProclaimedHoliday, "Invalid interval", new(2026, 1, 1), new(2026, 1, 1), new(15, 0), new(12, 0));
        Throws<ArgumentException>(() => UsHolidays.GetCalendar(2026, additionalHolidays: [invalid]));
    }

    [Test]
    public void CatalogMetadataAndResultsAreImmutable()
    {
        Equal(Enum.GetValues<UsHolidayId>().Length, UsHolidays.Definitions.Count);
        Equal(UsHolidays.Definitions.Count, UsHolidays.Definitions.Select(d => d.Id).Distinct().Count());
        Check(UsHolidays.Definitions.All(d => Uri.IsWellFormedUriString(d.SourceUrl, UriKind.Absolute)));
        var dates = (IList<DateOnly>)UsHolidays.GetDates(UsHolidayId.NewYearsDay, 2026);
        Throws<NotSupportedException>(() => dates[0] = new(2026, 1, 2));
        var occurrences = (IList<UsHolidayOccurrence>)UsHolidays.GetCalendar(2026, [UsHolidayId.NewYearsDay]).Occurrences;
        Throws<NotSupportedException>(() => occurrences.Clear());
    }

    private static void Equal<T>(T expected, T actual)
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
            throw new Exception($"Expected {expected}, got {actual}.");
    }

    private static void Check(bool condition, string message = "Assertion failed.")
    {
        if (!condition)
            throw new Exception(message);
    }

    private static void Throws<T>(Action action) where T : Exception
    {
        try { action(); }
        catch (T) { return; }
        throw new Exception($"Expected {typeof(T).Name}.");
    }
}
