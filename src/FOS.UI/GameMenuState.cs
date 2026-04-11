using FOS.Business;
using TGGD.Business;
using TGGD.UI;

namespace FOS.UI
{
    internal class GameMenuState(IWorld world) : UIState(GenerateLines(), GenerateChoices())
    {
        public override string Prompt => "Game Menu:";

        private static IEnumerable<IDialogChoice> GenerateChoices()
        {
            return [
                new DialogChoice(Commands.RESUME_GAME, "Resume Game"),
                new DialogChoice(Commands.ABANDON_GAME, "Abandon Game")
            ];
        }

        private static IEnumerable<IDialogLine> GenerateLines()
        {
            return [];
        }

        public override IUIState HandleCommand(string command)
        {
            if (command == Commands.RESUME_GAME)
            {
                return new InPlayState(world);
            }
            else if (command == Commands.ABANDON_GAME)
            {
                return new MainMenuState(world);
            }
            return this;
        }
    }
}