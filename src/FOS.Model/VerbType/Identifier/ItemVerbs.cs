namespace FOS.Model
{
    internal static class ItemVerbs
    {
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new DropItemVerbType(),
                new TakeItemVerbType(),
                new BlurItemVerbType()
            ];
    }
}
