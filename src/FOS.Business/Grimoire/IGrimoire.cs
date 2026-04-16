namespace FOS.Business
{
    public interface IGrimoire
    {
        void FireTrigger(ITrigger trigger, ICharacter character);
        bool InterceptCharacterItem(ICharacter character, IItem item);
    }
}
