using FOS.Business;

namespace FOS.Model
{
    internal class UsePortalVerbType() : MoveVerbType(MoveVerbs.USE_PORTAL), IVerbType
    {
        protected override string GetDirection(ICharacter character)
        {
            return Directions.PORTAL;
        }

        public override string GetText(ICharacter character)
        {
            return "Use Portal";
        }

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