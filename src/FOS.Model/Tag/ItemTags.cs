namespace FOS.Model
{
    internal static class ItemTags
    {
        private static string GetName(string tagName) => $"{nameof(ItemTags)}.{tagName}";
        internal static readonly string IS_RAT_TAIL = GetName(nameof(IS_RAT_TAIL));
    }
}
