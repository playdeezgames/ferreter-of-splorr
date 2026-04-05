using TGGD.UI;

namespace FOS.UI
{
    internal class TitleState : UIState
    {
        public TitleState(): base(GenerateLines(), GenerateChoices())
        {

        }

        private static IEnumerable<IDialogChoice> GenerateChoices()
        {
            return [new DialogChoice("OK","OK")];
        }

        private static IEnumerable<IDialogLine> GenerateLines()
        {
            return [new DialogLine("","Ferreter of SPLORR!")];
        }

        public override IUIState HandleInput(string input)
        {
            return new MainMenuState();
        }
    }
}
