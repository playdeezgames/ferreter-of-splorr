using FOS.Business;

namespace FOS.Model
{
    internal class EnterLocationVerbType() : MoveVerbType(MoveVerbs.ENTER_LOCATION, x => "Enter"), IVerbType
    {
        protected override string GetDirection(ICharacter character)
        {
            return Directions.IN;
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