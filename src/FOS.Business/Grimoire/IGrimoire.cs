namespace FOS.Business
{
    public interface IGrimoire
    {
        void AddMessage(ICharacter character, string mood, string text);
        bool DoesRouteAllowCharacter(IRoute route, ICharacter character);
        void FireTrigger(ITrigger trigger, ICharacter character);
        bool InterceptCharacterItem(ICharacter character, IItem item);
    }
}
