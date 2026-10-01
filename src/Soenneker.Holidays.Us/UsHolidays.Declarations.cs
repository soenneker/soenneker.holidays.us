using System;
using System.Collections.Generic;

namespace Soenneker.Holidays.Us;

public static partial class UsHolidays
{
    // Only published declarations: never extend these snapshots into an unpublished year.
    // Sources are retained on the Georgia and Oklahoma state definitions.
    private static IEnumerable<UsHolidayOccurrence> GetPublishedStateDeclarations(UsState state, int year)
    {
        if (state == UsState.Oklahoma && year is 2026 or 2027)
        {
            var date = new DateOnly(year, 12, year == 2026 ? 24 : 23);
            return [new(UsHolidayId.OklahomaAdditionalChristmasHoliday, "Additional Christmas holiday", date, date)];
        }

        if (state != UsState.Georgia || year is not (2026 or 2027))
            return [];

        // Georgia's declared closure dates, including Washington's Birthday moved to December.
        // Declarations are supplied as published and are not re-shifted by a uniform observance policy.
        return year == 2026
            ? [
                Declared(UsHolidayId.NewYearsDay, "New Year's Day", 2026, 1, 1),
                Declared(UsHolidayId.MartinLutherKingJrDay, "Martin Luther King Jr.'s Birthday", 2026, 1, 19),
                Declared(UsHolidayId.ProclaimedHoliday, "State holiday", 2026, 4, 3),
                Declared(UsHolidayId.MemorialDay, "Memorial Day", 2026, 5, 25),
                Declared(UsHolidayId.Juneteenth, "Juneteenth", 2026, 6, 19),
                Declared(UsHolidayId.IndependenceDay, "Independence Day", 2026, 7, 3, new(2026, 7, 4)),
                Declared(UsHolidayId.LaborDay, "Labor Day", 2026, 9, 7),
                Declared(UsHolidayId.ColumbusDay, "Columbus Day", 2026, 10, 12),
                Declared(UsHolidayId.VeteransDay, "Veterans Day", 2026, 11, 11),
                Declared(UsHolidayId.ThanksgivingDay, "Thanksgiving Day", 2026, 11, 26),
                Declared(UsHolidayId.ProclaimedHoliday, "State holiday", 2026, 11, 27),
                Declared(UsHolidayId.WashingtonsBirthday, "Washington's Birthday", 2026, 12, 24, new(2026, 2, 16)),
                Declared(UsHolidayId.ChristmasDay, "Christmas Day", 2026, 12, 25)
            ]
            : [
                Declared(UsHolidayId.NewYearsDay, "New Year's Day", 2027, 1, 1),
                Declared(UsHolidayId.MartinLutherKingJrDay, "Martin Luther King Jr.'s Birthday", 2027, 1, 18),
                Declared(UsHolidayId.ProclaimedHoliday, "State holiday", 2027, 3, 26),
                Declared(UsHolidayId.MemorialDay, "Memorial Day", 2027, 5, 31),
                Declared(UsHolidayId.Juneteenth, "Juneteenth", 2027, 6, 18, new(2027, 6, 19)),
                Declared(UsHolidayId.IndependenceDay, "Independence Day", 2027, 7, 5, new(2027, 7, 4)),
                Declared(UsHolidayId.LaborDay, "Labor Day", 2027, 9, 6),
                Declared(UsHolidayId.ColumbusDay, "Columbus Day", 2027, 10, 11),
                Declared(UsHolidayId.VeteransDay, "Veterans Day", 2027, 11, 11),
                Declared(UsHolidayId.ThanksgivingDay, "Thanksgiving Day", 2027, 11, 25),
                Declared(UsHolidayId.ProclaimedHoliday, "State holiday", 2027, 11, 26),
                Declared(UsHolidayId.WashingtonsBirthday, "Washington's Birthday", 2027, 12, 23, new(2027, 2, 15)),
                Declared(UsHolidayId.ChristmasDay, "Christmas Day", 2027, 12, 24, new(2027, 12, 25))
            ];
    }

    private static UsHolidayOccurrence Declared(UsHolidayId id, string name, int year, int month, int day,
        DateOnly? actualDate = null)
    {
        var date = new DateOnly(year, month, day);
        return new(id, name, date, actualDate ?? date);
    }
}
