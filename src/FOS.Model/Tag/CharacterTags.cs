namespace FOS.Model
{
    internal static class CharacterTags
    {
        private static string GetName(string name) => $"{nameof(CharacterTags)}.{name}";
        internal static readonly string N00B = GetName(nameof(N00B));
        internal static readonly string GORACHAN = GetName(nameof(GORACHAN));
    }
}
