using FOS.Business;
using TGGD.Business;
using TGGD.UI;

namespace FOS.UI
{
    internal class MainMenuState(IWorld world) : UIState(GenerateLines(), GenerateChoices())
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
                world.Initialize(WorldInitializer.Run);
                return new InPlayState(world);
            }
            return this;
        }
    }
}
