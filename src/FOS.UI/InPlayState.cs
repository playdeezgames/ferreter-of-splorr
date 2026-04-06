using FOS.Business;
using TGGD.Business;
using TGGD.UI;

namespace FOS.UI
{
    internal class InPlayState(IWorld world) : UIState(world, GenerateLines(world), GenerateChoices(world))
    {
        private static IEnumerable<IDialogChoice> GenerateChoices(IWorld world)
        {
            return [new DialogChoice(Commands.GAME_MENU, "Game Menu")];
        }

        private static IEnumerable<IDialogLine> GenerateLines(IWorld world)
        {
            return [new DialogLine("", "Yer playing the game!")];
        }

        public override IUIState HandleInput(string input)
        {
            if(input == Commands.GAME_MENU)
            {
                return new GameMenuState(_world);
            }
            return this;
        }
    }
}