using FOS.Business;

namespace FOS.Model
{
    internal class EnterLocationVerbType() : MoveVerbType(Verbs.ENTER_LOCATION), IVerbType
    {
        public override string GetDirection(ICharacter character)
        {
            return Directions.IN;
        }

        public override string GetText(ICharacter character)
        {
            return "Enter";
        }

        protected override string GetFailureMessage(ICharacter character, IRoute route)
        {
            return $"You cannot enter {route.Name}.";
        }

        protected override string GetSuccessMessage(ICharacter character, IRoute route)
        {
            return $"You enter thru {route.Name}.";
        }
    }
}