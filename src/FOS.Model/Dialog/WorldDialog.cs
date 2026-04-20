using FOS.Business;
using FOS.Model.Dialog;
using TGGD.Business;

namespace FOS.Model
{
    public static class WorldDialog
    {
        public static IEnumerable<IDialogChoice> GetChoices(IWorld world)
        {
            return N00bChoices.GetChoices(world.Avatar!);
        }

        public static IEnumerable<IDialogLine> GetLines(IWorld world)
        {
            return N00bLines.GetLines(world.Avatar!);
        }

        public static string GetPrompt(IWorld world)
        {
            return N00bPrompt.GetPrompt(world.Avatar!);
        }

        public static void HandleCommand(IWorld world, IEnumerable<string> command)
        {
            N00bCommandHandler.HandleCommand(world.Avatar!, command);
        }
    }
}
