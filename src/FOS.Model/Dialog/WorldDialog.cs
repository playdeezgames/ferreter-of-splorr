using FOS.Business;
using FOS.Model.Dialog;
using TGGD.Business;

namespace FOS.Model
{
    public static class WorldDialog
    {
        public static IEnumerable<IDialogChoice> GetChoices(IWorld world)
        {
            return N00bDialogChoices.GetChoices(world.Avatar!);
        }

        public static IEnumerable<IDialogLine> GetLines(IWorld world)
        {
            return N00bDialogLines.GetLines(world.Avatar!);
        }

        public static string GetPrompt(IWorld world)
        {
            return N00bDialogPrompt.GetPrompt(world.Avatar!);
        }

        public static void HandleCommand(IWorld world, string command)
        {
            N00bDialogCommandHandler.HandleCommand(world.Avatar!, command);
        }
    }
}
