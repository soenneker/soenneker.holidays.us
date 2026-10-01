using System;
using System.Collections.Generic;
using System.Linq;

namespace Soenneker.Holidays.Us.Tests;

public sealed class JurisdictionTests
{
    // Representative dates from each state's cited statute or published 2026 calendar.
    [Test]
    [Arguments(UsState.Alabama, UsHolidayId.ConfederateMemorialDayFourthMonday, 4, 27)]
    [Arguments(UsState.Alaska, UsHolidayId.AlaskaDay, 10, 18)]
    [Arguments(UsState.Arizona, UsHolidayId.ArizonaNativeAmericanDay, 6, 2)]
    [Arguments(UsState.Arkansas, UsHolidayId.ChristmasEve, 12, 24)]
    [Arguments(UsState.California, UsHolidayId.GenocideRemembranceDay, 4, 24)]
    [Arguments(UsState.Colorado, UsHolidayId.FrancesXavierCabriniDay, 10, 5)]
    [Arguments(UsState.Connecticut, UsHolidayId.LincolnsBirthday, 2, 12)]
    [Arguments(UsState.Delaware, UsHolidayId.GoodFriday, 4, 3)]
    [Arguments(UsState.Florida, UsHolidayId.MartinLutherKingJrBirthday, 1, 15)]
    [Arguments(UsState.Georgia, UsHolidayId.WashingtonsBirthday, 12, 24)]
    [Arguments(UsState.Hawaii, UsHolidayId.KingKamehamehaDay, 6, 11)]
    [Arguments(UsState.Idaho, UsHolidayId.Juneteenth, 6, 19)]
    [Arguments(UsState.Illinois, UsHolidayId.CasimirPulaskiDay, 3, 2)]
    [Arguments(UsState.Indiana, UsHolidayId.IndianaPrimaryDay, 5, 5)]
    [Arguments(UsState.Iowa, UsHolidayId.LincolnsBirthday, 2, 12)]
    [Arguments(UsState.Kansas, UsHolidayId.ColumbusDay, 10, 12)]
    [Arguments(UsState.Kentucky, UsHolidayId.FranklinDRooseveltDay, 1, 30)]
    [Arguments(UsState.Louisiana, UsHolidayId.JuneteenthThirdSaturday, 6, 20)]
    [Arguments(UsState.Maine, UsHolidayId.PatriotsDay, 4, 20)]
    [Arguments(UsState.Maryland, UsHolidayId.DefendersDay, 9, 12)]
    [Arguments(UsState.Massachusetts, UsHolidayId.PatriotsDay, 4, 20)]
    [Arguments(UsState.Michigan, UsHolidayId.LincolnsBirthday, 2, 12)]
    [Arguments(UsState.Minnesota, UsHolidayId.IndigenousPeoplesDay, 10, 12)]
    [Arguments(UsState.Mississippi, UsHolidayId.ConfederateMemorialDayLastMonday, 4, 27)]
    [Arguments(UsState.Missouri, UsHolidayId.TrumanDay, 5, 8)]
    [Arguments(UsState.Montana, UsHolidayId.GeneralElectionDay, 11, 3)]
    [Arguments(UsState.Nebraska, UsHolidayId.ArborDay, 4, 24)]
    [Arguments(UsState.Nevada, UsHolidayId.NevadaDay, 10, 30)]
    [Arguments(UsState.NewHampshire, UsHolidayId.GeneralElectionDay, 11, 3)]
    [Arguments(UsState.NewJersey, UsHolidayId.GoodFriday, 4, 3)]
    [Arguments(UsState.NewMexico, UsHolidayId.IndigenousPeoplesDay, 10, 12)]
    [Arguments(UsState.NewYork, UsHolidayId.ElectionDay, 11, 3)]
    [Arguments(UsState.NorthCarolina, UsHolidayId.HalifaxResolvesDay, 4, 12)]
    [Arguments(UsState.NorthDakota, UsHolidayId.GoodFriday, 4, 3)]
    [Arguments(UsState.Ohio, UsHolidayId.Juneteenth, 6, 19)]
    [Arguments(UsState.Oklahoma, UsHolidayId.DayAfterThanksgiving, 11, 27)]
    [Arguments(UsState.Oregon, UsHolidayId.Juneteenth, 6, 19)]
    [Arguments(UsState.Pennsylvania, UsHolidayId.FlagDay, 6, 14)]
    [Arguments(UsState.RhodeIsland, UsHolidayId.VictoryDay, 8, 10)]
    [Arguments(UsState.SouthCarolina, UsHolidayId.ConfederateMemorialDayMay10, 5, 10)]
    [Arguments(UsState.SouthDakota, UsHolidayId.IndigenousPeoplesDay, 10, 12)]
    [Arguments(UsState.Tennessee, UsHolidayId.GoodFriday, 4, 3)]
    [Arguments(UsState.Texas, UsHolidayId.SanJacintoDay, 4, 21)]
    [Arguments(UsState.Utah, UsHolidayId.UtahJuneteenth, 6, 15)]
    [Arguments(UsState.Vermont, UsHolidayId.TownMeetingDay, 3, 3)]
    [Arguments(UsState.Virginia, UsHolidayId.ElectionDay, 11, 3)]
    [Arguments(UsState.Virginia, UsHolidayId.DayAfterThanksgiving, 11, 27)]
    [Arguments(UsState.Washington, UsHolidayId.AmericanIndianHeritageDay, 11, 27)]
    [Arguments(UsState.WestVirginia, UsHolidayId.WestVirginiaPrimaryDay, 5, 12)]
    [Arguments(UsState.Wisconsin, UsHolidayId.WisconsinPartisanPrimaryDay, 8, 11)]
    [Arguments(UsState.Wyoming, UsHolidayId.WashingtonsBirthday, 2, 16)]
    [Arguments(UsState.DistrictOfColumbia, UsHolidayId.DcEmancipationDay, 4, 16)]
    public void EachJurisdictionHasItsOwn2026Fixture(UsState state, UsHolidayId holiday, int month, int day)
    {
        Check(UsHolidays.GetAllStateHolidays(2026, state).Occurrences.Any(h => h.Id == holiday && h.Date == new DateOnly(2026, month, day)),
            $"{state} is missing {holiday}.");
    }

