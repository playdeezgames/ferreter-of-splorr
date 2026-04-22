using FOS.Business;

namespace FOS.Model.Dialog
{
    internal static class N00bCommandHandler
    {
        internal static void HandleCommand(ICharacter character, IEnumerable<string> command)
        {
            character.World.ClearMessages();
            Verbs.All[command.First()].Perform(character, [.. command.Skip(1)]);
        }
    }
}
