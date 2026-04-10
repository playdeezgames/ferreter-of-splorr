namespace FOS.Business
{
    internal static class ItemTypes
    {
        internal static readonly string DAGGER = nameof(DAGGER);
        internal static readonly IReadOnlyDictionary<string, IItemType> All =
            new List<IItemType>
            {
                new DaggerItemType()
            }.ToDictionary(x => x.Identifier, x => x);
    }
}
