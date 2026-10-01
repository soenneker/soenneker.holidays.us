using System;

namespace Soenneker.Holidays.Us;

/// <summary>A full or partial holiday on a local calendar date. No time zone conversion is performed.</summary>
/// <param name="Id">The holiday identifier.</param>
/// <param name="Name">The holiday name.</param>
/// <param name="Date">The actual or substituted date.</param>
/// <param name="ActualDate">The underlying holiday date, including when it lies in an adjacent year.</param>
/// <param name="StartTime">Inclusive local start, or null for midnight.</param>
/// <param name="EndTime">Exclusive local end, or null for the end of the date.</param>
public sealed record UsHolidayOccurrence(UsHolidayId Id, string Name, DateOnly Date, DateOnly ActualDate,
    TimeOnly? StartTime = null, TimeOnly? EndTime = null)
{
    /// <summary>Whether this occurrence is a substituted date.</summary>
    public bool IsObserved => Date != ActualDate;

    /// <summary>Whether the holiday covers the specified local time on its date.</summary>
    public bool Contains(TimeOnly time) => (!StartTime.HasValue || time >= StartTime.Value) && (!EndTime.HasValue || time < EndTime.Value);
}