    [Test]
    public void EveryPostalJurisdictionHasOneCompleteProfile()
    {
        string[] codes = "AL AK AZ AR CA CO CT DE FL GA HI ID IL IN IA KS KY LA ME MD MA MI MN MS MO MT NE NV NH NJ NM NY NC ND OH OK OR PA RI SC SD TN TX UT VT VA WA WV WI WY DC".Split(' ');
        Equal(51, UsHolidays.States.Count);
        Equal(51, Enum.GetValues<UsState>().Length);
        Check(codes.Order().SequenceEqual(UsHolidays.States.Select(s => s.Code).Order()));
        foreach (UsStateHolidayDefinition profile in UsHolidays.States)
        {
            Equal(profile.State, UsHolidays.GetState(profile.Code.ToLowerInvariant()));
            Check(profile.Holidays.Count > 0 && profile.Notes.Length > 0 && profile.SourceUrls.Count > 0);
            Check(profile.SourceUrls.All(s => Uri.IsWellFormedUriString(s, UriKind.Absolute)));
            Equal(profile.Holidays.Count, profile.Holidays.Distinct().Count());
            Check(!profile.Holidays.Intersect(profile.ConditionalHolidays).Any());
            foreach (UsHolidayId id in profile.Holidays.Concat(profile.ConditionalHolidays))
                Equal(id, UsHolidays.GetDefinition(id).Id);
        }
    }

    [Test]
    public void FederalCalendarHasElevenRulesWithObservedAndActualDates()
    {
        UsHolidayCalendar calendar = UsHolidays.GetAllFederalHolidays(2026);
        Equal(11, calendar.Occurrences.Select(h => h.Id).Distinct().Count());
        Equal(12, calendar.Occurrences.Count);
        Equal(0, calendar.UnresolvedHolidays.Count);
        Check(calendar.IsHoliday(new(2026, 7, 3)));
        Check(calendar.IsHoliday(new(2026, 7, 4)));
        Check(!calendar.IsHoliday(new(2026, 4, 3)));
        Check(UsHolidays.IsFederalHoliday(new(2021, 12, 31)));
        Check(!UsHolidays.IsFederalHoliday(new(2026, 7, 3), HolidayObservance.None));
        Check(!UsHolidays.GetAllFederalHolidays(2025).Occurrences.Any(h => h.Id == UsHolidayId.InaugurationDay));
        Check(UsHolidays.GetAllFederalHolidays(2025, includeInaugurationDay: true).Occurrences.Any(h => h.Id == UsHolidayId.InaugurationDay));
    }

