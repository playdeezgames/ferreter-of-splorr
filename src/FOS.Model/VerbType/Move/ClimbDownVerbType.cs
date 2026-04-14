using FOS.Business;
using FOS.Model.VerbType;

namespace FOS.Model
{
    internal class ClimbDownVerbType() : MoveVerbType(MoveVerbs.CLIMB_DOWN), IVerbType
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