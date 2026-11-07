//==============================================================
// LocaleInfo — GetLocaleInfoEx wrapper + LOCALE_* constants (WinNls.h)
//
// GitHub: https://github.com/SevenKeyboard/locale-info
// Author: SevenKeyboard Ltd. (2026)
// License: MIT License
//
// Documentation / References:
//   GetLocaleInfoEx function (winnls.h)
//     https://learn.microsoft.com/en-us/windows/win32/api/winnls/nf-winnls-getlocaleinfoex
//==============================================================

using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.System32)]

namespace SevenKeyboard;

public static partial class LocaleInfo
{
    public static T GetEx<T>(string? localeName = "NAME_USER_DEFAULT", string? infoType = "")
        => GetEx<T>(localeName, infoType, out _);

    public static unsafe T GetEx<T>(string? localeName, string? infoType, out int ret)
    {
        ret = 0;
        if (typeof(T) != typeof(string) && typeof(T) != typeof(uint) && typeof(T) != typeof(LocaleSignature))
            throw new ArgumentException("T must be string, uint, or LocaleSignature.");

        T empty = typeof(T) == typeof(string) ? (T)(object)string.Empty : default!;
        if (string.IsNullOrEmpty(infoType) || !InfoTypes.TryGetValue(infoType, out uint lcType))
            return empty;

        // AHK's object keys, '=' comparison, and default switch comparisons ignore case.
        bool number = infoType[0] is 'I' or 'i';
        bool signature = infoType.Equals("FONTSIGNATURE", StringComparison.OrdinalIgnoreCase);
        if (number ? typeof(T) != typeof(uint)
            : signature ? typeof(T) != typeof(LocaleSignature) : typeof(T) != typeof(string))
            throw new ArgumentException("T does not match the requested infoType.", nameof(infoType));

        if (localeName is not null)
        {
            if (localeName.Equals("NAME_USER_DEFAULT", StringComparison.OrdinalIgnoreCase) || IsNumericZero(localeName))
                localeName = null;
            else if (localeName.Equals("NAME_INVARIANT", StringComparison.OrdinalIgnoreCase))
                localeName = LOCALE_NAME_INVARIANT;
            else if (localeName.Equals("NAME_SYSTEM_DEFAULT", StringComparison.OrdinalIgnoreCase))
                localeName = LOCALE_NAME_SYSTEM_DEFAULT;
        }

        if (number)
        {
            uint value = 0;
            ret = NativeGetLocaleInfoEx(localeName, lcType | LOCALE_RETURN_NUMBER, &value, 2);
            return ret != 0 ? (T)(object)value : empty;
        }

        if (signature)
        {
            Span<uint> values = stackalloc uint[8];
            values.Clear();
            fixed (uint* buffer = values)
                ret = NativeGetLocaleInfoEx(localeName, LOCALE_FONTSIGNATURE, buffer, 16);
            return ret != 0 ? (T)(object)new LocaleSignature(values) : empty;
        }

        int cchData = NativeGetLocaleInfoEx(localeName, lcType, null, 0);
        if (cchData == 0)
            return empty;

        char[] data = new char[cchData];
        fixed (char* buffer = data)
            ret = NativeGetLocaleInfoEx(localeName, lcType, buffer, cchData);
        if (ret == 0)
            return empty;

        int terminator = Array.IndexOf(data, '\0');
        return (T)(object)new string(data, 0, terminator < 0 ? cchData : terminator);
    }

    // Preserve AHK's localeName == 0 fallback, including signed/hex/float zero,
    // space/tab padding, and its repeated-exponent grammar. Empty is invariant.
    private static bool IsNumericZero(string value)
    {
        Match match = NumericZeroPattern().Match(value);
        if (!match.Success)
            return false;
        Group floating = match.Groups["floating"];
        return !floating.Success
            || (double.TryParse(floating.ValueSpan, NumberStyles.Float, CultureInfo.InvariantCulture, out double number)
                && number == 0);
    }

    [GeneratedRegex(@"\A[ \t]*[+-]?(?:0[xX]0+|0+|(?<floating>(?:[0-9]+\.[0-9]*|\.[0-9]+)(?:[eE][+-]?[0-9]+)?)(?:[eE][+-]?[0-9]+)*)[ \t]*\z")]
    private static partial Regex NumericZeroPattern();

    [LibraryImport("kernel32.dll", EntryPoint = "GetLocaleInfoEx", StringMarshalling = StringMarshalling.Utf16)]
    private static unsafe partial int NativeGetLocaleInfoEx(string? localeName, uint lcType, void* data, int cchData);
}