    [Test]
    public void PennsylvaniaNamedLegalListMatchesEntireStatutorySelection()
    {
        string[] expected = "01-01 01-19 02-16 04-03 05-25 06-14 07-04 09-07 10-12 11-03 11-11 11-26 12-25".Split(' ');
        string[] actual = UsHolidays.GetAllStateHolidays(2026, "PA").Occurrences
            .Where(h => h.Id != UsHolidayId.SaturdayHalfHoliday).Select(h => h.Date.ToString("MM-dd")).ToArray();
        Check(expected.SequenceEqual(actual));
        Check(UsHolidays.IsStateHoliday(new(2026, 6, 14), "PA"));
        Check(!UsHolidays.IsStateHoliday(new(2026, 6, 15), "PA"));
    }

    [Test]
    public void StateSelectionsDoNotInheritMissingFederalHolidays()
    {
        foreach (UsState state in new[] { UsState.Delaware, UsState.Hawaii, UsState.Oregon, UsState.Washington,
                     UsState.Texas, UsState.NorthDakota, UsState.SouthCarolina, UsState.Mississippi, UsState.Wyoming })
            Check(!UsHolidays.GetStateDefinition(state).Holidays.Contains(UsHolidayId.ColumbusDay), state.ToString());
        foreach (UsState state in new[] { UsState.Arizona, UsState.Arkansas, UsState.Florida, UsState.Hawaii,
                     UsState.Iowa, UsState.Kansas, UsState.Mississippi, UsState.Montana, UsState.NorthCarolina,
                     UsState.NorthDakota, UsState.SouthCarolina, UsState.WestVirginia, UsState.Wyoming })
            Check(!UsHolidays.GetStateDefinition(state).Holidays.Contains(UsHolidayId.Juneteenth), state.ToString());
        Check(!UsHolidays.GetStateDefinition(UsState.Delaware).Holidays.Contains(UsHolidayId.WashingtonsBirthday));
        Check(!UsHolidays.GetStateDefinition(UsState.Colorado).Holidays.Contains(UsHolidayId.ColumbusDay));
    }

    [Test]
    public void DateVariantsStaySpecificToTheirStates()
    {
        UsHolidayCalendar nj = UsHolidays.GetAllStateHolidays(2025, "NJ");
        Check(nj.IsHoliday(new(2025, 6, 20)));
        Check(!nj.IsHoliday(new(2025, 6, 19)));
        UsHolidayCalendar ny = UsHolidays.GetAllStateHolidays(2025, UsState.NewYork);
        Equal(new DateOnly(2025, 6, 8), ny.Occurrences.Single(h => h.Id == UsHolidayId.NewYorkFlagDay).Date);
        Check(!ny.Occurrences.Any(h => h.Id == UsHolidayId.FlagDay));
        UsHolidayCalendar la = UsHolidays.GetAllStateHolidays(2026, UsState.Louisiana);
        Check(la.IsHoliday(new(2026, 6, 20)));
        Check(!la.IsHoliday(new(2026, 6, 19)));
        Check(!UsHolidays.GetStateDefinition(UsState.NorthCarolina).Holidays.Contains(UsHolidayId.EasterMonday));
    }

    [Test]
    public void LocalAndOptionalHolidaysRequireSelection()
    {
        Check(!UsHolidays.GetAllStateHolidays(2026, "MA").Occurrences.Any(h => h.Id == UsHolidayId.EvacuationDay));
        Check(UsHolidays.GetAllStateHolidays(2026, "MA", includeConditionalHolidays: true).Occurrences.Any(h => h.Id == UsHolidayId.EvacuationDay));
        Check(!UsHolidays.GetAllStateHolidays(2026, "TX").Occurrences.Any(h => h.Id == UsHolidayId.GoodFriday));
        Check(UsHolidays.GetAllStateHolidays(2026, "TX", includeConditionalHolidays: true).Occurrences.Any(h => h.Id == UsHolidayId.GoodFriday));
        UsHolidayOccurrence returnDay = UsHolidays.GetAllStateHolidays(2026, "DE", includeConditionalHolidays: true)
            .Occurrences.Single(h => h.Id == UsHolidayId.DelawareReturnDay);
        Equal(new DateOnly(2026, 11, 5), returnDay.Date);
        Check(!returnDay.Contains(new(11, 59)));
        Check(returnDay.Contains(new(12, 0)));
    }

