using FOS.Business;
using FOS.Model;
using TGGD.Business;
using TGGD.UI;

namespace FOS.UI
{
    internal class InPlayState(IWorld world) : UIState(
        WorldDialog.GetLines(world),
        WorldDialog.GetChoices(world).Append(new DialogChoice([Commands.GAME_MENU], "Game Menu")))
    {
        public override string Prompt => WorldDialog.GetPrompt(world);

        public override IUIState HandleCommand(IEnumerable<string> command)
        {
            if (command.FirstOrDefault() == Commands.GAME_MENU)
            {
                return new GameMenuState(world);
            }
            WorldDialog.HandleCommand(world, command);
            return new InPlayState(world);
        }
    }
}