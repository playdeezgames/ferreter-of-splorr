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
    }
}
