namespace FOS.Model.VerbType
{
    internal static class TurnVerbs
    {
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new TurnLeftVerbType(),
                new TurnRightVerbType(),
                new TurnAroundVerbType()
            ];
    }
}
