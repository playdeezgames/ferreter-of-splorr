using FOS.Business;

namespace FOS.Model.Dialog
{
    internal static class N00bCommandHandler
    {
        private record CommandHandler(Func<ICharacter, string, bool> Condition, Action<ICharacter, string> Operation);

        private readonly static IReadOnlyList<CommandHandler> commandHandlers =
            [
                new CommandHandler(
                    (x,s)=>
                        x.HasMetadata(Metadatas.MODE) &&
                        x.GetMetadata(Metadatas.MODE)== Modes.FEATURES &&
                        Guid.TryParse(s, out _),
                    (x,s)=>x.FocusFeature = x.World.GetFeature(Guid.Parse(s))),
                new CommandHandler(
                    (x,s)=>
                        x.HasMetadata(Metadatas.MODE) &&
                        x.GetMetadata(Metadatas.MODE)== Modes.CHARACTERS &&
                        Guid.TryParse(s, out _),
                    (x,s)=>x.FocusCharacter = x.World.GetCharacter(Guid.Parse(s))),
                new CommandHandler(
                    (x,s)=>
                        x.HasMetadata(Metadatas.MODE) &&
                        (x.GetMetadata(Metadatas.MODE)== Modes.INVENTORY || x.GetMetadata(Metadatas.MODE)== Modes.GROUND_INVENTORY) &&
                        Guid.TryParse(s, out _),
                    (x,s)=>x.FocusItem = x.World.GetItem(Guid.Parse(s))),
                new CommandHandler((_,_) => true, (x,s) => Verbs.All[s].Perform(x))
            ];

        internal static void HandleCommand(ICharacter character, string command)
        {
            character.World.ClearMessages();
            commandHandlers.First(x => x.Condition(character, command)).Operation(character, command);
        }
    }
}
