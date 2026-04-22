using FOS.Business;

namespace FOS.Model.Dialog
{
    internal static class N00bCommandHandler
    {
        private record CommandHandler(Func<ICharacter, IEnumerable<string>, bool> Condition, Action<ICharacter, IEnumerable<string>> Operation);

        private readonly static IReadOnlyList<CommandHandler> commandHandlers =
            [
                new CommandHandler(
                    (x,s)=>
                        x.HasMode() &&
                        x.GetMode()== Modes.CHARACTERS &&
                        Guid.TryParse(s.FirstOrDefault(), out _),
                    (x,s)=>x.FocusCharacter = x.World.GetCharacter(Guid.Parse(s.First()))),
                new CommandHandler(
                    (_,_) => true,
                    (x,s) =>
                        Verbs.All[s.First()].Perform(x,[.. s.Skip(1)]))
            ];

        internal static void HandleCommand(ICharacter character, IEnumerable<string> command)
        {
            character.World.ClearMessages();
            commandHandlers.First(x => x.Condition(character, command)).Operation(character, command);
        }
    }
}
