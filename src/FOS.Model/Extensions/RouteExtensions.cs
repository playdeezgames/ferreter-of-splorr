using FOS.Business;

namespace FOS.Model
{
    internal static class RouteExtensions
    {
        private record RouteBlocker(Func<IRoute, ICharacter, bool> Condition, Action<ICharacter> Operation);

        private static readonly IReadOnlyList<RouteBlocker> routeBlockers =
            [
                new RouteBlocker((r,c)=>r.HasTag(QuestTags.INN_RATS_ACCEPTED) && !c.HasTag(QuestTags.INN_RATS_ACCEPTED) , c=>{ })
            ];

        internal static bool Allows(this IRoute route, ICharacter character)
        {
            var blocker = routeBlockers.FirstOrDefault(x => x.Condition(route, character));
            blocker?.Operation(character);
            return blocker == null;
        }
    }
}
