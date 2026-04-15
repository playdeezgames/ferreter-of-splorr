namespace FOS.Model
{
    internal class TriggerTags
    {
        private static string GetName(string name) => $"{nameof(TriggerTags)}.{name}";
        internal static readonly string BLOCK_WHEN_OTHER_CHARACTERS = GetName(nameof(BLOCK_WHEN_OTHER_CHARACTERS));
    }
}
