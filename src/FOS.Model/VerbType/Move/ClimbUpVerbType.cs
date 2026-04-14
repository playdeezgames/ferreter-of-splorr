using FOS.Business;

namespace FOS.Model
{
    internal class ClimbUpVerbType() : MoveVerbType(VerbTypes.CLIMB_UP), IVerbType
    {
        public override string GetDirection(ICharacter character)
        {
            return Directions.UP;
        }

        public override string GetText(ICharacter character)
        {
            return "Climb Up";
        }

        protected override string GetFailureMessage(ICharacter character, IRoute route)
        {
            return $"You cannot climb up {route.Name}.";
        }

        protected override string GetSuccessMessage(ICharacter character, IRoute route)
        {
            return $"You climb up {route.Name}.";
        }
    }
}