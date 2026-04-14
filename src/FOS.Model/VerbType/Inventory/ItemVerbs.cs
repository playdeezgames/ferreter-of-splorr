namespace FOS.Model
{
    internal static class ItemVerbs
    {
        internal readonly static string BLUR_ITEM = nameof(BLUR_ITEM);
        internal readonly static string DROP_ITEM = nameof(DROP_ITEM);
        internal readonly static string TAKE_ITEM = nameof(TAKE_ITEM);
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new DropItemVerbType(),
                new TakeItemVerbType(),
                new BlurItemVerbType()
            ];
    }
}
