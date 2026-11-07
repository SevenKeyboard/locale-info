namespace SevenKeyboard;

public static partial class LocaleInfo
{
    // Values and aliases from the original WinNls.h table. Query availability is gated below.
    public const uint LOCALE_ALL = 0; // enumerate all named based locales
    public const uint LOCALE_WINDOWS = 0x00000001; // shipped locales and/or replacements for them
    public const uint LOCALE_SUPPLEMENTAL = 0x00000002; // supplemental locales only
    public const uint LOCALE_ALTERNATE_SORTS = 0x00000004; // alternate sort locales
    public const uint LOCALE_REPLACEMENT = 0x00000008; // locales that replace shipped locales (callback flag only)
    public const uint LOCALE_NEUTRALDATA = 0x00000010; // Locales that are "neutral" (language only, region data is default)
    public const uint LOCALE_SPECIFICDATA = 0x00000020; // Locales that contain language and region data
    public const uint LOCALE_NOUSEROVERRIDE = 0x80000000; // Not Recommended - do not use user overrides
    public const uint LOCALE_USE_CP_ACP = 0x40000000; // DEPRECATED, call Unicode APIs instead: use the system ACP
    public const uint LOCALE_RETURN_NUMBER = 0x20000000; // return number instead of string
    public const uint LOCALE_RETURN_GENITIVE_NAMES = 0x10000000; // Flag to return the Genitive forms of month names
    public const uint LOCALE_ALLOW_NEUTRAL_NAMES = 0x08000000; // Flag to allow returning neutral names/lcids for name conversion
    public const uint LOCALE_SLOCALIZEDDISPLAYNAME = 0x00000002; // localized name of locale, eg "German (Germany)" in UI language
    public const uint LOCALE_SENGLISHDISPLAYNAME = 0x00000072; // Display name (language + country/region usually) in English, eg "German (Germany)"
    public const uint LOCALE_SNATIVEDISPLAYNAME = 0x00000073; // Display name in native locale language, eg "Deutsch (Deutschland)
    public const uint LOCALE_SLOCALIZEDLANGUAGENAME = 0x0000006f; // Language Display Name for a language, eg "German" in UI language
    public const uint LOCALE_SENGLISHLANGUAGENAME = 0x00001001; // English name of language, eg "German"
    public const uint LOCALE_SNATIVELANGUAGENAME = 0x00000004; // native name of language, eg "Deutsch"
    public const uint LOCALE_SLOCALIZEDCOUNTRYNAME = 0x00000006; // localized name of country/region, eg "Germany" in UI language
    public const uint LOCALE_SENGLISHCOUNTRYNAME = 0x00001002; // English name of country/region, eg "Germany"
    public const uint LOCALE_SNATIVECOUNTRYNAME = 0x00000008; // native name of country/region, eg "Deutschland"
    public const uint LOCALE_IDIALINGCODE = 0x00000005; // country/region dialing code, example: en-US and en-CA return 1.
    public const uint LOCALE_SLIST = 0x0000000C; // list item separator, eg "," for "1,2,3,4"
    public const uint LOCALE_IMEASURE = 0x0000000D; // 0 = metric, 1 = US measurement system
    public const uint LOCALE_SDECIMAL = 0x0000000E; // decimal separator, eg "." for 1,234.00
    public const uint LOCALE_STHOUSAND = 0x0000000F; // thousand separator, eg "," for 1,234.00
    public const uint LOCALE_SGROUPING = 0x00000010; // digit grouping, eg "3;0" for 1,000,000
    public const uint LOCALE_IDIGITS = 0x00000011; // number of fractional digits eg 2 for 1.00
    public const uint LOCALE_ILZERO = 0x00000012; // leading zeros for decimal, 0 for .97, 1 for 0.97
    public const uint LOCALE_INEGNUMBER = 0x00001010; // negative number mode, 0-4, see documentation
    public const uint LOCALE_SNATIVEDIGITS = 0x00000013; // native digits for 0-9, eg "0123456789"
    public const uint LOCALE_SCURRENCY = 0x00000014; // local monetary symbol, eg "$"
    public const uint LOCALE_SINTLSYMBOL = 0x00000015; // intl monetary symbol, eg "USD"
    public const uint LOCALE_SMONDECIMALSEP = 0x00000016; // monetary decimal separator, eg "." for $1,234.00
    public const uint LOCALE_SMONTHOUSANDSEP = 0x00000017; // monetary thousand separator, eg "," for $1,234.00
    public const uint LOCALE_SMONGROUPING = 0x00000018; // monetary grouping, eg "3;0" for $1,000,000.00
    public const uint LOCALE_ICURRDIGITS = 0x00000019; // # local monetary digits, eg 2 for $1.00
    public const uint LOCALE_ICURRENCY = 0x0000001B; // positive currency mode, 0-3, see documentation
    public const uint LOCALE_INEGCURR = 0x0000001C; // negative currency mode, 0-15, see documentation
    public const uint LOCALE_SSHORTDATE = 0x0000001F; // short date format string, eg "MM/dd/yyyy"
    public const uint LOCALE_SLONGDATE = 0x00000020; // long date format string, eg "dddd, MMMM dd, yyyy"
    public const uint LOCALE_STIMEFORMAT = 0x00001003; // time format string, eg "HH:mm:ss"
    public const uint LOCALE_SAM = 0x00000028; // AM designator, eg "AM"
    public const uint LOCALE_SPM = 0x00000029; // PM designator, eg "PM"
    public const uint LOCALE_ICALENDARTYPE = 0x00001009; // type of calendar specifier, eg CAL_GREGORIAN
    public const uint LOCALE_IOPTIONALCALENDAR = 0x0000100B; // additional calendar types specifier, eg CAL_GREGORIAN_US
    public const uint LOCALE_IFIRSTDAYOFWEEK = 0x0000100C; // first day of week specifier, 0-6, 0=Monday, 6=Sunday
    public const uint LOCALE_IFIRSTWEEKOFYEAR = 0x0000100D; // first week of year specifier, 0-2, see documentation
    public const uint LOCALE_SDAYNAME1 = 0x0000002A; // long name for Monday
    public const uint LOCALE_SDAYNAME2 = 0x0000002B; // long name for Tuesday
    public const uint LOCALE_SDAYNAME3 = 0x0000002C; // long name for Wednesday
    public const uint LOCALE_SDAYNAME4 = 0x0000002D; // long name for Thursday
    public const uint LOCALE_SDAYNAME5 = 0x0000002E; // long name for Friday
    public const uint LOCALE_SDAYNAME6 = 0x0000002F; // long name for Saturday
    public const uint LOCALE_SDAYNAME7 = 0x00000030; // long name for Sunday
    public const uint LOCALE_SABBREVDAYNAME1 = 0x00000031; // abbreviated name for Monday
    public const uint LOCALE_SABBREVDAYNAME2 = 0x00000032; // abbreviated name for Tuesday
    public const uint LOCALE_SABBREVDAYNAME3 = 0x00000033; // abbreviated name for Wednesday
    public const uint LOCALE_SABBREVDAYNAME4 = 0x00000034; // abbreviated name for Thursday
    public const uint LOCALE_SABBREVDAYNAME5 = 0x00000035; // abbreviated name for Friday
    public const uint LOCALE_SABBREVDAYNAME6 = 0x00000036; // abbreviated name for Saturday
    public const uint LOCALE_SABBREVDAYNAME7 = 0x00000037; // abbreviated name for Sunday
    public const uint LOCALE_SMONTHNAME1 = 0x00000038; // long name for January
    public const uint LOCALE_SMONTHNAME2 = 0x00000039; // long name for February
    public const uint LOCALE_SMONTHNAME3 = 0x0000003A; // long name for March
    public const uint LOCALE_SMONTHNAME4 = 0x0000003B; // long name for April
    public const uint LOCALE_SMONTHNAME5 = 0x0000003C; // long name for May
    public const uint LOCALE_SMONTHNAME6 = 0x0000003D; // long name for June
    public const uint LOCALE_SMONTHNAME7 = 0x0000003E; // long name for July
    public const uint LOCALE_SMONTHNAME8 = 0x0000003F; // long name for August
    public const uint LOCALE_SMONTHNAME9 = 0x00000040; // long name for September
    public const uint LOCALE_SMONTHNAME10 = 0x00000041; // long name for October
    public const uint LOCALE_SMONTHNAME11 = 0x00000042; // long name for November
    public const uint LOCALE_SMONTHNAME12 = 0x00000043; // long name for December
    public const uint LOCALE_SMONTHNAME13 = 0x0000100E; // long name for 13th month (if exists)
    public const uint LOCALE_SABBREVMONTHNAME1 = 0x00000044; // abbreviated name for January
    public const uint LOCALE_SABBREVMONTHNAME2 = 0x00000045; // abbreviated name for February
    public const uint LOCALE_SABBREVMONTHNAME3 = 0x00000046; // abbreviated name for March
    public const uint LOCALE_SABBREVMONTHNAME4 = 0x00000047; // abbreviated name for April
    public const uint LOCALE_SABBREVMONTHNAME5 = 0x00000048; // abbreviated name for May
    public const uint LOCALE_SABBREVMONTHNAME6 = 0x00000049; // abbreviated name for June
    public const uint LOCALE_SABBREVMONTHNAME7 = 0x0000004A; // abbreviated name for July
    public const uint LOCALE_SABBREVMONTHNAME8 = 0x0000004B; // abbreviated name for August
    public const uint LOCALE_SABBREVMONTHNAME9 = 0x0000004C; // abbreviated name for September
    public const uint LOCALE_SABBREVMONTHNAME10 = 0x0000004D; // abbreviated name for October
    public const uint LOCALE_SABBREVMONTHNAME11 = 0x0000004E; // abbreviated name for November
    public const uint LOCALE_SABBREVMONTHNAME12 = 0x0000004F; // abbreviated name for December
    public const uint LOCALE_SABBREVMONTHNAME13 = 0x0000100F; // abbreviated name for 13th month (if exists)
    public const uint LOCALE_SPOSITIVESIGN = 0x00000050; // positive sign, eg ""
    public const uint LOCALE_SNEGATIVESIGN = 0x00000051; // negative sign, eg "-"
    public const uint LOCALE_IPOSSIGNPOSN = 0x00000052; // positive sign position (derived from INEGCURR)
    public const uint LOCALE_INEGSIGNPOSN = 0x00000053; // negative sign position (derived from INEGCURR)
    public const uint LOCALE_IPOSSYMPRECEDES = 0x00000054; // mon sym precedes pos amt (derived from ICURRENCY)
    public const uint LOCALE_IPOSSEPBYSPACE = 0x00000055; // mon sym sep by space from pos amt (derived from ICURRENCY)
    public const uint LOCALE_INEGSYMPRECEDES = 0x00000056; // mon sym precedes neg amt (derived from INEGCURR)
    public const uint LOCALE_INEGSEPBYSPACE = 0x00000057; // mon sym sep by space from neg amt (derived from INEGCURR)
    public const uint LOCALE_FONTSIGNATURE = 0x00000058; // font signature
    public const uint LOCALE_SISO639LANGNAME = 0x00000059; // ISO abbreviated language name, eg "en"
    public const uint LOCALE_SISO3166CTRYNAME = 0x0000005A; // ISO abbreviated country/region name, eg "US"
    public const uint LOCALE_IPAPERSIZE = 0x0000100A; // 1 = letter, 5 = legal, 8 = a3, 9 = a4
    public const uint LOCALE_SENGCURRNAME = 0x00001007; // english name of currency, eg "Euro"
    public const uint LOCALE_SNATIVECURRNAME = 0x00001008; // native name of currency, eg "euro"
    public const uint LOCALE_SYEARMONTH = 0x00001006; // year month format string, eg "MM/yyyy"
    public const uint LOCALE_SSORTNAME = 0x00001013; // sort name, usually "", eg "Dictionary" in UI Language
    public const uint LOCALE_IDIGITSUBSTITUTION = 0x00001014; // 0 = context, 1 = none, 2 = national
    public const uint LOCALE_SNAME = 0x0000005c; // locale name (ie: en-us)
    public const uint LOCALE_SDURATION = 0x0000005d; // time duration format, eg "hh:mm:ss"
    public const uint LOCALE_SSHORTESTDAYNAME1 = 0x00000060; // Shortest day name for Monday
    public const uint LOCALE_SSHORTESTDAYNAME2 = 0x00000061; // Shortest day name for Tuesday
    public const uint LOCALE_SSHORTESTDAYNAME3 = 0x00000062; // Shortest day name for Wednesday
    public const uint LOCALE_SSHORTESTDAYNAME4 = 0x00000063; // Shortest day name for Thursday
    public const uint LOCALE_SSHORTESTDAYNAME5 = 0x00000064; // Shortest day name for Friday
    public const uint LOCALE_SSHORTESTDAYNAME6 = 0x00000065; // Shortest day name for Saturday
    public const uint LOCALE_SSHORTESTDAYNAME7 = 0x00000066; // Shortest day name for Sunday
    public const uint LOCALE_SISO639LANGNAME2 = 0x00000067; // 3 character ISO abbreviated language name, eg "eng"
    public const uint LOCALE_SISO3166CTRYNAME2 = 0x00000068; // 3 character ISO country/region name, eg "USA"
    public const uint LOCALE_SNAN = 0x00000069; // Not a Number, eg "NaN"
    public const uint LOCALE_SPOSINFINITY = 0x0000006a; // + Infinity, eg "infinity"
    public const uint LOCALE_SNEGINFINITY = 0x0000006b; // - Infinity, eg "-infinity"
    public const uint LOCALE_SSCRIPTS = 0x0000006c; // Typical scripts in the locale: ; delimited script codes, eg "Latn;"
    public const uint LOCALE_SPARENT = 0x0000006d; // Fallback name for resources, eg "en" for "en-US"
    public const uint LOCALE_SCONSOLEFALLBACKNAME = 0x0000006e; // Fallback name for within the console for Unicode Only locales, eg "en" for bn-IN
    public const uint LOCALE_IREADINGLAYOUT = 0x00000070; // Returns one of the following 4 reading layout values:
    public const uint LOCALE_INEUTRAL = 0x00000071; // Returns 0 for specific cultures, 1 for neutral cultures.
    public const uint LOCALE_INEGATIVEPERCENT = 0x00000074; // Returns 0-11 for the negative percent format
    public const uint LOCALE_IPOSITIVEPERCENT = 0x00000075; // Returns 0-3 for the positive percent formatIPOSITIVEPERCENT
    public const uint LOCALE_SPERCENT = 0x00000076; // Returns the percent symbol
    public const uint LOCALE_SPERMILLE = 0x00000077; // Returns the permille (U+2030) symbol
    public const uint LOCALE_SMONTHDAY = 0x00000078; // Returns the preferred month/day format
    public const uint LOCALE_SSHORTTIME = 0x00000079; // Returns the preferred short time format (ie: no seconds, just h:mm)
    public const uint LOCALE_SOPENTYPELANGUAGETAG = 0x0000007a; // Open type language tag, eg: "latn" or "dflt"
    public const uint LOCALE_SSORTLOCALE = 0x0000007b; // Name of locale to use for sorting/collation/casing behavior.
    public const uint LOCALE_SRELATIVELONGDATE = 0x0000007c; // Long date without year, day of week, month, date, eg: for lock screen
    public const uint LOCALE_ICONSTRUCTEDLOCALE = 0x0000007d; // Flags if this locale is constructed.  Avoid using.
    public const uint LOCALE_SSHORTESTAM = 0x0000007e; // Shortest AM designator, eg "A"
    public const uint LOCALE_SSHORTESTPM = 0x0000007f; // Shortest PM designator, eg "P"
    public const uint LOCALE_IUSEUTF8LEGACYACP = 0x00000666; // default ansi code page (use of Unicode is recommended instead)
    public const uint LOCALE_IUSEUTF8LEGACYOEMCP = 0x00000999; // default oem code page (use of Unicode is recommended instead)
    public const uint LOCALE_IDEFAULTCODEPAGE = 0x0000000B; // default oem code page for locale (user may configure as UTF-8, use of Unicode is recommended instead)
    public const uint LOCALE_IDEFAULTANSICODEPAGE = 0x00001004; // default ansi code page for locale (user may configure as UTF-8, use of Unicode is recommended instead)
    public const uint LOCALE_IDEFAULTMACCODEPAGE = 0x00001011; // default mac code page for locale (user may configure as UTF-8, use of Unicode is recommended instead)
    public const uint LOCALE_IDEFAULTEBCDICCODEPAGE = 0x00001012; // default ebcdic code page for a locale (use of Unicode is recommended instead)
    public const uint LOCALE_ILANGUAGE = 0x00000001; // DEPRECATED language id (LCID), LOCALE_SNAME preferred
    public const uint LOCALE_SABBREVLANGNAME = 0x00000003; // DEPRECATED arbitrary abbreviated language name, LOCALE_SISO639LANGNAME instead.
    public const uint LOCALE_SABBREVCTRYNAME = 0x00000007; // DEPRECATED arbitrary abbreviated country/region name, LOCALE_SISO3166CTRYNAME instead.
    public const uint LOCALE_IGEOID = 0x0000005B; // DEPRECATED geographical location id, use LOCALE_SISO3166CTRYNAME instead.
    public const uint LOCALE_IDEFAULTLANGUAGE = 0x00000009; // DEPRECATED default language id, deprecated
    public const uint LOCALE_IDEFAULTCOUNTRY = 0x0000000A; // DEPRECATED default country/region code, deprecated
    public const uint LOCALE_IINTLCURRDIGITS = 0x0000001A; // DEPRECATED, use LOCALE_ICURRDIGITS # intl monetary digits, eg 2 for $1.00
    public const uint LOCALE_SDATE = 0x0000001D; // DEPRECATED date separator (derived from LOCALE_SSHORTDATE, use that instead)
    public const uint LOCALE_STIME = 0x0000001E; // DEPRECATED time separator (derived from LOCALE_STIMEFORMAT, use that instead)
    public const uint LOCALE_IDATE = 0x00000021; // DEPRECATED short date format ordering (derived from LOCALE_SSHORTDATE, use that instead)
    public const uint LOCALE_ILDATE = 0x00000022; // DEPRECATED long date format ordering (derived from LOCALE_SLONGDATE, use that instead)
    public const uint LOCALE_ITIME = 0x00000023; // DEPRECATED time format specifier (derived from LOCALE_STIMEFORMAT, use that instead)
    public const uint LOCALE_ITIMEMARKPOSN = 0x00001005; // DEPRECATED time marker position (derived from LOCALE_STIMEFORMAT, use that instead)
    public const uint LOCALE_ICENTURY = 0x00000024; // DEPRECATED century format specifier (short date, LOCALE_SSHORTDATE is preferred)
    public const uint LOCALE_ITLZERO = 0x00000025; // DEPRECATED leading zeros in time field (derived from LOCALE_STIMEFORMAT, use that instead)
    public const uint LOCALE_IDAYLZERO = 0x00000026; // DEPRECATED leading zeros in day field (short date, LOCALE_SSHORTDATE is preferred)
    public const uint LOCALE_IMONLZERO = 0x00000027; // DEPRECATED leading zeros in month field (short date, LOCALE_SSHORTDATE is preferred)
    public const uint LOCALE_SKEYBOARDSTOINSTALL = 0x0000005e; // Used internally, see GetKeyboardLayoutName() function
    public const uint LOCALE_SLANGUAGE = LOCALE_SLOCALIZEDDISPLAYNAME; // DEPRECATED as new name is more readable.
    public const uint LOCALE_SLANGDISPLAYNAME = LOCALE_SLOCALIZEDLANGUAGENAME; // DEPRECATED as new name is more readable.
    public const uint LOCALE_SENGLANGUAGE = LOCALE_SENGLISHLANGUAGENAME; // DEPRECATED as new name is more readable.
    public const uint LOCALE_SNATIVELANGNAME = LOCALE_SNATIVELANGUAGENAME; // DEPRECATED as new name is more readable.
    public const uint LOCALE_SCOUNTRY = LOCALE_SLOCALIZEDCOUNTRYNAME; // DEPRECATED as new name is more readable.
    public const uint LOCALE_SENGCOUNTRY = LOCALE_SENGLISHCOUNTRYNAME; // DEPRECATED as new name is more readable.
    public const uint LOCALE_SNATIVECTRYNAME = LOCALE_SNATIVECOUNTRYNAME; // DEPRECATED as new name is more readable.
    public const uint LOCALE_ICOUNTRY = LOCALE_IDIALINGCODE; // Deprecated synonym for LOCALE_IDIALINGCODE
    public const uint LOCALE_S1159 = LOCALE_SAM; // DEPRECATED: Please use LOCALE_SAM, which is more readable.
    public const uint LOCALE_S2359 = LOCALE_SPM; // DEPRECATED: Please use LOCALE_SPM, which is more readable.
    public const uint LOCALE_NAME_USER_DEFAULT = 0;
    public const string LOCALE_NAME_INVARIANT = "";
    public const string LOCALE_NAME_SYSTEM_DEFAULT = "!x-sys-default-locale";
    public const uint LOCALE_NAME_MAX_LENGTH = 85;

