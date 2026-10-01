using System;
using System.Collections.Generic;
using System.Linq;

namespace Soenneker.Holidays.Us;

/// <summary>A calculated calendar and any selected rules whose dates could not be calculated.</summary>
/// <remarks>An empty unresolved list means the selected catalog rules were resolved, not that every possible
/// proclamation, local holiday, or legal restriction has been discovered.</remarks>
public sealed class UsHolidayCalendar
{
    /// <summary>The calendar year.</summary>
    public int Year { get; }
    /// <summary>Chronologically ordered occurrences, retaining different holidays on the same day.</summary>
    public IReadOnlyList<UsHolidayOccurrence> Occurrences { get; }
    /// <summary>Rules needing externally supplied dates or outside their supported calculation range.</summary>
    public IReadOnlyList<UsHolidayDefinition> UnresolvedHolidays { get; }

    internal UsHolidayCalendar(int year, List<UsHolidayOccurrence> occurrences, List<UsHolidayDefinition> unresolved)
    {
        Year = year;
        Occurrences = Array.AsReadOnly(occurrences.Distinct().OrderBy(h => h.Date).ThenBy(h => h.Id).ToArray());
        UnresolvedHolidays = unresolved.AsReadOnly();
    }

    /// <summary>Checks whether any selected holiday covers part of a local date.</summary>
    /// <exception cref="InvalidOperationException">No matching occurrence exists but selected dates are unresolved.</exception>
    /// <exception cref="ArgumentOutOfRangeException">The date is outside this calendar's year.</exception>
    public bool IsHoliday(DateOnly date)
    {
        ValidateYear(date);
        if (Occurrences.Any(h => h.Date == date))
            return true;
        EnsureResolved();
        return false;
    }

    /// <summary>Checks a local date and time, respecting partial-day boundaries.</summary>
    /// <exception cref="InvalidOperationException">No matching occurrence exists but selected dates are unresolved.</exception>
    /// <exception cref="ArgumentOutOfRangeException">The date is outside this calendar's year.</exception>
    public bool IsHoliday(DateOnly date, TimeOnly time)
    {
        ValidateYear(date);
        if (Occurrences.Any(h => h.Date == date && h.Contains(time)))
            return true;
        EnsureResolved();
        return false;
    }

    private void ValidateYear(DateOnly date)
    {
        if (date.Year != Year)
            throw new ArgumentOutOfRangeException(nameof(date), "The date must be in the calendar's year.");
    }

    private void EnsureResolved()
    {
        if (UnresolvedHolidays.Count != 0)
            throw new InvalidOperationException("Selected holiday dates are unresolved. Supply their dates before treating an unmatched date as a non-holiday.");
    }
}
