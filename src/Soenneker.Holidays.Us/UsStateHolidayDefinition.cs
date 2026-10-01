using System;
using System.Collections.Generic;

namespace Soenneker.Holidays.Us;

/// <summary>A sourced selection of holiday rules for one state, using current formulas rather than historical enactment dates.</summary>
/// <remarks>This describes the scope of the cited holiday lists, not a telemarketing permission decision.
/// Government office closures and private-sector restrictions are not interchangeable.
/// Proclamations, emergency closures, floating leave, and unlisted local holidays must be supplied separately.</remarks>
public sealed class UsStateHolidayDefinition
{
    /// <summary>The state or District of Columbia.</summary>
    public UsState State { get; }
    /// <summary>The two-letter postal abbreviation.</summary>
    public string Code { get; }
    /// <summary>Sources supporting this state's selection and its scope.</summary>
    public IReadOnlyList<string> SourceUrls { get; }
    /// <summary>The rules selected by default, including weekly or partial holidays where the cited law includes them.</summary>
    public IReadOnlyList<UsHolidayId> Holidays { get; }
    /// <summary>Additional catalog rules limited to localities, employees, optional observance, or proclamations.
    /// These are excluded by default and are not an exhaustive inventory of local holidays.</summary>
    public IReadOnlyList<UsHolidayId> ConditionalHolidays { get; }
    /// <summary>Applicability, source scope, and limitations of this selection.</summary>
    public string Notes { get; }

    internal UsStateHolidayDefinition(UsState state, string code, string[] sourceUrls, UsHolidayId[] holidays,
        UsHolidayId[] conditionalHolidays, string notes)
    {
        State = state;
        Code = code;
        SourceUrls = Array.AsReadOnly(sourceUrls);
        Holidays = Array.AsReadOnly(holidays);
        ConditionalHolidays = Array.AsReadOnly(conditionalHolidays);
        Notes = notes;
    }
}
