namespace FOS.Model.VerbType
{
    internal static class MoveVerbs
    {
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new MoveAheadVerbType(),
                new ClimbUpVerbType(),
                new ClimbDownVerbType(),
                new EnterLocationVerbType(),
                new ExitLocationVerbType(),
                new UsePortalVerbType()
            ];
    }
}
