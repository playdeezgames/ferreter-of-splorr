using TGGD.Business;

namespace FOS.Business
{
    public static class WorldDialog
    {
        public static IEnumerable<IDialogChoice> GetChoices(IWorld world)
        {
            return world.GetChoices();
        }

        public static IEnumerable<IDialogLine> GetLines(IWorld world)
        {
            return world.GetLines();
        }

        public static string GetPrompt(IWorld world)
        {
            return world.Prompt;
        }

        public static void HandleCommand(IWorld world, string command)
        {
            world.HandleCommand(command);
        }
    }
}