    [Test]
    public void PartialDaysAndExplicitObservanceWorkThroughStateApi()
    {
        UsHolidayCalendar pa = UsHolidays.GetAllStateHolidays(2026, " pa ");
        Check(!pa.IsHoliday(new(2026, 1, 10), new TimeOnly(11, 59)));
        Check(pa.IsHoliday(new(2026, 1, 10), new TimeOnly(12, 0)));
        UsHolidayCalendar wi = UsHolidays.GetAllStateHolidays(2026, "WI");
        Check(!wi.IsHoliday(new(2026, 4, 3), new TimeOnly(10, 59)));
        Check(wi.IsHoliday(new(2026, 4, 3), new TimeOnly(11, 0)));
        Check(!wi.IsHoliday(new(2026, 4, 3), new TimeOnly(15, 0)));
        Check(!UsHolidays.IsStateHoliday(new(2026, 7, 3), UsState.Texas));
        Check(UsHolidays.IsStateHoliday(new(2026, 7, 3), UsState.Texas, HolidayObservance.NearestWeekday));
        // RI's employee weekend-to-Monday policy is explicitly selectable.
        Check(UsHolidays.GetAllStateHolidays(2026, "RI", HolidayObservance.WeekendToMonday).IsHoliday(new(2026, 7, 6)));
    }

    [Test]
    public void PublishedDeclarationsDoNotBecomeInventedRecurrences()
    {
        UsHolidayCalendar ga = UsHolidays.GetAllStateHolidays(2026, "GA");
        Equal(13, ga.Occurrences.Count);
        Equal(0, ga.UnresolvedHolidays.Count);
        Check(ga.IsHoliday(new(2026, 12, 24)));
        Check(!ga.IsHoliday(new(2026, 2, 16)));
        Equal(new DateOnly(2026, 2, 16), ga.Occurrences.Single(h => h.Id == UsHolidayId.WashingtonsBirthday).ActualDate);
        Check(UsHolidays.GetAllStateHolidays(2027, "GA").IsHoliday(new(2027, 12, 23)));
        UsHolidayCalendar unknown = UsHolidays.GetAllStateHolidays(2028, "GA");
        Equal(1, unknown.UnresolvedHolidays.Count);
        Throws<InvalidOperationException>(() => unknown.IsHoliday(new(2028, 1, 3)));
        Equal(0, UsHolidays.GetAllStateHolidays(2026, "OK").UnresolvedHolidays.Count);
        Check(UsHolidays.GetAllStateHolidays(2027, "OK").IsHoliday(new(2027, 12, 23)));
        Check(UsHolidays.GetAllStateHolidays(2028, "OK").UnresolvedHolidays.Any(h => h.Id == UsHolidayId.OklahomaAdditionalChristmasHoliday));
    }

    [Test]
    public void CallerCanResolveExternalStateDates()
    {
        var diwali = new UsHolidayOccurrence(UsHolidayId.Diwali, "Diwali", new(2026, 11, 8), new(2026, 11, 8));
        UsHolidayCalendar ca = UsHolidays.GetAllStateHolidays(2026, "CA");
        Check(ca.UnresolvedHolidays.Any(h => h.Id == UsHolidayId.Diwali));
        Throws<InvalidOperationException>(() => ca.IsHoliday(new(2026, 1, 6)));
        UsHolidayCalendar supplied = UsHolidays.GetAllStateHolidays(2026, "CA", additionalHolidays: [diwali]);
        Equal(0, supplied.UnresolvedHolidays.Count);
        Check(!supplied.IsHoliday(new(2026, 1, 6)));
        Check(supplied.IsHoliday(new(2026, 11, 8)));
        var declared = new UsHolidayOccurrence(UsHolidayId.ProclaimedHoliday, "Declared holiday", new(2028, 1, 3), new(2028, 1, 3));
        Equal(0, UsHolidays.GetAllStateHolidays(2028, "GA", additionalHolidays: [declared]).UnresolvedHolidays.Count);
    }

