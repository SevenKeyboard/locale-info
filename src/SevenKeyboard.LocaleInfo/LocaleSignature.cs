namespace SevenKeyboard;

public readonly struct LocaleSignature
{
    private static readonly uint[] Zero = new uint[8];
    private readonly uint[]? values;

    internal LocaleSignature(ReadOnlySpan<uint> values)
        => this.values = values.ToArray();

    public ReadOnlySpan<uint> LsUsb => (values ?? Zero).AsSpan(0, 4);
    public ReadOnlySpan<uint> LsCsbDefault => (values ?? Zero).AsSpan(4, 2);
    public ReadOnlySpan<uint> LsCsbSupported => (values ?? Zero).AsSpan(6, 2);
}
