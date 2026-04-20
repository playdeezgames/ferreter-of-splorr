namespace FOS.Model
{
    internal class LocationVerbs
    {
        private static string GetName(string name) => $"{nameof(LocationVerbs)}.{name}";
        private readonly static string SEARCH = GetName(nameof(SEARCH));
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new VerbType(
                    SEARCH,
                    x=> !x.IsDead() && !x.HasMode() && x.Location.HasTrigger(Triggers.SEARCH),
                    x=> "Search...",
                    x=> x.Location.FireTrigger(Triggers.SEARCH,x))
            ];
    }
}
