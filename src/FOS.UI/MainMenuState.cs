using FOS.Business;
using TGGD.Business;
using TGGD.UI;

namespace FOS.UI
{
    internal class MainMenuState(IWorld world) : UIState(world, GenerateLines(), GenerateChoices())
    {
        private static IEnumerable<IDialogChoice> GenerateChoices()
        {
            return [new DialogChoice(Commands.EMBARK, "Embark!")];
        }

        private static IEnumerable<IDialogLine> GenerateLines()
        {
            return [new DialogLine(Moods.MENU_HEADER, "Main Menu:")];
        }

        public override IUIState HandleCommand(string command)
        {
            if(command == Commands.EMBARK)
            {
                _world.Initialize();
                return new InPlayState(_world);
            }
            return this;
        }
    }
}
