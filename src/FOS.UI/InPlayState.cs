using FOS.Business;
using TGGD.Business;
using TGGD.UI;

namespace FOS.UI
{
    internal class InPlayState(IWorld world) : UIState(
        WorldDialog.GetLines(world),
        WorldDialog.GetChoices(world).Append(new DialogChoice(Commands.GAME_MENU, "Game Menu")))
    {
        public override string Prompt => WorldDialog.GetPrompt(world);

        public override IUIState HandleCommand(string command)
        {
            if (command == Commands.GAME_MENU)
            {
                return new GameMenuState(world);
            }
            WorldDialog.HandleCommand(world, command);
            return new InPlayState(world);
        }
    }
}