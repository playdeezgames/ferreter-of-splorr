namespace FOS.Business
{
    internal static class StatisticTypes
    {
        internal static readonly string COLUMN = nameof(COLUMN);
        internal static readonly string ROW = nameof(ROW);
        internal static readonly IReadOnlyDictionary<string, IStatisticType> All =
            new List<IStatisticType>
            {

            }.ToDictionary(x => x.Identifier, x => x);
    }
}
