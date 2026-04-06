using FOS.Business;
using TGGD.Business;
using TGGD.UI;

namespace FOS.UI
{
    internal class GameMenuState(IWorld world) : UIState(world, GenerateLines(world), GenerateChoices(world))
    {
        private static IEnumerable<IDialogChoice> GenerateChoices(IWorld world)
        {
            return [
                new DialogChoice(Commands.RESUME_GAME, "Resume Game"),
                new DialogChoice(Commands.ABANDON_GAME, "Abandon Game")
            ];
        }

        private static IEnumerable<IDialogLine> GenerateLines(IWorld world)
        {
            return [new DialogLine("","Game Menu:")];
        }

        public override IUIState HandleInput(string input)
        {
            if(input == Commands.RESUME_GAME)
            {
                return new InPlayState(_world);
            }
            else if(input == Commands.ABANDON_GAME)
            {
                return new MainMenuState(_world);
            }
            return this;
        }
    }
}