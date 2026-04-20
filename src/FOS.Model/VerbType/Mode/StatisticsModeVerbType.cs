using FOS.Business;

namespace FOS.Model
{
    internal class StatisticsModeVerbType : IVerbType
    {
        public string Identifier => ModeVerbs.STATISTICS_MODE;

        public bool CanPerform(ICharacter character, params string[] parameters)
        {
            return !character.HasMode();
        }

        public string GetText(ICharacter character)
        {
            return "Statistics...";
        }

        public void Perform(ICharacter character, params string[] parameters)
        {
            character.SetMode(Modes.STATISTICS);
        }
    }
}