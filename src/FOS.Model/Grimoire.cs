using FOS.Business;

namespace FOS.Model
{
    public class Grimoire : IGrimoire
    {

        public void FireTrigger(ITrigger trigger, ICharacter character)
        {
            if (CanFire(trigger, character))
            {
                TriggerTypes.All[trigger.TriggerType].Fire(trigger, character);
            }
        }

        private record TriggerBlocker(
            Func<ITrigger, ICharacter, bool> Condition,
            Action<ITrigger, ICharacter> Operation);

        private readonly static IReadOnlyList<TriggerBlocker> triggerBlockers =
            [
                new TriggerBlocker(
                    (t,c)=>t.HasTag(TriggerTags.BLOCK_WHEN_OTHER_CHARACTERS) && c.Location.HasOtherCharacters(c),
                    (t,c)=>
                    {
                        if(t.HasMetadata(Metadatas.BLOCK_TEXT))
                        {
                            c.AddMessage(t.GetMetadata(Metadatas.BLOCK_MOOD), t.GetMetadata(Metadatas.BLOCK_TEXT));
                        }
                    })
            ];

        private static bool CanFire(ITrigger trigger, ICharacter character)
        {
            var blocker = triggerBlockers.FirstOrDefault(x => x.Condition(trigger, character));
            blocker?.Operation(trigger, character);
            return blocker == null;
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
                new RouteBlocker((r,c)=>r.HasTag(QuestTags.INN_RATS_ACCEPTED) && !c.HasTag(QuestTags.INN_RATS_ACCEPTED) , c=>{ })
            ];

        public bool DoesRouteAllowCharacter(IRoute route, ICharacter character)
        {
            var blocker = routeBlockers.FirstOrDefault(x => x.Condition(route, character));
            blocker?.Operation(character);
            return blocker == null;
        }
    }
}
