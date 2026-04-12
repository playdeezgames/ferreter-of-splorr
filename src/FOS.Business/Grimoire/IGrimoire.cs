namespace FOS.Business
{
    public interface IGrimoire
    {
        void AddMessage(ICharacter character, string mood, string text);
        void FireTrigger(ITrigger trigger, ICharacter character);
        string GetDirectionName(string directionId);
    }
}
