using FOS.Business;

namespace FOS.Model
{
    public class Grimoire : IGrimoire
    {
        public void AddMessage(ICharacter character, string mood, string text)
        {
            if (character.HasTag(Tags.N00B))
            {
                character.World.AddMessage(mood, text);
            }
        }

        public void FireTrigger(ITrigger trigger, ICharacter character)
        {
            TriggerTypes.All[trigger.TriggerType].Fire(trigger, character);
        }
    }
}
