using FOS.Business;

namespace FOS.Model
{
    internal class ClimbUpVerbType() :
        MoveVerbType(
            MoveVerbs.CLIMB_UP,
            x => "Climb Up",
            x => Directions.UP), IVerbType
    {
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