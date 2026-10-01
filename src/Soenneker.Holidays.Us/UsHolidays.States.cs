using System;
using System.Collections.Generic;

namespace Soenneker.Holidays.Us;

public static partial class UsHolidays
{
    // Explicit selections: do not replace these with a federal fallback or ExampleJurisdictions parsing.
    private static readonly IReadOnlyList<UsStateHolidayDefinition> _states = Array.AsReadOnly<UsStateHolidayDefinition>(
    [
        new(UsState.Alabama, "AL",
            ["https://personnel.alabama.gov/Downloads/StateHolidays2026.pdf"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth, UsHolidayId.ConfederateMemorialDayFourthMonday,
                UsHolidayId.JeffersonDavisBirthdayFirstMonday
            ],
            [
                UsHolidayId.MardiGras, UsHolidayId.RosaParksDay, UsHolidayId.ProclaimedHoliday
            ],
            "Published state holiday list. MLK/Lee, Washington/Jefferson, and Columbus/Fraternal/American Indian Heritage share dates. Mardi Gras is limited to Mobile/Baldwin counties; Rosa Parks Day is commemorative. Extra governor-granted closures require supplied dates."),
        new(UsState.Alaska, "AK",
            ["https://www.akleg.gov/statutesPDF/Title-44.pdf"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.Juneteenth, UsHolidayId.SewardsDay, UsHolidayId.AlaskaDay,
                UsHolidayId.Sunday
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "AS 44.12.010 general holiday list, including Sundays. Juneteenth was added in 2024; current formulas are projected to all supported years."),
        new(UsState.Arizona, "AZ",
            ["https://www.azleg.gov/ars/1/00301.htm"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Sunday, UsHolidayId.MothersDay,
                UsHolidayId.FathersDay, UsHolidayId.AmericanFamilyDay, UsHolidayId.ArizonaNativeAmericanDay,
                UsHolidayId.NavajoCodeTalkersDay, UsHolidayId.ConstitutionCommemorationDay
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "ARS 1-301 includes ceremonial holidays, not just closures. Returns June 2, August 14, and September 17 nominal dates; their special Sunday ceremonial observances are not applied by the uniform observance argument."),
        new(UsState.Arkansas, "AR",
            ["https://sas.arkansas.gov/wp-content/uploads/52-Holidays-and-Birthday-Leave-5.23.2025.pdf"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.ChristmasEve
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "Ark. Code 1-5-101 through 104 as summarized by state personnel. Washington and Daisy Gatson Bates share a date. Individual birthday leave is not a common calendar holiday."),
        new(UsState.California, "CA",
            ["https://leginfo.legislature.ca.gov/faces/codes_displaySection.xhtml?lawCode=GOV&sectionNum=6700."],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth, UsHolidayId.Sunday,
                UsHolidayId.LincolnsBirthday, UsHolidayId.LunarNewYear, UsHolidayId.CesarChavezDay,
                UsHolidayId.GenocideRemembranceDay, UsHolidayId.Diwali, UsHolidayId.CaliforniaAdmissionDay,
                UsHolidayId.NativeAmericanDay, UsHolidayId.CaliforniaGoodFridayPartial
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "Government Code 6700, broader than paid employee holidays; local exceptions exist. Diwali requires supplied dates. March 31 is Farmworkers Day under the 2026 amendment. Thanksgiving uses the recurring national date; extraordinary proclamations are additional."),
        new(UsState.Colorado, "CO",
            ["https://leg.colorado.gov/bills/SB22-139",
             "https://leg.colorado.gov/bills/HB20-1031",
             "https://www.coloradojudicial.gov/sites/default/files/2023-12/Holidays_FY24.pdf"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.Juneteenth, UsHolidayId.FrancesXavierCabriniDay
            ],
            [
                UsHolidayId.CesarChavezDay, UsHolidayId.ProclaimedHoliday
            ],
            "CRS 24-11-101 legal holiday list. Cabrini replaces Columbus. Cesar Chavez is an optional employee substitution, not an additional universal closure."),
        new(UsState.Connecticut, "CT",
            ["https://www.cga.ct.gov/current/pub/chap_002.htm",
             "https://portal.ct.gov/das/statewide-hr/compensation-and-benefits/state-holidays"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth, UsHolidayId.LincolnsBirthday
            ],
            [
                UsHolidayId.GoodFriday, UsHolidayId.ProclaimedHoliday
            ],
            "CGS 1-4 named legal holidays; Thanksgiving follows its recurring national date. Good Friday is a proclaimed state closure rather than a named fixed rule in 1-4."),
        new(UsState.Delaware, "DE",
            ["https://delcode.delaware.gov/title1/c005/"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.MemorialDay,
                UsHolidayId.IndependenceDay, UsHolidayId.LaborDay, UsHolidayId.VeteransDay,
                UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth,
                UsHolidayId.GoodFriday, UsHolidayId.DayAfterThanksgiving, UsHolidayId.GeneralElectionDay,
                UsHolidayId.SaturdayHoliday
            ],
            [
                UsHolidayId.DelawareReturnDay, UsHolidayId.ProclaimedHoliday
            ],
            "1 Del. C. 501 includes Saturdays and biennial elections. Return Day is only Sussex County, from noon. Floating employee holidays are not shared calendar dates."),
        new(UsState.Florida, "FL",
            ["https://www.leg.state.fl.us/statutes/index.cfm?App_mode=Display_Statute&URL=0600-0699/0683/Sections/0683.01.html",
             "https://www.mybenefits.myflorida.com/work_and_life/additional_benefits/paid_leave_of_absence"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.WashingtonsBirthday, UsHolidayId.MemorialDay,
                UsHolidayId.IndependenceDay, UsHolidayId.LaborDay, UsHolidayId.ColumbusDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.Sunday, UsHolidayId.MartinLutherKingJrBirthday, UsHolidayId.RobertELeeBirthday,
                UsHolidayId.LincolnsBirthday, UsHolidayId.SusanBAnthonyBirthday, UsHolidayId.TuskegeeAirmenCommemorationDay,
                UsHolidayId.GoodFriday, UsHolidayId.PascuaFloridaDay, UsHolidayId.ConfederateMemorialDayApril26,
                UsHolidayId.JeffersonDavisBirthday, UsHolidayId.FlagDay, UsHolidayId.GeneralElectionDay
            ],
            [
                UsHolidayId.MardiGras, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.ProclaimedHoliday
            ],
            "FS 683.01 legal list uses January 15 for MLK; employee third-Monday observance is conditional. Mardi Gras applies only to qualifying counties."),
        new(UsState.Georgia, "GA",
            ["https://team.georgia.gov/all-articles/state-georgia-holiday-schedule",
             "https://gba.georgia.gov/document/document/state-holidays/download"],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            [],
            "Georgia sets its schedule by annual declaration. Published 2026 and 2027 dates are bundled, including displaced Washington's Birthday. Other years require supplied declared dates; no recurrence is inferred from these schedules."),
        new(UsState.Hawaii, "HI",
            ["https://dhrd.hawaii.gov/state-observed-holidays/"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.PrinceKuhioDay, UsHolidayId.GoodFriday, UsHolidayId.KingKamehamehaDay,
                UsHolidayId.HawaiiStatehoodDay, UsHolidayId.GeneralElectionDay
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "HRS 8-1 state holidays. No Columbus Day or Juneteenth closure is inferred. Election holiday is biennial."),
        new(UsState.Idaho, "ID",
            ["https://legislature.idaho.gov/statutesrules/idstat/Title73/T73CH1/SECT73-108/",
             "https://gov.idaho.gov/pressrelease/idaho-observes-juneteenth-as-new-legal-public-holiday/",
             "https://sos.idaho.gov/blue_book/2023/BlueBook_2023_2024.pdf"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth, UsHolidayId.Sunday
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "Idaho Code 73-108 and official state holiday list, including Juneteenth recognized under the federal-holiday provision."),
        new(UsState.Illinois, "IL",
            ["https://www.ilga.gov/Legislation/publicacts/view/102-0334"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth, UsHolidayId.LincolnsBirthday,
                UsHolidayId.CasimirPulaskiDay, UsHolidayId.GoodFriday, UsHolidayId.GeneralElectionDay,
                UsHolidayId.SaturdayHalfHoliday
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "Illinois has sector-specific lists. This uses the legal/banking list in 205 ILCS 630/17, including Saturday half-holidays, rather than assuming every listed day is an employee closure."),
        new(UsState.Indiana, "IN",
            ["https://iga.in.gov/laws/current/ic/titles/1#1-1-9",
             "https://iga.in.gov/laws/current/ic/titles/3#3-10",
             "https://www.in.gov/spd/benefits/state-holidays/"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.LincolnsBirthday, UsHolidayId.GoodFriday,
                UsHolidayId.Sunday, UsHolidayId.IndianaPrimaryDay, UsHolidayId.IndianaElectionDay
            ],
            [
                UsHolidayId.AdditionalElectionDay, UsHolidayId.ProclaimedHoliday
            ],
            "IC 1-1-9. Regular primary/November elections calculated for even and municipal-election years. Local, special, or rescheduled elections require supplied dates. Employee observance may move Lincoln's Birthday."),
        new(UsState.Iowa, "IA",
            ["https://www.legis.iowa.gov/docs/code/1c.pdf"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.LincolnsBirthday
            ],
            [
                UsHolidayId.DayAfterThanksgiving, UsHolidayId.ProclaimedHoliday
            ],
            "1C.1 legal public holidays; Friday after Thanksgiving is additional employee leave under 1C.2. Commemorative days in other sections are not automatically legal holidays."),
        new(UsState.Kansas, "KS",
            ["https://www.kslegislature.gov/li/b2025_26/statute/035_000_0000_chapter/035_001_0000_article/035_001_0007_section/035_001_0007_k/",
             "https://admin.ks.gov/offices/personnel-services/holidays"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay
            ],
            [
                UsHolidayId.Juneteenth, UsHolidayId.DayAfterThanksgiving, UsHolidayId.ProclaimedHoliday
            ],
            "KSA 35-107 statutory list. Juneteenth and Friday after Thanksgiving are employee-calendar additions, subject to executive scheduling."),
        new(UsState.Kentucky, "KY",
            ["https://apps.legislature.ky.gov/law/statutes/statute.aspx?id=46",
             "https://personnel.ky.gov/Pages/Leave.aspx"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.RobertELeeBirthday, UsHolidayId.FranklinDRooseveltDay,
                UsHolidayId.LincolnsBirthday, UsHolidayId.JeffersonDavisBirthday
            ],
            [
                UsHolidayId.Juneteenth, UsHolidayId.ChristmasEve, UsHolidayId.NewYearsEve,
                UsHolidayId.ProclaimedHoliday
            ],
            "KRS 2.110 named legal holidays, using the recurring Thanksgiving date. Employee closure schedules, including Juneteenth and holiday eves, are separate; supplied occurrences should represent partial leave where applicable."),
        new(UsState.Louisiana, "LA",
            ["https://legis.la.gov/legis/Law.aspx?d=74097",
             "https://www.legis.la.gov/legis/Law.aspx?d=1238710"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Sunday, UsHolidayId.BattleOfNewOrleans,
                UsHolidayId.MardiGras, UsHolidayId.GoodFriday, UsHolidayId.HueyPLongDay,
                UsHolidayId.AllSaintsDay, UsHolidayId.JuneteenthThirdSaturday
            ],
            [
                UsHolidayId.GeneralElectionDay, UsHolidayId.SaturdayHoliday, UsHolidayId.SaturdayHalfHoliday,
                UsHolidayId.WednesdayHalfHoliday, UsHolidayId.NewYearsEve, UsHolidayId.Juneteenth,
                UsHolidayId.ProclaimedHoliday
            ],
            "RS 1:55 general legal list and 1:55.1 third-Saturday Juneteenth. Conditional rules concern specified courts, banks, localities, or employee proclamations. June 19 is not substituted for the statutory third Saturday."),
        new(UsState.Maine, "ME",
            ["https://www.mainelegislature.org/LEGIS/STATUTES/4/title4sec1051-1.html",
             "https://www.maine.gov/bhr/state-hr-professionals/rules-policies/policy-practices-manual/Holidays"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.Juneteenth, UsHolidayId.PatriotsDay, UsHolidayId.IndigenousPeoplesDay,
                UsHolidayId.Sunday
            ],
            [
                UsHolidayId.DayAfterThanksgiving, UsHolidayId.ProclaimedHoliday
            ],
            "4 MRSA 1051 court/legal holidays. Day after Thanksgiving is an employee-calendar addition. Indigenous Peoples Day replaces Columbus."),
        new(UsState.Maryland, "MD",
            ["https://mgaleg.maryland.gov/mgawebsite/Laws/StatuteText?article=ggp&enactments=false&section=1-111"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth, UsHolidayId.LincolnsBirthday,
                UsHolidayId.MarylandDay, UsHolidayId.GoodFriday, UsHolidayId.DefendersDay,
                UsHolidayId.AmericanIndianHeritageDay, UsHolidayId.GeneralElectionDay
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "General Provisions 1-111 legal holiday list, broader than employee closures. American Indian Heritage Day is the Friday after Thanksgiving."),
        new(UsState.Massachusetts, "MA",
            ["https://malegislature.gov/Laws/GeneralLaws/PartI/TitleI/Chapter4/Section7"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth, UsHolidayId.PatriotsDay
            ],
            [
                UsHolidayId.EvacuationDay, UsHolidayId.BunkerHillDay, UsHolidayId.ProclaimedHoliday
            ],
            "Chapter 4 section 7 legal holidays. Evacuation and Bunker Hill are Suffolk County exceptions; public offices have statutory opening requirements on those days."),
        new(UsState.Michigan, "MI",
            ["https://legislature.mi.gov/Laws/MCL?objectName=MCL-435-101"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth, UsHolidayId.LincolnsBirthday,
                UsHolidayId.SaturdayHalfHoliday
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "MCL 435.101 public/half-holidays for instruments and courts, not the employee closure calendar."),
        new(UsState.Minnesota, "MN",
            ["https://www.revisor.mn.gov/statutes/cite/645.44"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.Juneteenth, UsHolidayId.IndigenousPeoplesDay
            ],
            [
                UsHolidayId.DayAfterThanksgiving, UsHolidayId.ProclaimedHoliday
            ],
            "645.44 subdivision 5 legal definition. The statute permits public employers to choose whether Indigenous Peoples Day and Friday after Thanksgiving are holidays."),
        new(UsState.Mississippi, "MS",
            ["https://sos.ms.gov/communications-publications/state-holidays"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.ConfederateMemorialDayLastMonday
            ],
            [
                UsHolidayId.MardiGras, UsHolidayId.ProclaimedHoliday
            ],
            "Mississippi official legal holiday list. MLK/Lee share January and Memorial/Jefferson Davis share May; Thanksgiving's recurring date is used pending any extra declaration."),
        new(UsState.Missouri, "MO",
            ["https://www.revisor.mo.gov/main/OneSection.aspx?section=9.010"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth, UsHolidayId.LincolnsBirthday,
                UsHolidayId.TrumanDay
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "RSMo 9.010 public holiday list."),
        new(UsState.Montana, "MT",
            ["https://mca.legmt.gov/bills/mca/title_0010/chapter_0010/part_0020/section_0160/0010-0010-0020-0160.html"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Sunday, UsHolidayId.IndigenousPeoplesDay,
                UsHolidayId.GeneralElectionDay
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "MCA 1-1-216, including the 2025 Indigenous Peoples Day name alongside Columbus on the same date; no Juneteenth is inferred."),
        new(UsState.Nebraska, "NE",
            ["https://nebraskalegislature.gov/laws/statutes.php?statute=s2522021000"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth, UsHolidayId.ArborDay,
                UsHolidayId.IndigenousPeoplesDay, UsHolidayId.DayAfterThanksgiving
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "Nebraska 25-2221 legal holidays; Columbus and Indigenous Peoples Day are the same date."),
        new(UsState.Nevada, "NV",
            ["https://www.leg.state.nv.us/nrs/NRS-236.html"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.Juneteenth, UsHolidayId.NevadaDay, UsHolidayId.DayAfterThanksgiving
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "NRS 236.015 actual legal Nevada Day is the last Friday of October; October 31 anniversary is not an extra holiday."),
        new(UsState.NewHampshire, "NH",
            ["https://gc.nh.gov/rsa/html/XXV/288/288-1.htm"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.GeneralElectionDay
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "RSA 288:1 legal list; Thanksgiving uses the recurring national date. Juneteenth recognition is not added as a legal holiday under this section."),
        new(UsState.NewJersey, "NJ",
            ["https://www.nj.gov/state/dos-commemorative-dates.shtml",
             "https://www.nj.gov/dcf/documents/news/Juneteenth%20Holiday.pdf"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.LincolnsBirthday, UsHolidayId.GoodFriday,
                UsHolidayId.JuneteenthThirdFriday, UsHolidayId.ElectionDay
            ],
            [
                UsHolidayId.SaturdayHoliday, UsHolidayId.ProclaimedHoliday
            ],
            "NJSA 36:1-1 public holidays; Juneteenth is third Friday, elections annual. Saturday rules also concern public offices under 36:1-1.1; that context-specific rule is conditional."),
        new(UsState.NewMexico, "NM",
            ["https://www.nmlegis.gov/Sessions/19%20Regular/bills/house/HB0100CPS.pdf",
             "https://www.spo.state.nm.us/"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.IndigenousPeoplesDay
            ],
            [
                UsHolidayId.Juneteenth, UsHolidayId.ProclaimedHoliday
            ],
            "NMSA 12-5-2 legal list, Indigenous Peoples replacing Columbus. State employee proclamations can add Juneteenth or move observances; they are not inferred from the statutory formula."),
        new(UsState.NewYork, "NY",
            ["https://www.nysenate.gov/legislation/laws/GCN/24"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth, UsHolidayId.LincolnsBirthday,
                UsHolidayId.NewYorkFlagDay, UsHolidayId.ElectionDay, UsHolidayId.SaturdayHalfHoliday
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "GCN 24 public/half-holidays. Flag Day is second Sunday in June, not June 14. General elections occur annually."),
        new(UsState.NorthCarolina, "NC",
            ["https://www.ncleg.gov/EnactedLegislation/Statutes/HTML/BySection/Chapter_103/GS_103-4.html"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.RobertELeeBirthday, UsHolidayId.GreekIndependenceDay,
                UsHolidayId.HalifaxResolvesDay, UsHolidayId.ConfederateMemorialDayMay10, UsHolidayId.MecklenburgDeclarationDay,
                UsHolidayId.GoodFriday, UsHolidayId.FirstRespondersDay, UsHolidayId.YomKippur,
                UsHolidayId.GeneralElectionDay
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "GS 103-4 legal list, broader than state employee closures. Easter Monday is not included. Hebrew dates represent the civil daytime portion."),
        new(UsState.NorthDakota, "ND",
            ["https://ndlegis.gov/prod/cencode/t01c03.pdf"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.Sunday, UsHolidayId.GoodFriday
            ],
            [
                UsHolidayId.NorthDakotaChristmasEvePartial, UsHolidayId.ProclaimedHoliday
            ],
            "1-03-01 legal list. Christmas Eve noon closure under 1-03-01.1 is conditional and omitted on weekends or when December 24 is the substituted Christmas holiday."),
        new(UsState.Ohio, "OH",
            ["https://codes.ohio.gov/ohio-revised-code/section-1.14"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "ORC 1.14 legal holiday list."),
        new(UsState.Oklahoma, "OK",
            ["https://govt.westlaw.com/okjc/Document/N9F7A2820C76C11DB8F04FB3E68C8F4C5?viewType=FullText",
             "https://oklahoma.gov/omes/divisions/human-capital-management/employee-benefits/leave-holidays/holidays.html"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.Sunday, UsHolidayId.SaturdayHoliday, UsHolidayId.DayAfterThanksgiving,
                UsHolidayId.OklahomaAdditionalChristmasHoliday
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "25 OS 82.1 legal list. An additional Christmas date depends on the executive order; published 2026/2027 selections are bundled, other years require supplied dates."),
        new(UsState.Oregon, "OR",
            ["https://www.oregonlegislature.gov/bills_laws/ors/ors187.html"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.Juneteenth, UsHolidayId.Sunday
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "ORS 187.010 legal holidays. Separately recognized commemorations are not treated as legal holidays."),
        new(UsState.Pennsylvania, "PA",
            ["https://www.legis.state.pa.us/WU01/LI/LI/US/PDF/1893/0/0138..PDF",
             "https://www.palegis.us/statutes/unconsolidated/act-name-search-results?keywords=HOLIDAY"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.GoodFriday, UsHolidayId.FlagDay,
                UsHolidayId.ElectionDay, UsHolidayId.SaturdayHalfHoliday
            ],
            [
                UsHolidayId.Juneteenth, UsHolidayId.ProclaimedHoliday
            ],
            "1893 Legal Holiday Law named dates and Saturday noon half-holidays. Juneteenth is separately recognized by Act 9 of 2019 and employee policy; it is conditional rather than silently amending the 1893 list."),
        new(UsState.RhodeIsland, "RI",
            ["https://webserver.rilegislature.gov/Statutes/TITLE25/25-1/25-1-1_25-1-1.htm"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth, UsHolidayId.RhodeIslandIndependenceDay,
                UsHolidayId.VictoryDay, UsHolidayId.GeneralElectionDay, UsHolidayId.Sunday
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "25-1-1 list effective 2024 including Juneteenth. State employee Saturday observance is following Monday, unlike federal Friday; choose observance explicitly for the relevant scope."),
        new(UsState.SouthCarolina, "SC",
            ["https://www.scstatehouse.gov/code/t53c005.php"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.ConfederateMemorialDayMay10, UsHolidayId.DayAfterThanksgiving, UsHolidayId.ChristmasEve,
                UsHolidayId.DayAfterChristmas
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "53-5-10 legal holiday list. Financial institutions have a separate federal-reserve holiday provision."),
        new(UsState.SouthDakota, "SD",
            ["https://sdlegislature.gov/api/Statutes/1-5.html?all=true"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.Juneteenth, UsHolidayId.Sunday, UsHolidayId.IndigenousPeoplesDay
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "1-5-1 legal list. Second Monday in October is Native Americans Day, represented by the Indigenous Peoples Day rule."),
        new(UsState.Tennessee, "TN",
            ["https://www.tn.gov/about-tn/state-holidays.html"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth, UsHolidayId.GoodFriday
            ],
            [
                UsHolidayId.DayAfterThanksgiving, UsHolidayId.ChristmasEve, UsHolidayId.NewYearsEve,
                UsHolidayId.ProclaimedHoliday
            ],
            "TCA Title 15 legal holidays; the employee calendar substitutes Friday after Thanksgiving for Columbus under 4-4-105. Extra closure dates and holiday eves depend on the governor and must be selected for the relevant year."),
        new(UsState.Texas, "TX",
            ["https://tcss.legis.texas.gov/resources/GV/htm/GV.662.htm",
             "https://comptroller.texas.gov/about/holidays-fy26.php"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.ConfederateHeroesDay, UsHolidayId.TexasIndependenceDay, UsHolidayId.SanJacintoDay,
                UsHolidayId.Juneteenth, UsHolidayId.LyndonBainesJohnsonDay, UsHolidayId.DayAfterThanksgiving,
                UsHolidayId.ChristmasEve, UsHolidayId.DayAfterChristmas
            ],
            [
                UsHolidayId.GoodFriday, UsHolidayId.RoshHashanah, UsHolidayId.YomKippur,
                UsHolidayId.CesarChavezDay, UsHolidayId.ProclaimedHoliday
            ],
            "Government Code 662 national/state holidays; conditional entries are optional substitutions. Texas state employee holidays on weekends do not automatically move to weekdays."),
        new(UsState.Utah, "UT",
            ["https://www.utcourts.gov/en/about/miscellaneous/law-library/holidays.html"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.UtahJuneteenth, UsHolidayId.PioneerDay
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "63G-1-301 legal dates as published by Utah courts. Juneteenth uses the special Utah Monday formula, not the national June 19 rule."),
        new(UsState.Vermont, "VT",
            ["https://legislature.vermont.gov/statutes/section/01/007/00371"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.Juneteenth, UsHolidayId.TownMeetingDay, UsHolidayId.BenningtonBattleDay,
                UsHolidayId.IndigenousPeoplesDay
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "1 VSA 371 legal holidays. Town Meeting Day here is the statutory first Tuesday in March, not a rescheduled local meeting."),
        new(UsState.Virginia, "VA",
            ["https://law.lis.virginia.gov/vacode/title2.2/chapter33/section2.2-3300/"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth, UsHolidayId.ElectionDay,
                UsHolidayId.DayAfterThanksgiving
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "2.2-3300 legal list, including annual November Election Day. Extra employee closure days require declaration."),
        new(UsState.Washington, "WA",
            ["https://app.leg.wa.gov/RCW/default.aspx?cite=1.16.050"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay,
                UsHolidayId.Juneteenth, UsHolidayId.Sunday, UsHolidayId.AmericanIndianHeritageDay
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "RCW 1.16.050(1) legal holidays; Friday after Thanksgiving is Native American Heritage Day. Separately recognized commemorations and floating religious leave are not universal holidays."),
        new(UsState.WestVirginia, "WV",
            ["https://code.wvlegislature.gov/2-2-1/",
             "https://sos.wv.gov/media/467/download?inline="],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.WestVirginiaDay, UsHolidayId.DayAfterThanksgiving,
                UsHolidayId.GeneralElectionDay, UsHolidayId.WestVirginiaPrimaryDay
            ],
            [
                UsHolidayId.AdditionalElectionDay, UsHolidayId.ProclaimedHoliday
            ],
            "2-2-1 legal holidays; Friday after Thanksgiving is Lincoln's Day. Regular primary/general elections are biennial; additional elections require supplied dates. Past Juneteenth proclamations are not assumed to recur."),
        new(UsState.Wisconsin, "WI",
            ["https://docs.legis.wisconsin.gov/statutes/statutes/995/20",
             "https://dpm.wi.gov/Pages/How_Do_I/seeStateHolidays.aspx"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.ColumbusDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth, UsHolidayId.GeneralElectionDay,
                UsHolidayId.WisconsinPartisanPrimaryDay, UsHolidayId.WisconsinGoodFridayPartial
            ],
            [
                UsHolidayId.ChristmasEve, UsHolidayId.NewYearsEve, UsHolidayId.AdditionalElectionDay,
                UsHolidayId.ProclaimedHoliday
            ],
            "995.20 legal holidays, distinct from the nine paid employee holidays. Good Friday is the 11 a.m.-3 p.m. worship period. Municipal election applicability is local and requires supplied dates."),
        new(UsState.Wyoming, "WY",
            ["https://www.wyoleg.gov/statutes/compress/title08.pdf"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay, UsHolidayId.ChristmasDay
            ],
            [
                UsHolidayId.ProclaimedHoliday
            ],
            "WS 8-4-101 legal list; no Columbus or Juneteenth legal closure is inferred."),
        new(UsState.DistrictOfColumbia, "DC",
            ["https://code.dccouncil.gov/us/dc/council/code/sections/1-612.02"],
            [
                UsHolidayId.NewYearsDay, UsHolidayId.MartinLutherKingJrDay, UsHolidayId.WashingtonsBirthday,
                UsHolidayId.MemorialDay, UsHolidayId.IndependenceDay, UsHolidayId.LaborDay,
                UsHolidayId.IndigenousPeoplesDay, UsHolidayId.VeteransDay, UsHolidayId.ThanksgivingDay,
                UsHolidayId.ChristmasDay, UsHolidayId.Juneteenth, UsHolidayId.DcEmancipationDay
            ],
            [
                UsHolidayId.InaugurationDay, UsHolidayId.ProclaimedHoliday
            ],
            "D.C. employee holidays under 1-612.02; Inauguration Day is conditional on the statutory eligibility/location requirements.")
    ]);
}
