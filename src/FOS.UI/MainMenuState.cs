using FOS.Business;
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
            return [new DialogLine("", "Main Menu:")];
        }

        public override IUIState HandleInput(string input)
        {
            if(input == Commands.EMBARK)
            {
                _world.Embark();
                return new InPlayState(_world);
            }
            return this;
        }
    }
}
