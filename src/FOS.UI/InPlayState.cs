using FOS.Business;
using TGGD.Business;
using TGGD.UI;

namespace FOS.UI
{
    internal class InPlayState(IWorld world) : UIState(world, GenerateLines(world), GenerateChoices(world))
    {
        public override string Prompt => _world.Prompt;

        private static List<IDialogChoice> GenerateChoices(IWorld world)
        {
            List<IDialogChoice> choices = [.. world.GetChoices()];
            choices.Add(new DialogChoice(Commands.GAME_MENU, "Game Menu"));
            return choices;
        }

        private static IEnumerable<IDialogLine> GenerateLines(IWorld world)
        {
            return world.GetLines();
        }

        public override IUIState HandleCommand(string command)
        {
            if (command == Commands.GAME_MENU)
            {
                return new GameMenuState(_world);
            }
            _world.HandleCommand(command);
            return new InPlayState(_world);
        }
    }
}