using FOS.Business;

namespace FOS.Model
{
    internal class EnterLocationVerbType() :
        MoveVerbType(
            MoveVerbs.ENTER_LOCATION,
            x => "Enter",
            x => Directions.IN), IVerbType
    {

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