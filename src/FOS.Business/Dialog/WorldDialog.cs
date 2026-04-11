using FOS.Business.Dialog;
using TGGD.Business;

namespace FOS.Business
{
    public static class WorldDialog
    {
        public static IEnumerable<IDialogChoice> GetChoices(IWorld world)
        {
            return N00bDialog.GetChoices(world.Avatar!);
        }

        public static IEnumerable<IDialogLine> GetLines(IWorld world)
        {
            return N00bDialog.GetLines(world.Avatar!);
        }

        public static string GetPrompt(IWorld world)
        {
            return N00bDialog.GetPrompt(world.Avatar!);
        }

        public static void HandleCommand(IWorld world, string command)
        {
            N00bDialog.HandleCommand(world.Avatar!, command);
        }
    }
}