    private static readonly Dictionary<string, uint> InfoTypes = CreateInfoTypes();

    private static Dictionary<string, uint> CreateInfoTypes()
    {
        var types = new Dictionary<string, uint>(StringComparer.OrdinalIgnoreCase);
        // The two nonnumeric NAME_* constants convert to zero in AHK DllCall UInt arguments.
        if (OSVersion.IsWindowsVistaOrGreater())
        {
            types.Add(nameof(LOCALE_ALL)[7..], LOCALE_ALL);
            types.Add(nameof(LOCALE_WINDOWS)[7..], LOCALE_WINDOWS);
            types.Add(nameof(LOCALE_SUPPLEMENTAL)[7..], LOCALE_SUPPLEMENTAL);
            types.Add(nameof(LOCALE_ALTERNATE_SORTS)[7..], LOCALE_ALTERNATE_SORTS);
            types.Add(nameof(LOCALE_REPLACEMENT)[7..], LOCALE_REPLACEMENT);
        }
        if (OSVersion.IsWindows7OrGreater())
        {
            types.Add(nameof(LOCALE_NEUTRALDATA)[7..], LOCALE_NEUTRALDATA);
            types.Add(nameof(LOCALE_SPECIFICDATA)[7..], LOCALE_SPECIFICDATA);
        }
        types.Add(nameof(LOCALE_NOUSEROVERRIDE)[7..], LOCALE_NOUSEROVERRIDE);
        types.Add(nameof(LOCALE_USE_CP_ACP)[7..], LOCALE_USE_CP_ACP);
        if (OSVersion.WinVer >= 0x0400)
            types.Add(nameof(LOCALE_RETURN_NUMBER)[7..], LOCALE_RETURN_NUMBER);
        if (OSVersion.IsWindows7OrGreater())
        {
            types.Add(nameof(LOCALE_RETURN_GENITIVE_NAMES)[7..], LOCALE_RETURN_GENITIVE_NAMES);
            types.Add(nameof(LOCALE_ALLOW_NEUTRAL_NAMES)[7..], LOCALE_ALLOW_NEUTRAL_NAMES);
        }
        types.Add(nameof(LOCALE_SLOCALIZEDDISPLAYNAME)[7..], LOCALE_SLOCALIZEDDISPLAYNAME);
        if (OSVersion.IsWindows7OrGreater())
        {
            types.Add(nameof(LOCALE_SENGLISHDISPLAYNAME)[7..], LOCALE_SENGLISHDISPLAYNAME);
            types.Add(nameof(LOCALE_SNATIVEDISPLAYNAME)[7..], LOCALE_SNATIVEDISPLAYNAME);
        }
        if (OSVersion.IsWindowsVistaOrGreater())
        {
            types.Add(nameof(LOCALE_SLOCALIZEDLANGUAGENAME)[7..], LOCALE_SLOCALIZEDLANGUAGENAME);
        }
        types.Add(nameof(LOCALE_SENGLISHLANGUAGENAME)[7..], LOCALE_SENGLISHLANGUAGENAME);
        types.Add(nameof(LOCALE_SNATIVELANGUAGENAME)[7..], LOCALE_SNATIVELANGUAGENAME);
        types.Add(nameof(LOCALE_SLOCALIZEDCOUNTRYNAME)[7..], LOCALE_SLOCALIZEDCOUNTRYNAME);
        types.Add(nameof(LOCALE_SENGLISHCOUNTRYNAME)[7..], LOCALE_SENGLISHCOUNTRYNAME);
        types.Add(nameof(LOCALE_SNATIVECOUNTRYNAME)[7..], LOCALE_SNATIVECOUNTRYNAME);
        types.Add(nameof(LOCALE_IDIALINGCODE)[7..], LOCALE_IDIALINGCODE);
        types.Add(nameof(LOCALE_SLIST)[7..], LOCALE_SLIST);
        types.Add(nameof(LOCALE_IMEASURE)[7..], LOCALE_IMEASURE);
        types.Add(nameof(LOCALE_SDECIMAL)[7..], LOCALE_SDECIMAL);
        types.Add(nameof(LOCALE_STHOUSAND)[7..], LOCALE_STHOUSAND);
        types.Add(nameof(LOCALE_SGROUPING)[7..], LOCALE_SGROUPING);
        types.Add(nameof(LOCALE_IDIGITS)[7..], LOCALE_IDIGITS);
        types.Add(nameof(LOCALE_ILZERO)[7..], LOCALE_ILZERO);
        types.Add(nameof(LOCALE_INEGNUMBER)[7..], LOCALE_INEGNUMBER);
        types.Add(nameof(LOCALE_SNATIVEDIGITS)[7..], LOCALE_SNATIVEDIGITS);
        types.Add(nameof(LOCALE_SCURRENCY)[7..], LOCALE_SCURRENCY);
        types.Add(nameof(LOCALE_SINTLSYMBOL)[7..], LOCALE_SINTLSYMBOL);
        types.Add(nameof(LOCALE_SMONDECIMALSEP)[7..], LOCALE_SMONDECIMALSEP);
        types.Add(nameof(LOCALE_SMONTHOUSANDSEP)[7..], LOCALE_SMONTHOUSANDSEP);
        types.Add(nameof(LOCALE_SMONGROUPING)[7..], LOCALE_SMONGROUPING);
        types.Add(nameof(LOCALE_ICURRDIGITS)[7..], LOCALE_ICURRDIGITS);
        types.Add(nameof(LOCALE_ICURRENCY)[7..], LOCALE_ICURRENCY);
        types.Add(nameof(LOCALE_INEGCURR)[7..], LOCALE_INEGCURR);
        types.Add(nameof(LOCALE_SSHORTDATE)[7..], LOCALE_SSHORTDATE);
        types.Add(nameof(LOCALE_SLONGDATE)[7..], LOCALE_SLONGDATE);
        types.Add(nameof(LOCALE_STIMEFORMAT)[7..], LOCALE_STIMEFORMAT);
        types.Add(nameof(LOCALE_SAM)[7..], LOCALE_SAM);
        types.Add(nameof(LOCALE_SPM)[7..], LOCALE_SPM);
        types.Add(nameof(LOCALE_ICALENDARTYPE)[7..], LOCALE_ICALENDARTYPE);
        types.Add(nameof(LOCALE_IOPTIONALCALENDAR)[7..], LOCALE_IOPTIONALCALENDAR);
        types.Add(nameof(LOCALE_IFIRSTDAYOFWEEK)[7..], LOCALE_IFIRSTDAYOFWEEK);
        types.Add(nameof(LOCALE_IFIRSTWEEKOFYEAR)[7..], LOCALE_IFIRSTWEEKOFYEAR);
        types.Add(nameof(LOCALE_SDAYNAME1)[7..], LOCALE_SDAYNAME1);
        types.Add(nameof(LOCALE_SDAYNAME2)[7..], LOCALE_SDAYNAME2);
        types.Add(nameof(LOCALE_SDAYNAME3)[7..], LOCALE_SDAYNAME3);
        types.Add(nameof(LOCALE_SDAYNAME4)[7..], LOCALE_SDAYNAME4);
        types.Add(nameof(LOCALE_SDAYNAME5)[7..], LOCALE_SDAYNAME5);
        types.Add(nameof(LOCALE_SDAYNAME6)[7..], LOCALE_SDAYNAME6);
        types.Add(nameof(LOCALE_SDAYNAME7)[7..], LOCALE_SDAYNAME7);
        types.Add(nameof(LOCALE_SABBREVDAYNAME1)[7..], LOCALE_SABBREVDAYNAME1);
        types.Add(nameof(LOCALE_SABBREVDAYNAME2)[7..], LOCALE_SABBREVDAYNAME2);
        types.Add(nameof(LOCALE_SABBREVDAYNAME3)[7..], LOCALE_SABBREVDAYNAME3);
        types.Add(nameof(LOCALE_SABBREVDAYNAME4)[7..], LOCALE_SABBREVDAYNAME4);
        types.Add(nameof(LOCALE_SABBREVDAYNAME5)[7..], LOCALE_SABBREVDAYNAME5);
        types.Add(nameof(LOCALE_SABBREVDAYNAME6)[7..], LOCALE_SABBREVDAYNAME6);
        types.Add(nameof(LOCALE_SABBREVDAYNAME7)[7..], LOCALE_SABBREVDAYNAME7);
        types.Add(nameof(LOCALE_SMONTHNAME1)[7..], LOCALE_SMONTHNAME1);
        types.Add(nameof(LOCALE_SMONTHNAME2)[7..], LOCALE_SMONTHNAME2);
        types.Add(nameof(LOCALE_SMONTHNAME3)[7..], LOCALE_SMONTHNAME3);
        types.Add(nameof(LOCALE_SMONTHNAME4)[7..], LOCALE_SMONTHNAME4);
        types.Add(nameof(LOCALE_SMONTHNAME5)[7..], LOCALE_SMONTHNAME5);
        types.Add(nameof(LOCALE_SMONTHNAME6)[7..], LOCALE_SMONTHNAME6);
        types.Add(nameof(LOCALE_SMONTHNAME7)[7..], LOCALE_SMONTHNAME7);
        types.Add(nameof(LOCALE_SMONTHNAME8)[7..], LOCALE_SMONTHNAME8);
        types.Add(nameof(LOCALE_SMONTHNAME9)[7..], LOCALE_SMONTHNAME9);
        types.Add(nameof(LOCALE_SMONTHNAME10)[7..], LOCALE_SMONTHNAME10);
        types.Add(nameof(LOCALE_SMONTHNAME11)[7..], LOCALE_SMONTHNAME11);
        types.Add(nameof(LOCALE_SMONTHNAME12)[7..], LOCALE_SMONTHNAME12);
        types.Add(nameof(LOCALE_SMONTHNAME13)[7..], LOCALE_SMONTHNAME13);
        types.Add(nameof(LOCALE_SABBREVMONTHNAME1)[7..], LOCALE_SABBREVMONTHNAME1);
        types.Add(nameof(LOCALE_SABBREVMONTHNAME2)[7..], LOCALE_SABBREVMONTHNAME2);
        types.Add(nameof(LOCALE_SABBREVMONTHNAME3)[7..], LOCALE_SABBREVMONTHNAME3);
        types.Add(nameof(LOCALE_SABBREVMONTHNAME4)[7..], LOCALE_SABBREVMONTHNAME4);
        types.Add(nameof(LOCALE_SABBREVMONTHNAME5)[7..], LOCALE_SABBREVMONTHNAME5);
        types.Add(nameof(LOCALE_SABBREVMONTHNAME6)[7..], LOCALE_SABBREVMONTHNAME6);
        types.Add(nameof(LOCALE_SABBREVMONTHNAME7)[7..], LOCALE_SABBREVMONTHNAME7);
        types.Add(nameof(LOCALE_SABBREVMONTHNAME8)[7..], LOCALE_SABBREVMONTHNAME8);
        types.Add(nameof(LOCALE_SABBREVMONTHNAME9)[7..], LOCALE_SABBREVMONTHNAME9);
        types.Add(nameof(LOCALE_SABBREVMONTHNAME10)[7..], LOCALE_SABBREVMONTHNAME10);
        types.Add(nameof(LOCALE_SABBREVMONTHNAME11)[7..], LOCALE_SABBREVMONTHNAME11);
        types.Add(nameof(LOCALE_SABBREVMONTHNAME12)[7..], LOCALE_SABBREVMONTHNAME12);
        types.Add(nameof(LOCALE_SABBREVMONTHNAME13)[7..], LOCALE_SABBREVMONTHNAME13);
        types.Add(nameof(LOCALE_SPOSITIVESIGN)[7..], LOCALE_SPOSITIVESIGN);
        types.Add(nameof(LOCALE_SNEGATIVESIGN)[7..], LOCALE_SNEGATIVESIGN);
        types.Add(nameof(LOCALE_IPOSSIGNPOSN)[7..], LOCALE_IPOSSIGNPOSN);
        types.Add(nameof(LOCALE_INEGSIGNPOSN)[7..], LOCALE_INEGSIGNPOSN);
        types.Add(nameof(LOCALE_IPOSSYMPRECEDES)[7..], LOCALE_IPOSSYMPRECEDES);
        types.Add(nameof(LOCALE_IPOSSEPBYSPACE)[7..], LOCALE_IPOSSEPBYSPACE);
        types.Add(nameof(LOCALE_INEGSYMPRECEDES)[7..], LOCALE_INEGSYMPRECEDES);
        types.Add(nameof(LOCALE_INEGSEPBYSPACE)[7..], LOCALE_INEGSEPBYSPACE);
        if (OSVersion.WinVer >= 0x0400)
        {
            types.Add(nameof(LOCALE_FONTSIGNATURE)[7..], LOCALE_FONTSIGNATURE);
            types.Add(nameof(LOCALE_SISO639LANGNAME)[7..], LOCALE_SISO639LANGNAME);
            types.Add(nameof(LOCALE_SISO3166CTRYNAME)[7..], LOCALE_SISO3166CTRYNAME);
        }
        if (OSVersion.WinVer >= 0x0500)
        {
            types.Add(nameof(LOCALE_IPAPERSIZE)[7..], LOCALE_IPAPERSIZE);
            types.Add(nameof(LOCALE_SENGCURRNAME)[7..], LOCALE_SENGCURRNAME);
            types.Add(nameof(LOCALE_SNATIVECURRNAME)[7..], LOCALE_SNATIVECURRNAME);
            types.Add(nameof(LOCALE_SYEARMONTH)[7..], LOCALE_SYEARMONTH);
            types.Add(nameof(LOCALE_SSORTNAME)[7..], LOCALE_SSORTNAME);
            types.Add(nameof(LOCALE_IDIGITSUBSTITUTION)[7..], LOCALE_IDIGITSUBSTITUTION);
        }
        if (OSVersion.WinVer >= 0x0600)
        {
            types.Add(nameof(LOCALE_SNAME)[7..], LOCALE_SNAME);
            types.Add(nameof(LOCALE_SDURATION)[7..], LOCALE_SDURATION);
            types.Add(nameof(LOCALE_SSHORTESTDAYNAME1)[7..], LOCALE_SSHORTESTDAYNAME1);
            types.Add(nameof(LOCALE_SSHORTESTDAYNAME2)[7..], LOCALE_SSHORTESTDAYNAME2);
            types.Add(nameof(LOCALE_SSHORTESTDAYNAME3)[7..], LOCALE_SSHORTESTDAYNAME3);
            types.Add(nameof(LOCALE_SSHORTESTDAYNAME4)[7..], LOCALE_SSHORTESTDAYNAME4);
            types.Add(nameof(LOCALE_SSHORTESTDAYNAME5)[7..], LOCALE_SSHORTESTDAYNAME5);
            types.Add(nameof(LOCALE_SSHORTESTDAYNAME6)[7..], LOCALE_SSHORTESTDAYNAME6);
            types.Add(nameof(LOCALE_SSHORTESTDAYNAME7)[7..], LOCALE_SSHORTESTDAYNAME7);
            types.Add(nameof(LOCALE_SISO639LANGNAME2)[7..], LOCALE_SISO639LANGNAME2);
            types.Add(nameof(LOCALE_SISO3166CTRYNAME2)[7..], LOCALE_SISO3166CTRYNAME2);
            types.Add(nameof(LOCALE_SNAN)[7..], LOCALE_SNAN);
            types.Add(nameof(LOCALE_SPOSINFINITY)[7..], LOCALE_SPOSINFINITY);
            types.Add(nameof(LOCALE_SNEGINFINITY)[7..], LOCALE_SNEGINFINITY);
            types.Add(nameof(LOCALE_SSCRIPTS)[7..], LOCALE_SSCRIPTS);
            types.Add(nameof(LOCALE_SPARENT)[7..], LOCALE_SPARENT);
            types.Add(nameof(LOCALE_SCONSOLEFALLBACKNAME)[7..], LOCALE_SCONSOLEFALLBACKNAME);
        }
        if (OSVersion.IsWindows7OrGreater())
        {
            types.Add(nameof(LOCALE_IREADINGLAYOUT)[7..], LOCALE_IREADINGLAYOUT);
            types.Add(nameof(LOCALE_INEUTRAL)[7..], LOCALE_INEUTRAL);
            types.Add(nameof(LOCALE_INEGATIVEPERCENT)[7..], LOCALE_INEGATIVEPERCENT);
            types.Add(nameof(LOCALE_IPOSITIVEPERCENT)[7..], LOCALE_IPOSITIVEPERCENT);
            types.Add(nameof(LOCALE_SPERCENT)[7..], LOCALE_SPERCENT);
            types.Add(nameof(LOCALE_SPERMILLE)[7..], LOCALE_SPERMILLE);
            types.Add(nameof(LOCALE_SMONTHDAY)[7..], LOCALE_SMONTHDAY);
            types.Add(nameof(LOCALE_SSHORTTIME)[7..], LOCALE_SSHORTTIME);
            types.Add(nameof(LOCALE_SOPENTYPELANGUAGETAG)[7..], LOCALE_SOPENTYPELANGUAGETAG);
            types.Add(nameof(LOCALE_SSORTLOCALE)[7..], LOCALE_SSORTLOCALE);
        }
        if (OSVersion.IsWindows8OrGreater())
        {
            types.Add(nameof(LOCALE_SRELATIVELONGDATE)[7..], LOCALE_SRELATIVELONGDATE);
        }
        if (OSVersion.IsWindows8Point1OrGreater())
        {
            types.Add(nameof(LOCALE_ICONSTRUCTEDLOCALE)[7..], LOCALE_ICONSTRUCTEDLOCALE);
        }
        if (OSVersion.IsWindows10OrGreater())
        {
            types.Add(nameof(LOCALE_SSHORTESTAM)[7..], LOCALE_SSHORTESTAM);
            types.Add(nameof(LOCALE_SSHORTESTPM)[7..], LOCALE_SSHORTESTPM);
        }
        if (OSVersion.BuildNumber >= 19402)
        {
            types.Add(nameof(LOCALE_IUSEUTF8LEGACYACP)[7..], LOCALE_IUSEUTF8LEGACYACP);
            types.Add(nameof(LOCALE_IUSEUTF8LEGACYOEMCP)[7..], LOCALE_IUSEUTF8LEGACYOEMCP);
        }
        types.Add(nameof(LOCALE_IDEFAULTCODEPAGE)[7..], LOCALE_IDEFAULTCODEPAGE);
        types.Add(nameof(LOCALE_IDEFAULTANSICODEPAGE)[7..], LOCALE_IDEFAULTANSICODEPAGE);
        types.Add(nameof(LOCALE_IDEFAULTMACCODEPAGE)[7..], LOCALE_IDEFAULTMACCODEPAGE);
        if (OSVersion.WinVer >= 0x0500)
        {
            types.Add(nameof(LOCALE_IDEFAULTEBCDICCODEPAGE)[7..], LOCALE_IDEFAULTEBCDICCODEPAGE);
        }
        types.Add(nameof(LOCALE_ILANGUAGE)[7..], LOCALE_ILANGUAGE);
        types.Add(nameof(LOCALE_SABBREVLANGNAME)[7..], LOCALE_SABBREVLANGNAME);
        types.Add(nameof(LOCALE_SABBREVCTRYNAME)[7..], LOCALE_SABBREVCTRYNAME);
        types.Add(nameof(LOCALE_IGEOID)[7..], LOCALE_IGEOID);
        types.Add(nameof(LOCALE_IDEFAULTLANGUAGE)[7..], LOCALE_IDEFAULTLANGUAGE);
        types.Add(nameof(LOCALE_IDEFAULTCOUNTRY)[7..], LOCALE_IDEFAULTCOUNTRY);
        types.Add(nameof(LOCALE_IINTLCURRDIGITS)[7..], LOCALE_IINTLCURRDIGITS);
        types.Add(nameof(LOCALE_SDATE)[7..], LOCALE_SDATE);
        types.Add(nameof(LOCALE_STIME)[7..], LOCALE_STIME);
        types.Add(nameof(LOCALE_IDATE)[7..], LOCALE_IDATE);
        types.Add(nameof(LOCALE_ILDATE)[7..], LOCALE_ILDATE);
        types.Add(nameof(LOCALE_ITIME)[7..], LOCALE_ITIME);
        types.Add(nameof(LOCALE_ITIMEMARKPOSN)[7..], LOCALE_ITIMEMARKPOSN);
        types.Add(nameof(LOCALE_ICENTURY)[7..], LOCALE_ICENTURY);
        types.Add(nameof(LOCALE_ITLZERO)[7..], LOCALE_ITLZERO);
        types.Add(nameof(LOCALE_IDAYLZERO)[7..], LOCALE_IDAYLZERO);
        types.Add(nameof(LOCALE_IMONLZERO)[7..], LOCALE_IMONLZERO);
        if (OSVersion.WinVer >= 0x0600)
        {
            types.Add(nameof(LOCALE_SKEYBOARDSTOINSTALL)[7..], LOCALE_SKEYBOARDSTOINSTALL);
        }
        types.Add(nameof(LOCALE_SLANGUAGE)[7..], LOCALE_SLANGUAGE);
        if (OSVersion.IsWindowsVistaOrGreater())
        {
            types.Add(nameof(LOCALE_SLANGDISPLAYNAME)[7..], LOCALE_SLANGDISPLAYNAME);
        }
        types.Add(nameof(LOCALE_SENGLANGUAGE)[7..], LOCALE_SENGLANGUAGE);
        types.Add(nameof(LOCALE_SNATIVELANGNAME)[7..], LOCALE_SNATIVELANGNAME);
        types.Add(nameof(LOCALE_SCOUNTRY)[7..], LOCALE_SCOUNTRY);
        types.Add(nameof(LOCALE_SENGCOUNTRY)[7..], LOCALE_SENGCOUNTRY);
        types.Add(nameof(LOCALE_SNATIVECTRYNAME)[7..], LOCALE_SNATIVECTRYNAME);
        types.Add(nameof(LOCALE_ICOUNTRY)[7..], LOCALE_ICOUNTRY);
        types.Add(nameof(LOCALE_S1159)[7..], LOCALE_S1159);
        types.Add(nameof(LOCALE_S2359)[7..], LOCALE_S2359);
        types.Add(nameof(LOCALE_NAME_USER_DEFAULT)[7..], LOCALE_NAME_USER_DEFAULT);
        types.Add(nameof(LOCALE_NAME_INVARIANT)[7..], 0);
        types.Add(nameof(LOCALE_NAME_SYSTEM_DEFAULT)[7..], 0);
        types.Add(nameof(LOCALE_NAME_MAX_LENGTH)[7..], LOCALE_NAME_MAX_LENGTH);
        return types;
    }
}
