using FOS.Business;
using TGGD.Business;
using TGGD.UI;

namespace FOS.UI
{
    internal class MainMenuState(IWorld world) : UIState(world, GenerateLines(), GenerateChoices())
    {
        public override string Prompt => "Main Menu:";

        private static IEnumerable<IDialogChoice> GenerateChoices()
        {
            return [new DialogChoice(Commands.EMBARK, "Embark!")];
        }

        private static IEnumerable<IDialogLine> GenerateLines()
        {
            return [];
        }

        public override IUIState HandleCommand(string command)
        {
            if (command == Commands.EMBARK)
            {
                _world.Initialize();
                return new InPlayState(_world);
            }
            return this;
        }
    }
}
