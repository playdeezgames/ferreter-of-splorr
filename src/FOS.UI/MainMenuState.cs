using TGGD.UI;

namespace FOS.UI
{
    internal class MainMenuState() : UIState(GenerateLines(), GenerateChoices())
    {
        private static IEnumerable<IDialogChoice> GenerateChoices()
        {
            return [new DialogChoice("Embark", "Embark!")];
        }

        private static IEnumerable<IDialogLine> GenerateLines()
        {
            return [new DialogLine("", "Main Menu:")];
        }

        public override IUIState HandleInput(string input)
        {
            return this;
        }
    }
}
