using FOS.Business;

namespace FOS.Model
{
    internal class StatisticsModeVerbType : IVerbType
    {
        public string Identifier => Verbs.STATISTICS_MODE;

        public bool CanPerform(ICharacter character)
        {
            return !character.HasMode();
        }

        public string GetText(ICharacter character)
        {
            return "Statistics...";
        }

        public void Perform(ICharacter character)
        {
            character.SetMode(Modes.STATISTICS);
        }
    }
}