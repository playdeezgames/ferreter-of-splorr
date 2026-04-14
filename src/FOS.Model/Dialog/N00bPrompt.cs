using FOS.Business;

namespace FOS.Model.Dialog
{
    internal static class N00bPrompt
    {
        private record PromptDeterminer(Func<ICharacter, bool> Condition, Func<ICharacter, string> GetPrompt);

        private readonly static IReadOnlyList<PromptDeterminer> promptDeterminers =
            [
                new PromptDeterminer(x=>!x.HasMode(), x=>"Now What?"),
                new PromptDeterminer(x=>x.GetMode()==Modes.MOVE, x=>"Move How?"),
                new PromptDeterminer(x=>x.GetMode()==Modes.TURN, x=>"Turn How?"),
                new PromptDeterminer(x=>x.GetMode()==Modes.STATISTICS, x=>"Stats are FUN!"),
                new PromptDeterminer(x=>x.GetMode()==Modes.INVENTORY && x.HasFocusItem, x=>$"Interact with {x.FocusItem!.Name}..."),
                new PromptDeterminer(x=>x.GetMode()==Modes.INVENTORY, x=>"Inventory:"),
                new PromptDeterminer(x=>x.GetMode()==Modes.GROUND_INVENTORY && x.HasFocusItem, x=>$"Interact with {x.FocusItem!.Name}..."),
                new PromptDeterminer(x=>x.GetMode()==Modes.GROUND_INVENTORY, x=>"Ground Inventory:"),
                new PromptDeterminer(x=>x.GetMode()==Modes.FEATURES && x.HasFocusFeature, x=>$"Interact with {x.FocusFeature!.Name}..."),
                new PromptDeterminer(x=>x.GetMode()==Modes.FEATURES, x=>"Which Feature?"),
                new PromptDeterminer(x=>x.GetMode()==Modes.CHARACTERS && x.HasFocusCharacter, x=>$"Interact with {x.FocusCharacter!.Name}..."),
                new PromptDeterminer(x=>x.GetMode()==Modes.CHARACTERS, x=>"Which Character?")
            ];

        internal static string GetPrompt(ICharacter character)
        {
            return promptDeterminers.First(x => x.Condition(character)).GetPrompt(character);
        }
    }
}
