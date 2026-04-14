namespace FOS.Model
{
    internal static class GorachanVerbs
    {
        internal static readonly string GORACHAN_INTRODUCTION = nameof(GORACHAN_INTRODUCTION);
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new GorachanIntroductionVerbType()
            ];
    }
}
