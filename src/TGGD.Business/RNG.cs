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
        public static int FromRange(int minimum, int maximum)
        {
            return FromEnumerable(Enumerable.Range(minimum, maximum - minimum + 1));
        }
        public static bool GenerateBool(int falseWeight, int trueWeight)
        {
            return FromGenerator(new Dictionary<bool, int>()
            {
                [false] = falseWeight,
                [true] = trueWeight
            });
        }
        public static TGenerated FromGenerator<TGenerated>(IReadOnlyDictionary<TGenerated, int> generator)
        {
            var total = generator.Values.Sum();
            var generated = RNG.FromRange(0, total - 1);
            foreach (var entry in generator)
            {
                generated -= entry.Value;
                if (generated < 0)
                {
                    return entry.Key;
                }
            }
            throw new NotImplementedException("This should not happen!");
        }
    }
}