    [Test]
    public void ElectionRulesHandleOffYearsAndMondayAnchors()
    {
        Equal(0, UsHolidays.GetDates(UsHolidayId.IndianaPrimaryDay, 2025).Count);
        Equal(new DateOnly(2027, 5, 4), UsHolidays.GetDates(UsHolidayId.IndianaPrimaryDay, 2027).Single());
        Equal(new DateOnly(2022, 11, 8), UsHolidays.GetDates(UsHolidayId.IndianaElectionDay, 2022).Single());
        Equal(0, UsHolidays.GetDates(UsHolidayId.WestVirginiaPrimaryDay, 2027).Count);
        Equal(0, UsHolidays.GetDates(UsHolidayId.WisconsinPartisanPrimaryDay, 2027).Count);
        Check(UsHolidays.GetAllStateHolidays(2025, "PA").Occurrences.Any(h => h.Id == UsHolidayId.ElectionDay));
        Check(!UsHolidays.GetAllStateHolidays(2025, "HI").Occurrences.Any(h => h.Id == UsHolidayId.GeneralElectionDay));
    }

    [Test]
    public void AllStatesRemainSeparateAndImmutableAcrossYearBounds()
    {
        foreach (int year in new[] { 1583, 2026, 2027, 2050, 2500, 9998 })
        {
            IReadOnlyDictionary<UsState, UsHolidayCalendar> calendars = UsHolidays.GetAllStateHolidays(year);
            Equal(51, calendars.Count);
            foreach ((UsState state, UsHolidayCalendar calendar) in calendars)
            {
                Equal(year, calendar.Year);
                Check(calendar.Occurrences.All(h => h.Date.Year == year));
                Check(calendar.Occurrences.SequenceEqual(UsHolidays.GetAllStateHolidays(year, state).Occurrences));
            }
        }
        Throws<NotSupportedException>(() => ((IList<UsStateHolidayDefinition>)UsHolidays.States).Clear());
        Throws<NotSupportedException>(() => ((IList<UsHolidayId>)UsHolidays.GetStateDefinition(UsState.Texas).Holidays).Clear());
        Throws<NotSupportedException>(() => ((IDictionary<UsState, UsHolidayCalendar>)UsHolidays.GetAllStateHolidays(2026)).Clear());
        Check(UsHolidays.GetAllHolidays(2026).Occurrences.SequenceEqual(UsHolidays.GetCalendar(2026).Occurrences));
    }

    [Test]
    public void InvalidInputsAreRejectedRatherThanFallingBackToFederal()
    {
        Throws<ArgumentException>(() => UsHolidays.GetAllStateHolidays(2026, "XX"));
        Throws<ArgumentException>(() => UsHolidays.GetState("Pennsylvania"));
        Throws<ArgumentException>(() => UsHolidays.GetState("PR"));
        Throws<ArgumentException>(() => UsHolidays.GetState(" "));
        Throws<ArgumentNullException>(() => UsHolidays.GetState(null!));
        Throws<ArgumentOutOfRangeException>(() => UsHolidays.GetAllStateHolidays(2026, (UsState)0));
        Throws<ArgumentOutOfRangeException>(() => UsHolidays.GetAllStateHolidays(10000));
        Throws<ArgumentOutOfRangeException>(() => UsHolidays.GetAllStateHolidays(2026, (HolidayObservance)99));
        Throws<ArgumentOutOfRangeException>(() => UsHolidays.GetAllStateHolidays(2026, "GA", (HolidayObservance)99));
    }

    private static void Check(bool value, string message = "Assertion failed.")
    {
        if (!value) throw new Exception(message);
    }

    private static void Equal<T>(T expected, T actual) => Check(EqualityComparer<T>.Default.Equals(expected, actual), $"Expected {expected}, got {actual}.");

    private static void Throws<T>(Action action) where T : Exception
    {
        try { action(); }
        catch (T) { return; }
        throw new Exception($"Expected {typeof(T).Name}.");
    }
}
