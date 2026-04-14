namespace FOS.Business
{
    public interface IGrimoire
    {
        void AddMessage(ICharacter character, string mood, string text);
        bool DoesRouteAllowCharacter(IRoute route, ICharacter character);
        void FireTrigger(ITrigger trigger, ICharacter character);
        string GetDirectionName(string directionId);
        string GetNextDirection(string directionId);
        string GetOppositeDirection(string directionId);
        string GetPreviousDirection(string directionId);
        bool InterceptCharacterItem(ICharacter character, IItem item);
    }
}
