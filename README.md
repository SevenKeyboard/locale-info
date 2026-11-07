# locale-info

GetLocaleInfoEx wrapper and the original LOCALE_* constants for .NET 10 on Windows 10+ (x64/x86). Version 2.0.0 uses typed values and unsigned font-signature fields.

```csharp
using SevenKeyboard;

string language = LocaleInfo.GetEx<string>("ja-JP", "SNATIVELANGUAGENAME", out int ret);
if (ret != 0)
    Console.WriteLine(language);
```

Use `string` for text, `uint` for names beginning with `I`, and `LocaleSignature` for `FONTSIGNATURE` (read-only `LsUsb`, `LsCsbDefault`, `LsCsbSupported` sequences of 4, 2, 2 uints). `ret` is the raw Win32 count: 0 on failure, 2 for numbers, 16 for signatures, or the string buffer count including its terminator. Failure returns `string.Empty`, 0, or the default signature. A successful value may also be empty or zero. Unsupported or mismatched `T` throws `ArgumentException`. The overload without `out` discards the count.

Names are case-insensitive, as in the original AHK defaults. Omitted locale, `null`, `"NAME_USER_DEFAULT"`, and numeric-zero strings select the user default; `""` and `"NAME_INVARIANT"` select invariant; `"NAME_SYSTEM_DEFAULT"` selects the system default. Unknown info types fail. Original OS gates, including build 19402, are retained.

Keep `locale-info/main-cs`, `os-version/main-cs` (2.x, minimum 2.1.0), and `library-build/main-cs` under one parent directory of any name. Override `OSVersionProjectPath` and `LibraryBuildTargetsPath` for another layout; dependencies stay external.

Build: `dotnet build src/SevenKeyboard.LocaleInfo -c Release`.
Smoke: `dotnet run --project tests/SevenKeyboard.LocaleInfo.Smoke -c Release`.
