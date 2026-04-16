using FOS.Business;

namespace FOS.Model
{
    internal static class TriggerExtensions
    {
        internal static void Fire(this ITrigger trigger, ICharacter character)
        {
            if (CanFire(trigger, character))
            {
                TriggerTypes.All[trigger.TriggerType].Fire(trigger, character);
            }
            trigger.NextTrigger?.Fire(character);
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
    }
}
