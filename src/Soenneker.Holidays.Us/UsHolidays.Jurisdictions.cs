using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Soenneker.Holidays.Us;

public static partial class UsHolidays
{
    private static readonly IReadOnlyList<UsHolidayId> _federalHolidays = Array.AsReadOnly<UsHolidayId>(
    [
        UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
        UsHolidayId.MemorialDay, UsHolidayId.Juneteenth, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
        UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay
    ]);

    /// <summary>The eleven nationwide federal holiday rules; excludes the geographically limited Inauguration Day.</summary>
    public static IReadOnlyList<UsHolidayId> FederalHolidays => _federalHolidays;

    /// <summary>Definitions for all 50 states and D.C., including source references and conditional rules.</summary>
    public static IReadOnlyList<UsStateHolidayDefinition> States => _states;

    /// <summary>Returns the sourced rule selection for a state.</summary>
    /// <exception cref="ArgumentOutOfRangeException">The state is not supported.</exception>
    public static UsStateHolidayDefinition GetStateDefinition(UsState state) =>
        _states.FirstOrDefault(s => s.State == state) ?? throw new ArgumentOutOfRangeException(nameof(state));

    /// <summary>Resolves a two-letter postal abbreviation, ignoring case and surrounding whitespace.</summary>
    /// <exception cref="ArgumentException">The code is not one of the 50 states or D.C.</exception>
    public static UsState GetState(string stateCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(stateCode);
        return _states.FirstOrDefault(s => string.Equals(s.Code, stateCode.Trim(), StringComparison.OrdinalIgnoreCase))?.State
            ?? throw new ArgumentException("Use a two-letter U.S. state or D.C. postal abbreviation.", nameof(stateCode));
    }

    /// <summary>Returns nationwide federal holidays in a calendar year, retaining actual and optionally observed dates.</summary>
    /// <param name="year">Gregorian year, 1583 through 9998. Current rules are projected without historical enactment filtering.</param>
    /// <param name="observance">Defaults to the federal Monday-Friday workweek policy. Use None for actual dates only.</param>
    /// <param name="includeInaugurationDay">Include the quadrennial D.C.-area holiday, which substitutes Sunday only.</param>
    /// <param name="additionalHolidays">Optional authoritative declared holiday occurrences.</param>
    public static UsHolidayCalendar GetAllFederalHolidays(int year,
        HolidayObservance observance = HolidayObservance.NearestWeekday, bool includeInaugurationDay = false,
        IEnumerable<UsHolidayOccurrence>? additionalHolidays = null) =>
        GetCalendar(year, includeInaugurationDay ? _federalHolidays.Append(UsHolidayId.InaugurationDay) : _federalHolidays,
            observance, additionalHolidays);

    /// <summary>Returns the selected state's holiday dates, including holidays shared with the federal calendar.</summary>
    /// <param name="year">Gregorian year, 1583 through 9998. Current formulas are projected without historical enactment filtering.</param>
    /// <param name="state">A state or D.C.</param>
    /// <param name="observance">An explicit caller-selected substitution policy; defaults to actual dates only.
    /// This is not an automatic implementation of each state's sector-specific observance laws.</param>
    /// <param name="includeConditionalHolidays">Include the profile's documented optional, local, employee, and declared rules.</param>
    /// <param name="additionalHolidays">Authoritative dates for declarations, external rules, or additional local holidays.
    /// Supply their observed dates explicitly.</param>
    /// <remarks>Read GetStateDefinition(state).Notes for scope. UnresolvedHolidays exposes required external dates.
    /// Bundled declarations (Georgia's 2026/2027 closure calendars and Oklahoma's additional Christmas dates)
    /// are returned exactly as published, regardless of observance, just like additionalHolidays.
    /// A resolved calendar covers its selected rules, not future proclamations or every municipal holiday.</remarks>
    public static UsHolidayCalendar GetAllStateHolidays(int year, UsState state,
        HolidayObservance observance = HolidayObservance.None, bool includeConditionalHolidays = false,
        IEnumerable<UsHolidayOccurrence>? additionalHolidays = null)
    {
        UsStateHolidayDefinition definition = GetStateDefinition(state);
        IEnumerable<UsHolidayOccurrence> declarations = GetPublishedStateDeclarations(state, year);
        additionalHolidays = additionalHolidays is null ? declarations : declarations.Concat(additionalHolidays);
        IEnumerable<UsHolidayId> ids = includeConditionalHolidays
            ? definition.Holidays.Concat(definition.ConditionalHolidays)
            : definition.Holidays;
        return GetCalendar(year, ids, observance, additionalHolidays);
    }

    /// <summary>Returns a state calendar using a case-insensitive two-letter postal abbreviation.
    /// Observance is caller-selected, not inferred from state law; conditional rules are excluded by default.</summary>
    public static UsHolidayCalendar GetAllStateHolidays(int year, string stateCode,
        HolidayObservance observance = HolidayObservance.None, bool includeConditionalHolidays = false,
        IEnumerable<UsHolidayOccurrence>? additionalHolidays = null) =>
        GetAllStateHolidays(year, GetState(stateCode), observance, includeConditionalHolidays, additionalHolidays);

    /// <summary>Returns separate calendars for all 50 states and D.C. Retains unresolved dates within each calendar.</summary>
    /// <remarks>Defaults to actual dates. The optional observance policy is a caller-selected uniform policy, not state law.
    /// Use the single-state overload to supply declared dates for individual states.</remarks>
    public static IReadOnlyDictionary<UsState, UsHolidayCalendar> GetAllStateHolidays(int year,
        HolidayObservance observance = HolidayObservance.None, bool includeConditionalHolidays = false)
    {
        ValidateYear(year);
        ValidateObservance(observance);
        return new ReadOnlyDictionary<UsState, UsHolidayCalendar>(_states.ToDictionary(s => s.State,
            s => GetAllStateHolidays(year, s.State, observance, includeConditionalHolidays)));
    }

    /// <summary>Returns the union of the entire rule catalog, including local, weekly, optional, and unresolved rules.</summary>
    /// <remarks>This is a broad date catalog, not a calendar applicable to a particular state or activity.</remarks>
    public static UsHolidayCalendar GetAllHolidays(int year, HolidayObservance observance = HolidayObservance.None,
        IEnumerable<UsHolidayOccurrence>? additionalHolidays = null) => GetCalendar(year, observance: observance,
            additionalHolidays: additionalHolidays);

    /// <summary>Checks a local date against nationwide federal holidays, including observed dates by default.</summary>
    public static bool IsFederalHoliday(DateOnly date, HolidayObservance observance = HolidayObservance.NearestWeekday,
        bool includeInaugurationDay = false) => GetAllFederalHolidays(date.Year, observance, includeInaugurationDay).IsHoliday(date);

    /// <summary>Checks whether any selected state holiday covers part of the local date. Unresolved negative results throw.</summary>
    /// <remarks>Uses actual dates by default. For partial-day time checks or externally supplied dates, retain and query a state calendar.</remarks>
    public static bool IsStateHoliday(DateOnly date, UsState state, HolidayObservance observance = HolidayObservance.None,
        bool includeConditionalHolidays = false) => GetAllStateHolidays(date.Year, state, observance, includeConditionalHolidays).IsHoliday(date);

    /// <summary>Checks a state holiday by postal abbreviation. Uses actual dates by default; unresolved negative results throw.</summary>
    public static bool IsStateHoliday(DateOnly date, string stateCode, HolidayObservance observance = HolidayObservance.None,
        bool includeConditionalHolidays = false) => IsStateHoliday(date, GetState(stateCode), observance, includeConditionalHolidays);
}
