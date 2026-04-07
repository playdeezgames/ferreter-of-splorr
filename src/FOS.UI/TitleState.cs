using FOS.Business;
using TGGD.Business;
using TGGD.UI;

namespace FOS.UI
{
    internal class TitleState : UIState
    {
        public TitleState(IWorld world): base(world, GenerateLines(), GenerateChoices())
        {

        }

        private static IEnumerable<IDialogChoice> GenerateChoices()
        {
            return [new DialogChoice(Commands.EMBARK,"OK")];
        }

        private static IEnumerable<IDialogLine> GenerateLines()
        {
            return [new DialogLine(Moods.TITLE, "Ferreter of SPLORR!")];
        }

        public override IUIState HandleCommand(string command)
        {
            return new MainMenuState(_world);
        }
    }
}
