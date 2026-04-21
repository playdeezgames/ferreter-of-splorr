using FOS.Business;

namespace FOS.Model
{
    internal class MoveAheadVerbType() : MoveVerbType(MoveVerbs.MOVE_AHEAD, x => "Move Ahead"), IVerbType
    {
        protected override string GetDirection(ICharacter character)
        {
            return character.Direction;
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