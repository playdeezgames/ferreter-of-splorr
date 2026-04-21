using FOS.Business;

namespace FOS.Model
{
    internal class UsePortalVerbType() :
        MoveVerbType(
            MoveVerbs.USE_PORTAL,
            x => "Use Portal",
            x => Directions.PORTAL), IVerbType
    {
        protected override string GetFailureMessage(ICharacter character, IRoute route)
        {
            return $"You cannot use {route.Name}.";
        }

        protected override string GetSuccessMessage(ICharacter character, IRoute route)
        {
            return $"You use {route.Name}.";
        }
    }
}