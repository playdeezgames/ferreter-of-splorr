namespace FOS.Model
{
    internal static class ItemVerbs
    {
        private static string GetName(string name) => $"{nameof(ItemVerbs)}.{name}";
        internal readonly static string BLUR_ITEM = GetName(nameof(BLUR_ITEM));
        internal readonly static string DROP_ITEM = GetName(nameof(DROP_ITEM));
        internal readonly static string TAKE_ITEM = GetName(nameof(TAKE_ITEM));
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new DropItemVerbType(),
                new TakeItemVerbType(),
                new BlurItemVerbType()
            ];
    }
}
