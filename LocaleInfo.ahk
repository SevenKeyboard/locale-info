#Requires AutoHotkey v1.1.36+
#Include %A_ScriptDir%
#Include .\lib\OSVersion.ahk
;==============================================================
; LocaleInfo — GetLocaleInfoEx wrapper + LOCALE_* constants (WinNls.h)
;
; GitHub: https://github.com/SevenKeyboard/locale-info
; Author: SevenKeyboard Ltd. (2025)
; License: MIT License
;
; Documentation / References:
;   GetLocaleInfoEx function (winnls.h)
;     Note  The application should call this function in preference to GetLocaleInfo if designed to run only on Windows Vista and later.
;     https://learn.microsoft.com/en-us/windows/win32/api/winnls/nf-winnls-getlocaleinfoex
;==============================================================

/*
Example Usage:
    #Requires AutoHotkey v1.1
    #Include %A_ScriptDir%
    #Include .\lib\ObjectDumpUtils.ahk
    msgbox % LocaleInfo.getEx(,"SNATIVECOUNTRYNAME")
    msgbox % LocaleInfo.getEx(,"IFIRSTDAYOFWEEK")
    msgbox % dumpArray(LocaleInfo.getEx("ja-JP","FONTSIGNATURE"))
*/

class VersionManager_LocaleInfo
{
    static _ := VersionManager_LocaleInfo._init()
    _init()    {
        global
        LOCALEINFO_VERSION := "1.0.0"
        if (!this._verCheck(OSVERSION_VERSION, "2.0.0"))
            throw exception("OSVersion version 2.x is required (minimum 2.0.0).")
        return true
    }
    _verCheck(byRef actual, required)    {
        if !isSet(actual)
            return false
        actualMajor     := strSplit(actual, ".",, 2)[1]
        requiredMajor   := strSplit(required, ".",, 2)[1]
        if (actualMajor !== requiredMajor)
            return false
        return verCompare(actual, ">=" required)
    }
}
class LocaleInfo
{
    getEx(localeName:="NAME_USER_DEFAULT", infoType:="", byRef ret:="")    {
        if (!this._isInitialized)
            this._init()
        ret:=0
        if (infoType=="" || !this.hasKey("LOCALE_" infoType))
            return
        switch (localeName)
        {
            case "NAME_USER_DEFAULT":       lpLocaleName:=0
            case "NAME_INVARIANT":          varSetCapacity(buf,strLen(this.LOCALE_NAME_INVARIANT)*2,0)          ,strPut(this.LOCALE_NAME_INVARIANT, &buf, "UTF-16")         ,lpLocaleName:=&buf ;  ""
            case "NAME_SYSTEM_DEFAULT":     varSetCapacity(buf,strLen(this.LOCALE_NAME_SYSTEM_DEFAULT)*2,0)     ,strPut(this.LOCALE_NAME_SYSTEM_DEFAULT, &buf, "UTF-16")    ,lpLocaleName:=&buf ;  "!x-sys-default-locale"
            default:
                if (localeName==0)    {
                    lpLocaleName:=0
                }  else  {
                    varSetCapacity(buf,min(this.LOCALE_NAME_MAX_LENGTH,strLen(localeName))*2,0)
                    ,strPut(localeName, &buf, "UTF-16")
                    ,lpLocaleName:=&buf
                }
        }
        if (subStr(infoType,1,1)="I")    { ;  LOCALE_RETURN_NUMBER  This constant can be combined with any other constant having a name that begins with "LOCALE_I".
            return (ret:=dllCall("Kernel32.dll\GetLocaleInfoEx", "Ptr",lpLocaleName, "UInt",LCType:=(this["LOCALE_" infoType]|this.LOCALE_RETURN_NUMBER), "UInt*",value, "Int",2, "Int")) ;  2  sizeof(value) / sizeof(WCHAR)
                ?value
                :""
        }  else  {
            switch ("LOCALE_" infoType)
            {
                case "LOCALE_FONTSIGNATURE":
                    varSetCapacity(LocSig,32,0) ;  4*4+4*2+4*2
                    if (ret:=dllCall("Kernel32.dll\GetLocaleInfoEx", "Ptr",lpLocaleName, "UInt",LCType:=this.LOCALE_FONTSIGNATURE, "Ptr",&LocSig, "Int",16, "Int"))    { ;  16  sizeof(LocSig) / sizeof(WCHAR)
                        _:=[]
                        loop 8
                            _.push(format("0x{:08X}", numGet(&LocSig,4*(A_Index-1),"UInt")))
                        return {lsUsb:[_[1],_[2],_[3],_[4]], lsCsbDefault:[_[5],_[6]], lsCsbSupported:[_[7],_[8]]}
                    }
                default:
                    if !(cchData:=dllCall("Kernel32.dll\GetLocaleInfoEx", "Ptr",lpLocaleName, "UInt",LCType:=this["LOCALE_" infoType], "Ptr",0, "Ptr",0, "Int"))
                        return
                    varSetCapacity(lpLCData, cchData*2, 0)
                    if (ret:=dllCall("Kernel32.dll\GetLocaleInfoEx", "Ptr",lpLocaleName, "UInt",LCType, "Ptr",&lpLCData, "Int",cchData, "Int"))
                        return strGet(&lpLCData, cchData, "UTF-16")
            }
        }
    }
    ;--------------------------------------------
    static _isInitialized:=false
    _init()    { ;  C:\Program Files (x86)\Windows Kits\10\Include\10.0.22000.0\um\WinNls.h
        if (this._isInitialized)
            return
        this._isInitialized:=true

        
        if (OSVersion.IsWindowsVistaOrGreater())    {
        ;  //
        ;  //  Named based enumeration flags.
        ;  //
            this.LOCALE_ALL                     := 0            ;  // enumerate all named based locales
            this.LOCALE_WINDOWS                 := 0x00000001   ;  // shipped locales and/or replacements for them
            this.LOCALE_SUPPLEMENTAL            := 0x00000002   ;  // supplemental locales only
            this.LOCALE_ALTERNATE_SORTS         := 0x00000004   ;  // alternate sort locales
            this.LOCALE_REPLACEMENT             := 0x00000008   ;  // locales that replace shipped locales (callback flag only)
        }
        if (OSVersion.IsWindows7OrGreater())    {
            this.LOCALE_NEUTRALDATA             := 0x00000010   ;  // Locales that are "neutral" (language only, region data is default)
            this.LOCALE_SPECIFICDATA            := 0x00000020   ;  // Locales that contain language and region data
        }
        

        ;  //
        ;  //  Locale Types.
        ;  //
        ;  //  These types are used for the GetLocaleInfo NLS API routine.
        ;  //  Some of these types are also used for the SetLocaleInfo NLS API routine.
        ;  //

        ;  //
        ;  //  The following LCTypes may be used in combination with any other LCTypes.
        ;  //
        ;  //    LOCALE_NOUSEROVERRIDE is also used in GetTimeFormat and
        ;  //    GetDateFormat.
        ;  //
        ;  //    LOCALE_RETURN_NUMBER will return the result from GetLocaleInfo as a
        ;  //    number instead of a string.  This flag is only valid for the LCTypes
        ;  //    beginning with LOCALE_I.
        ;  //
        ;  //    DEPRECATED: LOCALE_USE_CP_ACP is used in many of the A (Ansi) apis that need
        ;  //                to do string translation.  Callers are encouraged to use the W
        ;  //                (WCHAR/Unicode) apis instead.
        ;  //
        this.LOCALE_NOUSEROVERRIDE              := 0x80000000   ;  // Not Recommended - do not use user overrides
        this.LOCALE_USE_CP_ACP                  := 0x40000000   ;  // DEPRECATED, call Unicode APIs instead: use the system ACP

        if (OSVersion.WINVER >= 0x0400)
            this.LOCALE_RETURN_NUMBER           := 0x20000000   ;  // return number instead of string
        
        if (OSVersion.IsWindows7OrGreater())    {
            this.LOCALE_RETURN_GENITIVE_NAMES   := 0x10000000   ;  //Flag to return the Genitive forms of month names
            this.LOCALE_ALLOW_NEUTRAL_NAMES     := 0x08000000   ;  //Flag to allow returning neutral names/lcids for name conversion
        }


        ;  //
        ;  //  The following LCTypes are mutually exclusive in that they may NOT
        ;  //  be used in combination with each other.
        ;  //

        ;  //
        ;  // These are the various forms of the name of the locale:
        ;  //
        this.LOCALE_SLOCALIZEDDISPLAYNAME       := 0x00000002   ;  // localized name of locale, eg "German (Germany)" in UI language
        if (OSVersion.IsWindows7OrGreater())    {
            this.LOCALE_SENGLISHDISPLAYNAME     := 0x00000072   ;  // Display name (language + country/region usually) in English, eg "German (Germany)"
            this.LOCALE_SNATIVEDISPLAYNAME      := 0x00000073   ;  // Display name in native locale language, eg "Deutsch (Deutschland)
        }

        if (OSVersion.IsWindowsVistaOrGreater())    {
            this.LOCALE_SLOCALIZEDLANGUAGENAME  := 0x0000006f   ;  // Language Display Name for a language, eg "German" in UI language
        }
        this.LOCALE_SENGLISHLANGUAGENAME        := 0x00001001   ;  // English name of language, eg "German"
        this.LOCALE_SNATIVELANGUAGENAME         := 0x00000004   ;  // native name of language, eg "Deutsch"

        this.LOCALE_SLOCALIZEDCOUNTRYNAME       := 0x00000006   ;  // localized name of country/region, eg "Germany" in UI language
        this.LOCALE_SENGLISHCOUNTRYNAME         := 0x00001002   ;  // English name of country/region, eg "Germany"
        this.LOCALE_SNATIVECOUNTRYNAME          := 0x00000008   ;  // native name of country/region, eg "Deutschland"

        ;  // Additional LCTypes
        this.LOCALE_IDIALINGCODE                := 0x00000005   ;  // country/region dialing code, example: en-US and en-CA return 1.

        this.LOCALE_SLIST                       := 0x0000000C   ;  // list item separator, eg "," for "1,2,3,4"
        this.LOCALE_IMEASURE                    := 0x0000000D   ;  // 0 = metric, 1 = US measurement system

        this.LOCALE_SDECIMAL                    := 0x0000000E   ;  // decimal separator, eg "." for 1,234.00
        this.LOCALE_STHOUSAND                   := 0x0000000F   ;  // thousand separator, eg "," for 1,234.00
        this.LOCALE_SGROUPING                   := 0x00000010   ;  // digit grouping, eg "3;0" for 1,000,000
        this.LOCALE_IDIGITS                     := 0x00000011   ;  // number of fractional digits eg 2 for 1.00
        this.LOCALE_ILZERO                      := 0x00000012   ;  // leading zeros for decimal, 0 for .97, 1 for 0.97
        this.LOCALE_INEGNUMBER                  := 0x00001010   ;  // negative number mode, 0-4, see documentation
        this.LOCALE_SNATIVEDIGITS               := 0x00000013   ;  // native digits for 0-9, eg "0123456789"

        this.LOCALE_SCURRENCY                   := 0x00000014   ;  // local monetary symbol, eg "$"
        this.LOCALE_SINTLSYMBOL                 := 0x00000015   ;  // intl monetary symbol, eg "USD"
        this.LOCALE_SMONDECIMALSEP              := 0x00000016   ;  // monetary decimal separator, eg "." for $1,234.00
        this.LOCALE_SMONTHOUSANDSEP             := 0x00000017   ;  // monetary thousand separator, eg "," for $1,234.00
        this.LOCALE_SMONGROUPING                := 0x00000018   ;  // monetary grouping, eg "3;0" for $1,000,000.00
        this.LOCALE_ICURRDIGITS                 := 0x00000019   ;  // # local monetary digits, eg 2 for $1.00
        this.LOCALE_ICURRENCY                   := 0x0000001B   ;  // positive currency mode, 0-3, see documentation
        this.LOCALE_INEGCURR                    := 0x0000001C   ;  // negative currency mode, 0-15, see documentation

        this.LOCALE_SSHORTDATE                  := 0x0000001F   ;  // short date format string, eg "MM/dd/yyyy"
        this.LOCALE_SLONGDATE                   := 0x00000020   ;  // long date format string, eg "dddd, MMMM dd, yyyy"
        this.LOCALE_STIMEFORMAT                 := 0x00001003   ;  // time format string, eg "HH:mm:ss"
        this.LOCALE_SAM                         := 0x00000028   ;  // AM designator, eg "AM"
        this.LOCALE_SPM                         := 0x00000029   ;  // PM designator, eg "PM"

        this.LOCALE_ICALENDARTYPE               := 0x00001009   ;  // type of calendar specifier, eg CAL_GREGORIAN
        this.LOCALE_IOPTIONALCALENDAR           := 0x0000100B   ;  // additional calendar types specifier, eg CAL_GREGORIAN_US
        this.LOCALE_IFIRSTDAYOFWEEK             := 0x0000100C   ;  // first day of week specifier, 0-6, 0=Monday, 6=Sunday
        this.LOCALE_IFIRSTWEEKOFYEAR            := 0x0000100D   ;  // first week of year specifier, 0-2, see documentation

        this.LOCALE_SDAYNAME1                   := 0x0000002A   ;  // long name for Monday
        this.LOCALE_SDAYNAME2                   := 0x0000002B   ;  // long name for Tuesday
        this.LOCALE_SDAYNAME3                   := 0x0000002C   ;  // long name for Wednesday
        this.LOCALE_SDAYNAME4                   := 0x0000002D   ;  // long name for Thursday
        this.LOCALE_SDAYNAME5                   := 0x0000002E   ;  // long name for Friday
        this.LOCALE_SDAYNAME6                   := 0x0000002F   ;  // long name for Saturday
        this.LOCALE_SDAYNAME7                   := 0x00000030   ;  // long name for Sunday
        this.LOCALE_SABBREVDAYNAME1             := 0x00000031   ;  // abbreviated name for Monday
        this.LOCALE_SABBREVDAYNAME2             := 0x00000032   ;  // abbreviated name for Tuesday
        this.LOCALE_SABBREVDAYNAME3             := 0x00000033   ;  // abbreviated name for Wednesday
        this.LOCALE_SABBREVDAYNAME4             := 0x00000034   ;  // abbreviated name for Thursday
        this.LOCALE_SABBREVDAYNAME5             := 0x00000035   ;  // abbreviated name for Friday
        this.LOCALE_SABBREVDAYNAME6             := 0x00000036   ;  // abbreviated name for Saturday
        this.LOCALE_SABBREVDAYNAME7             := 0x00000037   ;  // abbreviated name for Sunday
        this.LOCALE_SMONTHNAME1                 := 0x00000038   ;  // long name for January
        this.LOCALE_SMONTHNAME2                 := 0x00000039   ;  // long name for February
        this.LOCALE_SMONTHNAME3                 := 0x0000003A   ;  // long name for March
        this.LOCALE_SMONTHNAME4                 := 0x0000003B   ;  // long name for April
        this.LOCALE_SMONTHNAME5                 := 0x0000003C   ;  // long name for May
        this.LOCALE_SMONTHNAME6                 := 0x0000003D   ;  // long name for June
        this.LOCALE_SMONTHNAME7                 := 0x0000003E   ;  // long name for July
        this.LOCALE_SMONTHNAME8                 := 0x0000003F   ;  // long name for August
        this.LOCALE_SMONTHNAME9                 := 0x00000040   ;  // long name for September
        this.LOCALE_SMONTHNAME10                := 0x00000041   ;  // long name for October
        this.LOCALE_SMONTHNAME11                := 0x00000042   ;  // long name for November
        this.LOCALE_SMONTHNAME12                := 0x00000043   ;  // long name for December
        this.LOCALE_SMONTHNAME13                := 0x0000100E   ;  // long name for 13th month (if exists)
        this.LOCALE_SABBREVMONTHNAME1           := 0x00000044   ;  // abbreviated name for January
        this.LOCALE_SABBREVMONTHNAME2           := 0x00000045   ;  // abbreviated name for February
        this.LOCALE_SABBREVMONTHNAME3           := 0x00000046   ;  // abbreviated name for March
        this.LOCALE_SABBREVMONTHNAME4           := 0x00000047   ;  // abbreviated name for April
        this.LOCALE_SABBREVMONTHNAME5           := 0x00000048   ;  // abbreviated name for May
        this.LOCALE_SABBREVMONTHNAME6           := 0x00000049   ;  // abbreviated name for June
        this.LOCALE_SABBREVMONTHNAME7           := 0x0000004A   ;  // abbreviated name for July
        this.LOCALE_SABBREVMONTHNAME8           := 0x0000004B   ;  // abbreviated name for August
        this.LOCALE_SABBREVMONTHNAME9           := 0x0000004C   ;  // abbreviated name for September
        this.LOCALE_SABBREVMONTHNAME10          := 0x0000004D   ;  // abbreviated name for October
        this.LOCALE_SABBREVMONTHNAME11          := 0x0000004E   ;  // abbreviated name for November
        this.LOCALE_SABBREVMONTHNAME12          := 0x0000004F   ;  // abbreviated name for December
        this.LOCALE_SABBREVMONTHNAME13          := 0x0000100F   ;  // abbreviated name for 13th month (if exists)

        this.LOCALE_SPOSITIVESIGN               := 0x00000050   ;  // positive sign, eg ""
        this.LOCALE_SNEGATIVESIGN               := 0x00000051   ;  // negative sign, eg "-"
        this.LOCALE_IPOSSIGNPOSN                := 0x00000052   ;  // positive sign position (derived from INEGCURR)
        this.LOCALE_INEGSIGNPOSN                := 0x00000053   ;  // negative sign position (derived from INEGCURR)
        this.LOCALE_IPOSSYMPRECEDES             := 0x00000054   ;  // mon sym precedes pos amt (derived from ICURRENCY)
        this.LOCALE_IPOSSEPBYSPACE              := 0x00000055   ;  // mon sym sep by space from pos amt (derived from ICURRENCY)
        this.LOCALE_INEGSYMPRECEDES             := 0x00000056   ;  // mon sym precedes neg amt (derived from INEGCURR)
        this.LOCALE_INEGSEPBYSPACE              := 0x00000057   ;  // mon sym sep by space from neg amt (derived from INEGCURR)

        if (OSVersion.WINVER >= 0x0400)    {
            this.LOCALE_FONTSIGNATURE           := 0x00000058   ;  // font signature
            this.LOCALE_SISO639LANGNAME         := 0x00000059   ;  // ISO abbreviated language name, eg "en"
            this.LOCALE_SISO3166CTRYNAME        := 0x0000005A   ;  // ISO abbreviated country/region name, eg "US"
        }

        if (OSVersion.WINVER >= 0x0500)    {
            this.LOCALE_IPAPERSIZE              := 0x0000100A   ;  // 1 = letter, 5 = legal, 8 = a3, 9 = a4
            this.LOCALE_SENGCURRNAME            := 0x00001007   ;  // english name of currency, eg "Euro"
            this.LOCALE_SNATIVECURRNAME         := 0x00001008   ;  // native name of currency, eg "euro"
            this.LOCALE_SYEARMONTH              := 0x00001006   ;  // year month format string, eg "MM/yyyy"
            this.LOCALE_SSORTNAME               := 0x00001013   ;  // sort name, usually "", eg "Dictionary" in UI Language
            this.LOCALE_IDIGITSUBSTITUTION      := 0x00001014   ;  // 0 = context, 1 = none, 2 = national

        }

        if (OSVersion.WINVER >= 0x0600)    {
            this.LOCALE_SNAME                   := 0x0000005c   ;  // locale name (ie: en-us)
            this.LOCALE_SDURATION               := 0x0000005d   ;  // time duration format, eg "hh:mm:ss"
            this.LOCALE_SSHORTESTDAYNAME1       := 0x00000060   ;  // Shortest day name for Monday
            this.LOCALE_SSHORTESTDAYNAME2       := 0x00000061   ;  // Shortest day name for Tuesday
            this.LOCALE_SSHORTESTDAYNAME3       := 0x00000062   ;  // Shortest day name for Wednesday
            this.LOCALE_SSHORTESTDAYNAME4       := 0x00000063   ;  // Shortest day name for Thursday
            this.LOCALE_SSHORTESTDAYNAME5       := 0x00000064   ;  // Shortest day name for Friday
            this.LOCALE_SSHORTESTDAYNAME6       := 0x00000065   ;  // Shortest day name for Saturday
            this.LOCALE_SSHORTESTDAYNAME7       := 0x00000066   ;  // Shortest day name for Sunday
            this.LOCALE_SISO639LANGNAME2        := 0x00000067   ;  // 3 character ISO abbreviated language name, eg "eng"
            this.LOCALE_SISO3166CTRYNAME2       := 0x00000068   ;  // 3 character ISO country/region name, eg "USA"
            this.LOCALE_SNAN                    := 0x00000069   ;  // Not a Number, eg "NaN"
            this.LOCALE_SPOSINFINITY            := 0x0000006a   ;  // + Infinity, eg "infinity"
            this.LOCALE_SNEGINFINITY            := 0x0000006b   ;  // - Infinity, eg "-infinity"
            this.LOCALE_SSCRIPTS                := 0x0000006c   ;  // Typical scripts in the locale: ; delimited script codes, eg "Latn;"
            this.LOCALE_SPARENT                 := 0x0000006d   ;  // Fallback name for resources, eg "en" for "en-US"
            this.LOCALE_SCONSOLEFALLBACKNAME    := 0x0000006e   ;  // Fallback name for within the console for Unicode Only locales, eg "en" for bn-IN
        }

        if (OSVersion.IsWindows7OrGreater())    {
            this.LOCALE_IREADINGLAYOUT          := 0x00000070   ;  // Returns one of the following 4 reading layout values:
                                                                ;  // 0 - Left to right (eg en-US)
                                                                ;  // 1 - Right to left (eg arabic locales)
                                                                ;  // 2 - Vertical top to bottom with columns to the left and also left to right (ja-JP locales)
                                                                ;  // 3 - Vertical top to bottom with columns proceeding to the right
            this.LOCALE_INEUTRAL                := 0x00000071   ;  // Returns 0 for specific cultures, 1 for neutral cultures.
            this.LOCALE_INEGATIVEPERCENT        := 0x00000074   ;  // Returns 0-11 for the negative percent format
            this.LOCALE_IPOSITIVEPERCENT        := 0x00000075   ;  // Returns 0-3 for the positive percent formatIPOSITIVEPERCENT
            this.LOCALE_SPERCENT                := 0x00000076   ;  // Returns the percent symbol
            this.LOCALE_SPERMILLE               := 0x00000077   ;  // Returns the permille (U+2030) symbol
            this.LOCALE_SMONTHDAY               := 0x00000078   ;  // Returns the preferred month/day format
            this.LOCALE_SSHORTTIME              := 0x00000079   ;  // Returns the preferred short time format (ie: no seconds, just h:mm)
            this.LOCALE_SOPENTYPELANGUAGETAG    := 0x0000007a   ;  // Open type language tag, eg: "latn" or "dflt"
            this.LOCALE_SSORTLOCALE             := 0x0000007b   ;  // Name of locale to use for sorting/collation/casing behavior.
        }

        if (OSVersion.IsWindows8OrGreater())    {
            this.LOCALE_SRELATIVELONGDATE       := 0x0000007c   ;  // Long date without year, day of week, month, date, eg: for lock screen
        }
        if (OSVersion.IsWindows8Point1OrGreater())    {
            this.LOCALE_ICONSTRUCTEDLOCALE      := 0x0000007d   ;  // Flags if this locale is constructed.  Avoid using.
        }

        if (OSVersion.IsWindows10OrGreater())    {
            this.LOCALE_SSHORTESTAM             := 0x0000007e   ;  // Shortest AM designator, eg "A"
            this.LOCALE_SSHORTESTPM             := 0x0000007f   ;  // Shortest PM designator, eg "P"
        }


        if (OSVersion.BuildNumber >= 19402)    { ;  #if (NTDDI_VERSION >= NTDDI_WIN10_MN)
            this.LOCALE_IUSEUTF8LEGACYACP       := 0x00000666   ;  // default ansi code page (use of Unicode is recommended instead)
            this.LOCALE_IUSEUTF8LEGACYOEMCP     := 0x00000999   ;  // default oem code page (use of Unicode is recommended instead)
        }

        ;  //
        ;  // DEPRECATED LCTYPEs
        ;  //

        ;  // DEPRECATED LCTYPEs for Code Pages
        ;  // Applications are strongly encouraged to Use Unicode, such as UTF-16 (WCHAR type)
        ;  // or the CP_UTF8 Code Page.  Legacy encodings are unable to represent the full
        ;  // set of scripts/language and characters (& emoji!) available on modern computers.
        ;  // Use of legacy code pages (encodings) is a leading cause of data loss and corruption.
        this.LOCALE_IDEFAULTCODEPAGE            := 0x0000000B   ;  // default oem code page for locale (user may configure as UTF-8, use of Unicode is recommended instead)
        this.LOCALE_IDEFAULTANSICODEPAGE        := 0x00001004   ;  // default ansi code page for locale (user may configure as UTF-8, use of Unicode is recommended instead)
        this.LOCALE_IDEFAULTMACCODEPAGE         := 0x00001011   ;  // default mac code page for locale (user may configure as UTF-8, use of Unicode is recommended instead)
        if (OSVersion.WINVER >= 0x0500)    {
            this.LOCALE_IDEFAULTEBCDICCODEPAGE  := 0x00001012   ;  // default ebcdic code page for a locale (use of Unicode is recommended instead)
        }

        ;  // LCTYPEs using out-of-date concepts
        this.LOCALE_ILANGUAGE                   := 0x00000001   ;  // DEPRECATED language id (LCID), LOCALE_SNAME preferred
        this.LOCALE_SABBREVLANGNAME             := 0x00000003   ;  // DEPRECATED arbitrary abbreviated language name, LOCALE_SISO639LANGNAME instead.
        this.LOCALE_SABBREVCTRYNAME             := 0x00000007   ;  // DEPRECATED arbitrary abbreviated country/region name, LOCALE_SISO3166CTRYNAME instead.
        this.LOCALE_IGEOID                      := 0x0000005B   ;  // DEPRECATED geographical location id, use LOCALE_SISO3166CTRYNAME instead.
        this.LOCALE_IDEFAULTLANGUAGE            := 0x00000009   ;  // DEPRECATED default language id, deprecated
        this.LOCALE_IDEFAULTCOUNTRY             := 0x0000000A   ;  // DEPRECATED default country/region code, deprecated
        this.LOCALE_IINTLCURRDIGITS             := 0x0000001A   ;  // DEPRECATED, use LOCALE_ICURRDIGITS # intl monetary digits, eg 2 for $1.00

        ;  // Derived legacy date & time values for compatibility only.
        ;  // Please use the appropriate date or time pattern instead.
        ;  // These can be misleading, for example a locale configured as 12h24m52s could have a time separator of "h".
        this.LOCALE_SDATE                       := 0x0000001D   ;  // DEPRECATED date separator (derived from LOCALE_SSHORTDATE, use that instead)
        this.LOCALE_STIME                       := 0x0000001E   ;  // DEPRECATED time separator (derived from LOCALE_STIMEFORMAT, use that instead)
        this.LOCALE_IDATE                       := 0x00000021   ;  // DEPRECATED short date format ordering (derived from LOCALE_SSHORTDATE, use that instead)
        this.LOCALE_ILDATE                      := 0x00000022   ;  // DEPRECATED long date format ordering (derived from LOCALE_SLONGDATE, use that instead)
        this.LOCALE_ITIME                       := 0x00000023   ;  // DEPRECATED time format specifier (derived from LOCALE_STIMEFORMAT, use that instead)
        this.LOCALE_ITIMEMARKPOSN               := 0x00001005   ;  // DEPRECATED time marker position (derived from LOCALE_STIMEFORMAT, use that instead)
        this.LOCALE_ICENTURY                    := 0x00000024   ;  // DEPRECATED century format specifier (short date, LOCALE_SSHORTDATE is preferred)
        this.LOCALE_ITLZERO                     := 0x00000025   ;  // DEPRECATED leading zeros in time field (derived from LOCALE_STIMEFORMAT, use that instead)
        this.LOCALE_IDAYLZERO                   := 0x00000026   ;  // DEPRECATED leading zeros in day field (short date, LOCALE_SSHORTDATE is preferred)
        this.LOCALE_IMONLZERO                   := 0x00000027   ;  // DEPRECATED leading zeros in month field (short date, LOCALE_SSHORTDATE is preferred)

        if (OSVersion.WINVER >= 0x0600)    {
            this.LOCALE_SKEYBOARDSTOINSTALL     := 0x0000005e   ;  // Used internally, see GetKeyboardLayoutName() function
        }

        ;  // LCTYPEs which have been renamed to enable more understandable source code.
        this.LOCALE_SLANGUAGE                   := this.LOCALE_SLOCALIZEDDISPLAYNAME   ;  // DEPRECATED as new name is more readable.
        if (OSVersion.IsWindowsVistaOrGreater())    {
            this.LOCALE_SLANGDISPLAYNAME        := this.LOCALE_SLOCALIZEDLANGUAGENAME  ;  // DEPRECATED as new name is more readable.
        }
        this.LOCALE_SENGLANGUAGE                := this.LOCALE_SENGLISHLANGUAGENAME    ;  // DEPRECATED as new name is more readable.
        this.LOCALE_SNATIVELANGNAME             := this.LOCALE_SNATIVELANGUAGENAME     ;  // DEPRECATED as new name is more readable.
        this.LOCALE_SCOUNTRY                    := this.LOCALE_SLOCALIZEDCOUNTRYNAME   ;  // DEPRECATED as new name is more readable.
        this.LOCALE_SENGCOUNTRY                 := this.LOCALE_SENGLISHCOUNTRYNAME     ;  // DEPRECATED as new name is more readable.
        this.LOCALE_SNATIVECTRYNAME             := this.LOCALE_SNATIVECOUNTRYNAME      ;  // DEPRECATED as new name is more readable.
        ;  // DEPRECATED: Use LOCALE_SISO3166CTRYNAME to query for a region identifier, LOCALE_ICOUNTRY is not a region identifier.
        this.LOCALE_ICOUNTRY                    := this.LOCALE_IDIALINGCODE   ;  // Deprecated synonym for LOCALE_IDIALINGCODE
        this.LOCALE_S1159                       := this.LOCALE_SAM   ;  // DEPRECATED: Please use LOCALE_SAM, which is more readable.
        this.LOCALE_S2359                       := this.LOCALE_SPM   ;  // DEPRECATED: Please use LOCALE_SPM, which is more readable.
        
        
        this.LOCALE_NAME_USER_DEFAULT           := 0
        this.LOCALE_NAME_INVARIANT              := ""
        this.LOCALE_NAME_SYSTEM_DEFAULT         := "!x-sys-default-locale"


        this.LOCALE_NAME_MAX_LENGTH             := 85
    }
}