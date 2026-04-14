using FOS.Business;

namespace FOS.Model
{
    internal class ClimbDownVerbType() : MoveVerbType(VerbTypes.CLIMB_DOWN), IVerbType
    {
        public override string GetDirection(ICharacter character)
        {
            return Directions.DOWN;
        }

        public override string GetText(ICharacter character)
        {
            return "Climb Down";
        }

        protected override string GetFailureMessage(ICharacter character, IRoute route)
        {
            return $"You cannot climb down {route.Name}.";
        }

        protected override string GetSuccessMessage(ICharacter character, IRoute route)
        {
            return $"You climb down {route.Name}.";
        }
    }
}