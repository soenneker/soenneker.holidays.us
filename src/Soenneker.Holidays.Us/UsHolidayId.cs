namespace Soenneker.Holidays.Us;

/// <summary>Stable identifiers for the catalog's holiday date rules. Recognition depends on jurisdiction and context.</summary>
public enum UsHolidayId
{
    /// <summary>New Year's Day. January 1.</summary>
    NewYearsDay = 1,
    /// <summary>Martin Luther King Jr. Day. Third Monday in January.</summary>
    MartinLutherKingJrDay = 2,
    /// <summary>Washington's Birthday / Presidents' Day. Third Monday in February; state names vary.</summary>
    WashingtonsBirthday = 3,
    /// <summary>Memorial Day. Last Monday in May.</summary>
    MemorialDay = 4,
    /// <summary>Juneteenth / Emancipation Day in Texas. June 19. Calculation does not imply recognition before enactment.</summary>
    Juneteenth = 5,
    /// <summary>Independence Day. July 4.</summary>
    IndependenceDay = 6,
    /// <summary>Labor Day. First Monday in September.</summary>
    LaborDay = 7,
    /// <summary>Columbus Day. Second Monday in October.</summary>
    ColumbusDay = 8,
    /// <summary>Veterans Day. November 11.</summary>
    VeteransDay = 9,
    /// <summary>Thanksgiving Day. Fourth Thursday in November.</summary>
    ThanksgivingDay = 10,
    /// <summary>Christmas Day. December 25.</summary>
    ChristmasDay = 11,
    /// <summary>Presidential Inauguration Day. January 20 every four years (year remainder 1). Federal recognition is limited to the designated Washington, D.C. area; Sunday substitution only.</summary>
    InaugurationDay = 12,
    /// <summary>Martin Luther King Jr. Birthday (January 15). January 15; distinct from the Monday observance.</summary>
    MartinLutherKingJrBirthday = 13,
    /// <summary>Robert E. Lee Birthday (January 19). January 19.</summary>
    RobertELeeBirthday = 14,
    /// <summary>Confederate Heroes Day. January 19.</summary>
    ConfederateHeroesDay = 15,
    /// <summary>Franklin D. Roosevelt Day. January 30.</summary>
    FranklinDRooseveltDay = 16,
    /// <summary>Lincoln's Birthday. February 12.</summary>
    LincolnsBirthday = 17,
    /// <summary>Susan B. Anthony Birthday. February 15.</summary>
    SusanBAnthonyBirthday = 18,
    /// <summary>Washington's Birthday (February 22). February 22; actual birthday distinguished from third-Monday observance.</summary>
    WashingtonsBirthdayFebruary22 = 19,
    /// <summary>Mardi Gras / Shrove Tuesday. 47 days before Western Easter; recognition can be local or proclamation-dependent.</summary>
    MardiGras = 20,
    /// <summary>Good Friday. Two days before Western Easter.</summary>
    GoodFriday = 21,
    /// <summary>Easter Sunday. Gregorian Western Easter; also a Sunday legal holiday in jurisdictions recognizing Sundays.</summary>
    EasterSunday = 22,
    /// <summary>Easter Monday. Day after Western Easter; supplemental calculation, not listed in the current North Carolina holiday statute.</summary>
    EasterMonday = 23,
    /// <summary>Casimir Pulaski Day. First Monday in March.</summary>
    CasimirPulaskiDay = 24,
    /// <summary>Town Meeting Day. First Tuesday in March; local meetings may be scheduled differently.</summary>
    TownMeetingDay = 25,
    /// <summary>Texas Independence Day. March 2.</summary>
    TexasIndependenceDay = 26,
    /// <summary>Evacuation Day. March 17; Suffolk County, Massachusetts, with statutory limitations.</summary>
    EvacuationDay = 27,
    /// <summary>Prince Jonah Kuhio Kalanianaole Day. March 26.</summary>
    PrinceKuhioDay = 28,
    /// <summary>Seward's Day. Last Monday in March.</summary>
    SewardsDay = 29,
    /// <summary>Cesar Chavez Day / Farmworkers Day. March 31; naming and applicability vary.</summary>
    CesarChavezDay = 30,
    /// <summary>Tuskegee Airmen Commemoration Day. Fourth Thursday in March.</summary>
    TuskegeeAirmenCommemorationDay = 31,
    /// <summary>Pascua Florida Day. April 2; statutory date, not a separately shifted ceremonial observance.</summary>
    PascuaFloridaDay = 32,
    /// <summary>District of Columbia Emancipation Day. April 16.</summary>
    DcEmancipationDay = 33,
    /// <summary>Patriots' Day. Third Monday in April.</summary>
    PatriotsDay = 34,
    /// <summary>San Jacinto Day. April 21.</summary>
    SanJacintoDay = 35,
    /// <summary>Genocide Remembrance Day. April 24.</summary>
    GenocideRemembranceDay = 36,
    /// <summary>Confederate Memorial Day (April 26). April 26; distinct from Monday and May/June variants.</summary>
    ConfederateMemorialDayApril26 = 37,
    /// <summary>Confederate Memorial Day (fourth Monday in April). Fourth Monday in April.</summary>
    ConfederateMemorialDayFourthMonday = 38,
    /// <summary>Arbor Day (Nebraska). Last Friday in April; other states have different ceremonial Arbor Days.</summary>
    ArborDay = 39,
    /// <summary>Rhode Island Independence Day. May 4.</summary>
    RhodeIslandIndependenceDay = 40,
    /// <summary>Truman Day. May 8.</summary>
    TrumanDay = 41,
    /// <summary>Confederate Memorial Day (May 10). May 10.</summary>
    ConfederateMemorialDayMay10 = 42,
    /// <summary>Jefferson Davis Birthday / Confederate Memorial Day (June 3). June 3.</summary>
    JeffersonDavisBirthday = 43,
    /// <summary>Jefferson Davis Birthday (first Monday in June). First Monday in June.</summary>
    JeffersonDavisBirthdayFirstMonday = 44,
    /// <summary>King Kamehameha I Day. June 11.</summary>
    KingKamehamehaDay = 45,
    /// <summary>Flag Day. June 14.</summary>
    FlagDay = 46,
    /// <summary>Bunker Hill Day. June 17; Suffolk County, Massachusetts, with statutory limitations.</summary>
    BunkerHillDay = 47,
    /// <summary>West Virginia Day. June 20.</summary>
    WestVirginiaDay = 48,
    /// <summary>Pioneer Day. July 24.</summary>
    PioneerDay = 49,
    /// <summary>Victory Day. Second Monday in August.</summary>
    VictoryDay = 50,
    /// <summary>Bennington Battle Day. August 16.</summary>
    BenningtonBattleDay = 51,
    /// <summary>Hawaii Statehood Day. Third Friday in August.</summary>
    HawaiiStatehoodDay = 52,
    /// <summary>Lyndon Baines Johnson Day. August 27.</summary>
    LyndonBainesJohnsonDay = 53,
    /// <summary>Huey P. Long Day. August 30; agency observance may depend on proclamation.</summary>
    HueyPLongDay = 54,
    /// <summary>California Admission Day. September 9.</summary>
    CaliforniaAdmissionDay = 55,
    /// <summary>Native American Day (California). Fourth Friday in September.</summary>
    NativeAmericanDay = 56,
    /// <summary>Frances Xavier Cabrini Day. First Monday in October.</summary>
    FrancesXavierCabriniDay = 57,
    /// <summary>Indigenous Peoples' Day. Second Monday in October; also called Native Americans' Day in South Dakota.</summary>
    IndigenousPeoplesDay = 58,
    /// <summary>Alaska Day. October 18.</summary>
    AlaskaDay = 59,
    /// <summary>Nevada Day (last Friday in October). Last Friday in October; use this rule for the statutory observance.</summary>
    NevadaDay = 60,
    /// <summary>Nevada admission anniversary (October 31). October 31; the statutory observance is NevadaDay.</summary>
    NevadaAdmissionAnniversary = 61,
    /// <summary>All Saints' Day. November 1.</summary>
    AllSaintsDay = 62,
    /// <summary>November Election Day (annual). Tuesday after the first Monday in November, every year; excludes primaries and special elections.</summary>
    ElectionDay = 63,
    /// <summary>General Election Day (even years). Tuesday after the first Monday in November in even years.</summary>
    GeneralElectionDay = 64,
    /// <summary>Day after Thanksgiving / Family Day. Friday after Thanksgiving.</summary>
    DayAfterThanksgiving = 65,
    /// <summary>American Indian Heritage Day. Friday after Thanksgiving.</summary>
    AmericanIndianHeritageDay = 66,
    /// <summary>Christmas Eve. December 24; some jurisdictions recognize only a partial day.</summary>
    ChristmasEve = 67,
    /// <summary>Day after Christmas. December 26.</summary>
    DayAfterChristmas = 68,
    /// <summary>New Year's Eve. December 31; recognition may be limited to courts or government employees.</summary>
    NewYearsEve = 69,
    /// <summary>Battle of New Orleans. January 8.</summary>
    BattleOfNewOrleans = 70,
    /// <summary>Rosh Hashanah. Tishri 1 and 2; civil daytime dates, not the preceding sunset.</summary>
    RoshHashanah = 71,
    /// <summary>Yom Kippur. Tishri 10; civil daytime date, not the preceding sunset.</summary>
    YomKippur = 72,
    /// <summary>Lunar New Year. Chinese lunisolar new year using the .NET calendar; civil date.</summary>
    LunarNewYear = 73,
    /// <summary>Sunday. Every Sunday; include only where relevant to the caller's policy.</summary>
    Sunday = 74,
    /// <summary>Saturday half-holiday. Every Saturday from noon through the end of the day; context-specific.</summary>
    SaturdayHalfHoliday = 75,
    /// <summary>Saturday holiday. Every Saturday; limited to specified localities and institutions.</summary>
    SaturdayHoliday = 76,
    /// <summary>Wednesday half-holiday. Every Wednesday from noon; limited to specified Louisiana banking institutions.</summary>
    WednesdayHalfHoliday = 77,
    /// <summary>Good Friday (California partial day). Good Friday from noon until 3 p.m.</summary>
    CaliforniaGoodFridayPartial = 78,
    /// <summary>Diwali. Requires an authoritative Hindu-calendar date; no approximate lunar calculation is substituted.</summary>
    Diwali = 79,
    /// <summary>Proclaimed or special holiday. Dates declared by a President, governor, or local authority must be supplied externally.</summary>
    ProclaimedHoliday = 80,
    /// <summary>Maryland Day. March 25.</summary>
    MarylandDay = 81,
    /// <summary>Defenders' Day. September 12.</summary>
    DefendersDay = 82,
    /// <summary>Greek Independence Day. March 25.</summary>
    GreekIndependenceDay = 83,
    /// <summary>Anniversary of the Halifax Resolves. April 12.</summary>
    HalifaxResolvesDay = 84,
    /// <summary>Mecklenburg Declaration of Independence anniversary. May 20.</summary>
    MecklenburgDeclarationDay = 85,
    /// <summary>First Responders Day. September 11.</summary>
    FirstRespondersDay = 86,
    /// <summary>Confederate Memorial Day (last Monday in April). Last Monday in April; differs from the fourth Monday in some years.</summary>
    ConfederateMemorialDayLastMonday = 87,
    /// <summary>Juneteenth (third Friday in June). Third Friday in June; distinct from the June 19 rule.</summary>
    JuneteenthThirdFriday = 88,
    /// <summary>Rosa Parks Day. December 1; Alabama's published calendar labels this commemoration only, not an automatic closure.</summary>
    RosaParksDay = 89,
    /// <summary>Utah Juneteenth: Monday of the same week for Monday through Friday; following Monday for a weekend.</summary>
    UtahJuneteenth = 90,
    /// <summary>Second Sunday in May.</summary>
    MothersDay = 91,
    /// <summary>Third Sunday in June.</summary>
    FathersDay = 92,
    /// <summary>First Sunday in August.</summary>
    AmericanFamilyDay = 93,
    /// <summary>June 2; ceremonial observance on the following Sunday when not Sunday.</summary>
    ArizonaNativeAmericanDay = 94,
    /// <summary>August 14; ceremonial observance on the following Sunday when not Sunday.</summary>
    NavajoCodeTalkersDay = 95,
    /// <summary>September 17; ceremonial observance on the preceding Sunday when not Sunday.</summary>
    ConstitutionCommemorationDay = 96,
    /// <summary>Second Sunday in June; distinct from June 14.</summary>
    NewYorkFlagDay = 97,
    /// <summary>Good Friday from 11 a.m. until 3 p.m.</summary>
    WisconsinGoodFridayPartial = 98,
    /// <summary>Second Tuesday in August in even years; excludes special or rescheduled elections.</summary>
    WisconsinPartisanPrimaryDay = 99,
    /// <summary>Second Tuesday in May in even years; excludes special or rescheduled elections.</summary>
    WestVirginiaPrimaryDay = 100,
    /// <summary>Tuesday after the first Monday in May, even years and municipal election years (remainder 3).</summary>
    IndianaPrimaryDay = 101,
    /// <summary>Tuesday after the first Monday in November, even years and municipal election years (remainder 3).</summary>
    IndianaElectionDay = 102,
    /// <summary>Thursday after the biennial November election, from noon.</summary>
    DelawareReturnDay = 103,
    /// <summary>Third Saturday in June; state employee June 19 closures are separately proclaimed.</summary>
    JuneteenthThirdSaturday = 104,
    /// <summary>December 24 from noon, unless a weekend or the substituted Christmas holiday.</summary>
    NorthDakotaChristmasEvePartial = 105,
    /// <summary>Requires the executive order selecting the additional Christmas date; do not assume December 24.</summary>
    OklahomaAdditionalChristmasHoliday = 106,
    /// <summary>Supply applicable special, municipal, primary, or rescheduled election dates from the election authority.</summary>
    AdditionalElectionDay = 107,
}

