using FOS.Business;

namespace FOS.Model
{
    internal class ExitLocationVerbType() : MoveVerbType(Verbs.EXIT_LOCATION), IVerbType
    {
        public override string GetDirection(ICharacter character)
        {
            return Directions.OUT;
        }

        public override string GetText(ICharacter character)
        {
            return "Exit";
        }

        protected override string GetFailureMessage(ICharacter character, IRoute route)
        {
            return $"You cannot exit thru {route.Name}.";
        }

        protected override string GetSuccessMessage(ICharacter character, IRoute route)
        {
            return $"You exit thru {route.Name}.";
        }
    }
}