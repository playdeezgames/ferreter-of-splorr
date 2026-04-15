using FOS.Business;

namespace FOS.Model
{
    public class Grimoire : IGrimoire
    {
        public void AddMessage(ICharacter character, string mood, string text)
        {
            if (character.HasTag(CharacterTags.N00B))
            {
                character.World.AddMessage(mood, text);
            }
        }

        public void FireTrigger(ITrigger trigger, ICharacter character)
        {
            TriggerTypes.All[trigger.TriggerType].Fire(trigger, character);
        }

        public string GetDirectionName(string directionId)
        {
            return Directions.All[directionId].Name;
        }

        public string GetNextDirection(string directionId)
        {
            return Directions.All[directionId].Next;
        }

        public string GetOppositeDirection(string directionId)
        {
            return Directions.All[directionId].Opposite;
        }

        public string GetPreviousDirection(string directionId)
        {
            return Directions.All[directionId].Previous;
        }

        private record ItemInterceptor(Func<ICharacter, IItem, bool> Condition, Action<ICharacter, IItem> Operation);

        private static readonly IReadOnlyList<ItemInterceptor> characterItemInterceptors =
            [
                new ItemInterceptor(
                    (c,i)=>c.HasStatistic(StatisticTypes.JOOLS) && i.HasStatistic(StatisticTypes.JOOLS),
                    (c,i)=>
                    {
                        c.ChangeStatistic(StatisticTypes.JOOLS, i.GetStatistic(StatisticTypes.JOOLS));
                    })
            ];

        public bool InterceptCharacterItem(ICharacter character, IItem item)
        {
            var interceptor = characterItemInterceptors.FirstOrDefault(x => x.Condition(character, item));
            interceptor?.Operation(character, item);
            return interceptor != null;
        }

        private record RouteBlocker(Func<IRoute, ICharacter, bool> Condition, Action<ICharacter> Operation);

        private static readonly IReadOnlyList<RouteBlocker> routeBlockers =
            [
            ];

        public bool DoesRouteAllowCharacter(IRoute route, ICharacter character)
        {
            var blocker = routeBlockers.FirstOrDefault(x => x.Condition(route, character));
            blocker?.Operation(character);
            return blocker == null;
        }
    }
}
