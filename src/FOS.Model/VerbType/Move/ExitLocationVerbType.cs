using FOS.Business;

namespace FOS.Model
{
    internal class ExitLocationVerbType() : MoveVerbType(MoveVerbs.EXIT_LOCATION, x => "Exit"), IVerbType
    {
        protected override string GetDirection(ICharacter character)
        {
            return Directions.OUT;
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