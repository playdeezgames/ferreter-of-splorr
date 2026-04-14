using FOS.Business;

namespace FOS.Model
{
    internal class MoveAheadVerbType() : MoveVerbType(Verbs.MOVE_AHEAD), IVerbType
    {
        public override string GetDirection(ICharacter character)
        {
            return character.Direction;
        }

        public override string GetText(ICharacter character)
        {
            return "Move Ahead";
        }

        protected override string GetSuccessMessage(ICharacter character, IRoute route)
        {
            return $"{character.Name} moves ahead thru {route.Name}.";
        }
    }
}