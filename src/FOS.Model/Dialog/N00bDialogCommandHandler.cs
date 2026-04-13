using FOS.Business;

namespace FOS.Model.Dialog
{
    internal static class N00bDialogCommandHandler
    {
        internal static void HandleCommand(ICharacter character, string command)
        {
            character.World.ClearMessages();
            if (character.HasMetadata(Metadatas.MODE))
            {
                var mode = character.GetMetadata(Metadatas.MODE);
                if (mode == Modes.FEATURES)
                {
                    if (Guid.TryParse(command, out Guid featureId))
                    {
                        character.FocusFeature = character.World.GetFeature(featureId);
                        return;
                    }
                }
                else if (mode == Modes.INVENTORY || mode == Modes.GROUND_INVENTORY)
                {
                    if (Guid.TryParse(command, out Guid itemId))
                    {
                        character.FocusItem = character.World.GetItem(itemId);
                        return;
                    }
                }
            }
            Verbs.All[command].Perform(character);
        }
    }
}
