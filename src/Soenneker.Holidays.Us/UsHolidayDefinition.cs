using System;
using System.Collections.Generic;

namespace Soenneker.Holidays.Us;

/// <summary>A holiday date rule, with an official reference and examples of where the holiday is recognized.</summary>
/// <remarks>Jurisdictions are examples, not an exhaustive applicability matrix. Rules project their current
/// calendar formula into the requested year; they do not assert historical or future legal status.</remarks>
public sealed class UsHolidayDefinition
{
    /// <summary>The stable holiday identifier.</summary>
    public UsHolidayId Id { get; }
    /// <summary>The display name.</summary>
    public string Name { get; }
    /// <summary>A human-readable explanation of the date rule and its scope.</summary>
    public string Rule { get; }
    /// <summary>An official source documenting the holiday or its date.</summary>
    public string SourceUrl { get; }
    /// <summary>Example jurisdictions; this is not a list of places where outreach is prohibited.</summary>
    public string ExampleJurisdictions { get; }
    /// <summary>Whether dates must be supplied by the caller from an announcement or authoritative calendar.</summary>
    public bool RequiresExternalDates => Calculate is null;
    /// <summary>The earliest year supported by the calculation.</summary>
    public int MinimumYear { get; }
    /// <summary>The latest year supported by the calculation.</summary>
    public int MaximumYear { get; }
    /// <summary>The start of a partial-day holiday, or null for a full day.</summary>
    public TimeOnly? StartTime { get; }
    /// <summary>The exclusive end of a partial day, or null for the end of the calendar day.</summary>
    public TimeOnly? EndTime { get; }

    internal Func<int, IReadOnlyList<DateOnly>>? Calculate { get; }

    internal UsHolidayDefinition(UsHolidayId id, string name, string rule, string sourceUrl, string jurisdictions,
        Func<int, IReadOnlyList<DateOnly>>? calculate, int minimumYear = 1583, int maximumYear = 9998,
        TimeOnly? startTime = null, TimeOnly? endTime = null)
    {
        Id = id;
        Name = name;
        Rule = rule;
        SourceUrl = sourceUrl;
        ExampleJurisdictions = jurisdictions;
        Calculate = calculate;
        MinimumYear = minimumYear;
        MaximumYear = maximumYear;
        StartTime = startTime;
        EndTime = endTime;
    }
}
