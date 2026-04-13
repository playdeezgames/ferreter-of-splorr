using FOS.Business;

namespace FOS.Model.Dialog
{
    internal static class N00bPrompt
    {
        private record PromptDeterminer(Func<ICharacter, bool> Condition, Func<ICharacter, string> GetPrompt);

        private readonly static IReadOnlyList<PromptDeterminer> promptDeterminers =
            [
                new PromptDeterminer(x=>!x.HasMetadata(Metadatas.MODE), x=>"Now What?"),
                new PromptDeterminer(x=>x.GetMetadata(Metadatas.MODE)==Modes.MOVE, x=>"Move How?"),
                new PromptDeterminer(x=>x.GetMetadata(Metadatas.MODE)==Modes.TURN, x=>"Turn How?"),
                new PromptDeterminer(x=>x.GetMetadata(Metadatas.MODE)==Modes.INVENTORY && x.HasFocusItem, x=>$"Interact with {x.FocusItem!.Name}..."),
                new PromptDeterminer(x=>x.GetMetadata(Metadatas.MODE)==Modes.INVENTORY, x=>"Inventory:"),
                new PromptDeterminer(x=>x.GetMetadata(Metadatas.MODE)==Modes.GROUND_INVENTORY && x.HasFocusItem, x=>$"Interact with {x.FocusItem!.Name}..."),
                new PromptDeterminer(x=>x.GetMetadata(Metadatas.MODE)==Modes.GROUND_INVENTORY, x=>"Ground Inventory:"),
                new PromptDeterminer(x=>x.GetMetadata(Metadatas.MODE)==Modes.FEATURES && x.HasFocusFeature, x=>$"Interact with {x.FocusFeature!.Name}..."),
                new PromptDeterminer(x=>x.GetMetadata(Metadatas.MODE)==Modes.FEATURES, x=>"Which Feature?")
            ];

        internal static string GetPrompt(ICharacter character)
        {
            return promptDeterminers.First(x => x.Condition(character)).GetPrompt(character);
        }
    }
}
