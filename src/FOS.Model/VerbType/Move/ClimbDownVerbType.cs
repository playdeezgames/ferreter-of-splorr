using FOS.Business;

namespace FOS.Model
{
    internal class ClimbDownVerbType() :
        MoveVerbType(
            MoveVerbs.CLIMB_DOWN,
            x => "Climb Down",
            x => Directions.DOWN), IVerbType
    {

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