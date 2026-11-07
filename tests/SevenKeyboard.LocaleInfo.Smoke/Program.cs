using System.Runtime.InteropServices;
using SevenKeyboard;

[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.System32)]

internal static unsafe class Program
{
    private static int checks;

    private static void Main()
    {
        // Numeric LCTYPEs below come from WinNls.h, independently of the library constants.
        (string Name, uint Type)[] strings =
        [
            ("SLOCALIZEDDISPLAYNAME", 0x02), ("SENGLISHDISPLAYNAME", 0x72),
            ("SNATIVEDISPLAYNAME", 0x73), ("SLOCALIZEDLANGUAGENAME", 0x6f),
            ("SENGLISHLANGUAGENAME", 0x1001), ("SNATIVELANGUAGENAME", 0x04),
            ("SLOCALIZEDCOUNTRYNAME", 0x06), ("SENGLISHCOUNTRYNAME", 0x1002),
            ("SNATIVECOUNTRYNAME", 0x08), ("SLIST", 0x0c), ("SDECIMAL", 0x0e),
            ("STHOUSAND", 0x0f), ("SGROUPING", 0x10), ("SNATIVEDIGITS", 0x13),
            ("SCURRENCY", 0x14), ("SINTLSYMBOL", 0x15), ("SMONDECIMALSEP", 0x16),
            ("SMONTHOUSANDSEP", 0x17), ("SMONGROUPING", 0x18),
            ("SSHORTDATE", 0x1f), ("SLONGDATE", 0x20), ("STIMEFORMAT", 0x1003),
            ("SAM", 0x28), ("SPM", 0x29), ("SPOSITIVESIGN", 0x50), ("SNEGATIVESIGN", 0x51),
            ("SISO639LANGNAME", 0x59), ("SISO3166CTRYNAME", 0x5a),
            ("SENGCURRNAME", 0x1007), ("SNATIVECURRNAME", 0x1008),
            ("SYEARMONTH", 0x1006), ("SSORTNAME", 0x1013), ("SNAME", 0x5c),
            ("SDURATION", 0x5d), ("SISO639LANGNAME2", 0x67), ("SISO3166CTRYNAME2", 0x68),
            ("SNAN", 0x69), ("SPOSINFINITY", 0x6a), ("SNEGINFINITY", 0x6b),
            ("SSCRIPTS", 0x6c), ("SPARENT", 0x6d), ("SCONSOLEFALLBACKNAME", 0x6e),
            ("SPERCENT", 0x76), ("SPERMILLE", 0x77), ("SMONTHDAY", 0x78),
            ("SSHORTTIME", 0x79), ("SOPENTYPELANGUAGETAG", 0x7a), ("SSORTLOCALE", 0x7b),
            ("SRELATIVELONGDATE", 0x7c), ("SSHORTESTAM", 0x7e), ("SSHORTESTPM", 0x7f),
            ("SABBREVLANGNAME", 0x03), ("SABBREVCTRYNAME", 0x07),
            ("SDATE", 0x1d), ("STIME", 0x1e), ("SKEYBOARDSTOINSTALL", 0x5e),
            ("SLANGUAGE", 0x02), ("SLANGDISPLAYNAME", 0x6f), ("SENGLANGUAGE", 0x1001),
            ("SNATIVELANGNAME", 0x04), ("SCOUNTRY", 0x06), ("SENGCOUNTRY", 0x1002),
            ("SNATIVECTRYNAME", 0x08), ("S1159", 0x28), ("S2359", 0x29),
            // Non-I names retain the string path even when their values alias numeric LCTYPEs.
            ("WINDOWS", 0x01), ("SUPPLEMENTAL", 0x02), ("ALTERNATE_SORTS", 0x04),
            ("REPLACEMENT", 0x08), ("NEUTRALDATA", 0x10), ("SPECIFICDATA", 0x20),
            ("NAME_MAX_LENGTH", 85), ("ALL", 0), ("NAME_USER_DEFAULT", 0),
            ("NAME_INVARIANT", 0), ("NAME_SYSTEM_DEFAULT", 0),
            ("NOUSEROVERRIDE", 0x80000000), ("USE_CP_ACP", 0x40000000),
            ("RETURN_NUMBER", 0x20000000), ("RETURN_GENITIVE_NAMES", 0x10000000),
            ("ALLOW_NEUTRAL_NAMES", 0x08000000)
        ];
        (string Name, uint Type)[] numbers =
        [
            ("IDIALINGCODE", 0x05), ("IMEASURE", 0x0d), ("IDIGITS", 0x11),
            ("ILZERO", 0x12), ("INEGNUMBER", 0x1010), ("ICURRDIGITS", 0x19),
            ("ICURRENCY", 0x1b), ("INEGCURR", 0x1c), ("ICALENDARTYPE", 0x1009),
            ("IOPTIONALCALENDAR", 0x100b), ("IFIRSTDAYOFWEEK", 0x100c),
            ("IFIRSTWEEKOFYEAR", 0x100d), ("IPOSSIGNPOSN", 0x52), ("INEGSIGNPOSN", 0x53),
            ("IPOSSYMPRECEDES", 0x54), ("IPOSSEPBYSPACE", 0x55),
            ("INEGSYMPRECEDES", 0x56), ("INEGSEPBYSPACE", 0x57),
            ("IPAPERSIZE", 0x100a), ("IDIGITSUBSTITUTION", 0x1014), ("IREADINGLAYOUT", 0x70),
            ("INEUTRAL", 0x71), ("INEGATIVEPERCENT", 0x74), ("IPOSITIVEPERCENT", 0x75),
            ("ICONSTRUCTEDLOCALE", 0x7d), ("IDEFAULTCODEPAGE", 0x0b),
            ("IDEFAULTANSICODEPAGE", 0x1004), ("IDEFAULTMACCODEPAGE", 0x1011),
            ("IDEFAULTEBCDICCODEPAGE", 0x1012), ("ILANGUAGE", 0x01), ("IGEOID", 0x5b),
            ("IDEFAULTLANGUAGE", 0x09), ("IDEFAULTCOUNTRY", 0x0a), ("IINTLCURRDIGITS", 0x1a),
            ("IDATE", 0x21), ("ILDATE", 0x22), ("ITIME", 0x23), ("ITIMEMARKPOSN", 0x1005),
            ("ICENTURY", 0x24), ("ITLZERO", 0x25), ("IDAYLZERO", 0x26),
            ("IMONLZERO", 0x27), ("ICOUNTRY", 0x05)
        ];
        foreach (string? locale in new string?[] { "ja-JP", "en-US", "ar-SA", "ko-KR", "ja", "", null, "#invalid!" })
        {
            foreach (var item in strings)
            {
                CheckString(locale, locale, item.Name, item.Type);
                CheckString(locale, locale, item.Name.ToLowerInvariant(), item.Type);
            }
            foreach (var item in numbers)
            {
                CheckNumber(locale, item.Name, item.Type);
                CheckNumber(locale, item.Name.ToLowerInvariant(), item.Type);
            }
            for (uint day = 0; day < 7; day++)
            {
                CheckString(locale, locale, $"SDAYNAME{day + 1}", 0x2a + day);
                CheckString(locale, locale, $"SABBREVDAYNAME{day + 1}", 0x31 + day);
                CheckString(locale, locale, $"SSHORTESTDAYNAME{day + 1}", 0x60 + day);
            }
            for (uint month = 0; month < 13; month++)
            {
                CheckString(locale, locale, $"SMONTHNAME{month + 1}", month == 12 ? 0x100e : 0x38 + month);
                CheckString(locale, locale, $"SABBREVMONTHNAME{month + 1}", month == 12 ? 0x100f : 0x44 + month);
            }
            foreach (string item in new[] { "FONTSIGNATURE", "fontsignature", "FontSignature" })
                CheckSignature(locale, item);

            foreach (var item in new[] { ("IUSEUTF8LEGACYACP", 0x666u), ("IUSEUTF8LEGACYOEMCP", 0x999u) })
            {
                if (Environment.OSVersion.Version.Build >= 19402)
                    CheckNumber(locale, item.Item1, item.Item2);
                else
                {
                    Equal(0u, LocaleInfo.GetEx<uint>(locale, item.Item1, out int unavailable), item.Item1);
                    Equal(0, unavailable, "Original build 19402 gate");
                }
            }
        }

        // Expectations confirmed against the original AHK, separate from native comparisons.
        Equal("ja-JP", LocaleInfo.GetEx<string>("ja-JP", "sname", out int ret), "AHK lowercase text");
        Equal(6, ret, "AHK SNAME character count");
        Equal("日本語", LocaleInfo.GetEx<string>("ja-JP", "SNATIVELANGUAGENAME", out ret), "AHK native language");
        Equal(4, ret, "Native language character count");
        Equal(2u, LocaleInfo.GetEx<uint>("ja-JP", "ireadinglayout", out ret), "AHK lowercase number");
        Equal(2, ret, "AHK DWORD count");
        Equal(0u, LocaleInfo.GetEx<uint>("ja-JP", "INEUTRAL", out ret), "Successful numeric zero");
        Equal(2, ret, "Numeric zero success count");
        Equal("", LocaleInfo.GetEx<string>("", "SNAME", out ret), "AHK empty locale is invariant");
        Equal(1, ret, "Invariant empty string succeeds");

        foreach (string alias in new[] { "NAME_INVARIANT", "name_invariant", "Name_Invariant" })
            CheckString(alias, "", "SNAME", 0x5c);
        foreach (string alias in new[] { "NAME_SYSTEM_DEFAULT", "name_system_default", "!x-sys-default-locale" })
            CheckString(alias, SystemLocale(), "SNAME", 0x5c);
        foreach (string? alias in new string?[] { null, "NAME_USER_DEFAULT", "name_user_default", "0", "00", "-0", "+0", "0.0", ".0", "0.", "0x0", "0X0", " 0 ", "\t0\t", "0.0e2", "0.0e2e3", "1.0e-999" })
            CheckString(alias, UserLocale(), "SNAME", 0x5c);
        foreach (string literal in new[] { "0e2", "\n0", "0\n", "0.0e2.5", "0x10000000000000000", "18446744073709551616" })
            CheckString(literal, literal, "SNAME", 0x5c);
        Equal(UserLocale(), LocaleInfo.GetEx<string>(infoType: "SNAME"), "Optional default locale");
        Equal("", LocaleInfo.GetEx<string>(), "Optional empty infoType");

        foreach (string? invalid in new string?[] { null, "", "BOGUS", "ILOCALE_DOES_NOT_EXIST", "LOCALE_SNAME", " SNAME", "SNAME " })
        {
            Equal("", LocaleInfo.GetEx<string>("ja-JP", invalid, out ret), "Unknown text type");
            Equal(0, ret, "Unknown type failure count");
            Equal(0u, LocaleInfo.GetEx<uint>("ja-JP", invalid, out ret), "Unknown numeric type");
            Equal(0, ret, "Unknown number count");
            LocaleSignature signature = LocaleInfo.GetEx<LocaleSignature>("ja-JP", invalid, out ret);
            Equal(0, ret, "Unknown signature count");
            CheckZeroSignature(signature);
        }
        ExpectArgument(() => LocaleInfo.GetEx<int>("ja-JP", "IREADINGLAYOUT"));
        ExpectArgument(() => LocaleInfo.GetEx<object>("ja-JP", "SNAME"));
        ExpectArgument(() => LocaleInfo.GetEx<ulong>("ja-JP", "IREADINGLAYOUT"));
        ExpectArgument(() => LocaleInfo.GetEx<uint>("ja-JP", "SNAME"));
        ExpectArgument(() => LocaleInfo.GetEx<string>("ja-JP", "ireadinglayout"));
        ExpectArgument(() => LocaleInfo.GetEx<string>("ja-JP", "fontsignature"));
        ExpectArgument(() => LocaleInfo.GetEx<LocaleSignature>("ja-JP", "SNAME"));
        ExpectArgument(() => LocaleInfo.GetEx<LocaleSignature>("ja-JP", "IREADINGLAYOUT"));
        ExpectArgument(() => LocaleInfo.GetEx<uint>("ja-JP", "FONTSIGNATURE"));
        Console.WriteLine($"PASS: {checks} checks; process {RuntimeInformation.ProcessArchitecture}; Windows {Environment.OSVersion.Version}.");
    }

