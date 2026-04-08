namespace TGGD.Business
{
    public static class RNG
    {
        private static readonly Random _random = new();
        public static TGenerated FromList<TGenerated>(List<TGenerated> candidates)
        {
            return candidates[_random.Next(candidates.Count)];
        }
        public static TGenerated FromEnumerable<TGenerated>(IEnumerable<TGenerated> candidates)
        {
            return FromList<TGenerated>([.. candidates]);
        }
    }
}
