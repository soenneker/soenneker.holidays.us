namespace Soenneker.Holidays.Us;

/// <summary>A caller-selected weekend substitution rule. No rule applies universally to all U.S. holidays.</summary>
public enum HolidayObservance
{
    /// <summary>Return actual dates only.</summary>
    None,
    /// <summary>Add Monday when the actual date is Sunday; leave Saturday unchanged.</summary>
    SundayToMonday,
    /// <summary>Add Friday for Saturday and Monday for Sunday.</summary>
    NearestWeekday,
    /// <summary>Add the following Monday for either Saturday or Sunday.</summary>
    WeekendToMonday
}