    private static void CheckString(string? locale, string? nativeLocale, string name, uint type)
    {
        // One fixed native buffer makes the oracle independent of the wrapper's two-call allocation.
        char* buffer = stackalloc char[1024];
        int expectedRet = GetLocaleInfoEx(nativeLocale, type, buffer, 1024);
        string expected = expectedRet == 0 ? "" : new string(buffer);
        string actual = LocaleInfo.GetEx<string>(locale, name, out int actualRet);
        Equal(expectedRet, actualRet, $"{locale ?? "null"}/{name} count");
        Equal(expected, actual, $"{locale ?? "null"}/{name} text");
    }

    private static void CheckNumber(string? locale, string name, uint type)
    {
        uint expected = 0;
        int expectedRet = GetLocaleInfoEx(locale, type | 0x20000000, &expected, 2);
        uint actual = LocaleInfo.GetEx<uint>(locale, name, out int actualRet);
        Equal(expectedRet, actualRet, $"{locale ?? "null"}/{name} count");
        Equal(expectedRet == 0 ? 0u : expected, actual, $"{locale ?? "null"}/{name} number");
    }

    private static void CheckSignature(string? locale, string name)
    {
        uint* expected = stackalloc uint[8];
        int expectedRet = GetLocaleInfoEx(locale, 0x58, expected, 16);
        LocaleSignature actual = LocaleInfo.GetEx<LocaleSignature>(locale, name, out int actualRet);
        Equal(expectedRet, actualRet, $"{locale ?? "null"}/{name} count");
        Equal(4, actual.LsUsb.Length, "USB length");
        Equal(2, actual.LsCsbDefault.Length, "Default CSB length");
        Equal(2, actual.LsCsbSupported.Length, "Supported CSB length");
        if (expectedRet == 0)
            CheckZeroSignature(actual);
        else
        {
            for (int i = 0; i < 4; i++)
                Equal(expected[i], actual.LsUsb[i], "USB value");
            for (int i = 0; i < 2; i++)
            {
                Equal(expected[i + 4], actual.LsCsbDefault[i], "Default CSB value");
                Equal(expected[i + 6], actual.LsCsbSupported[i], "Supported CSB value");
            }
        }
    }

