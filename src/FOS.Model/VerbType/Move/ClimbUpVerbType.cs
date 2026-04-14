using FOS.Business;

namespace FOS.Model
{
    internal class ClimbUpVerbType() : MoveVerbType(Verbs.CLIMB_UP), IVerbType
    {
        public override string GetDirection(ICharacter character)
        {
            return Directions.UP;
        }

        public override string GetText(ICharacter character)
        {
            return "Climb Up";
        }

        protected override string GetSuccessMessage(ICharacter character, IRoute route)
        {
            return $"You climb up {route.Name}.";
        }
    }
}