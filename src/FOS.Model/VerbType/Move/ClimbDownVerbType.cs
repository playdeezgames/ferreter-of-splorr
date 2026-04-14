using FOS.Business;

namespace FOS.Model
{
    internal class ClimbDownVerbType() : MoveVerbType(Verbs.CLIMB_DOWN), IVerbType
    {
        public override string GetDirection(ICharacter character)
        {
            return Directions.DOWN;
        }

        public override string GetText(ICharacter character)
        {
            return "Climb Down";
        }

        protected override string GetSuccessMessage(ICharacter character, IRoute route)
        {
            return $"You climb down {route.Name}.";
        }
    }
}