    private static void CheckZeroSignature(LocaleSignature value)
    {
        foreach (uint item in value.LsUsb) Equal(0u, item, "Default USB");
        foreach (uint item in value.LsCsbDefault) Equal(0u, item, "Default CSB");
        foreach (uint item in value.LsCsbSupported) Equal(0u, item, "Default supported CSB");
    }

    private static string UserLocale()
    {
        char* buffer = stackalloc char[85];
        if (GetUserDefaultLocaleName(buffer, 85) == 0) throw new Exception("Native user locale failed.");
        return new string(buffer);
    }

    private static string SystemLocale()
    {
        char* buffer = stackalloc char[85];
        if (GetSystemDefaultLocaleName(buffer, 85) == 0) throw new Exception("Native system locale failed.");
        return new string(buffer);
    }

    private static void Equal<T>(T expected, T actual, string label)
    {
        checks++;
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
            throw new Exception($"{label}: expected [{expected}], got [{actual}].");
    }

    private static void ExpectArgument(Action call)
    {
        checks++;
        try { call(); }
        catch (ArgumentException) { return; }
        throw new Exception("Expected ArgumentException for a programming error.");
    }

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
    private static extern int GetLocaleInfoEx(string? localeName, uint type, void* buffer, int count);

    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern int GetUserDefaultLocaleName(char* buffer, int count);

    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern int GetSystemDefaultLocaleName(char* buffer, int count);
}
