using FOS.Business;

namespace FOS.Model
{
    internal class MoveAheadVerbType() : MoveVerbType(VerbTypes.MOVE_AHEAD), IVerbType
    {
        public override string GetDirection(ICharacter character)
        {
            return character.Direction;
        }

        public override string GetText(ICharacter character)
        {
            return "Move Ahead";
        }

        protected override string GetFailureMessage(ICharacter character, IRoute route)
        {
            return $"{character.Name} cannot move thru {route.Name}.";
        }

        protected override string GetSuccessMessage(ICharacter character, IRoute route)
        {
            return $"{character.Name} moves ahead thru {route.Name}.";
        }
    }
}