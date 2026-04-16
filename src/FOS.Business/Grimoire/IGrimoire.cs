namespace FOS.Business
{
    public interface IGrimoire
    {
        bool DoesRouteAllowCharacter(IRoute route, ICharacter character);//TODO: entirely within model
        void FireTrigger(ITrigger trigger, ICharacter character);
        bool InterceptCharacterItem(ICharacter character, IItem item);
    }
}
