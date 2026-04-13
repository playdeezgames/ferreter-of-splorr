using FOS.Business;

namespace FOS.Model.Dialog
{
    internal static class N00bDialogPrompt
    {
        internal static string GetPrompt(ICharacter character)
        {
            if (!character.HasMetadata(Metadatas.MODE))
            {
                return "Now What?";
            }
            if (character.GetMetadata(Metadatas.MODE) == Modes.MOVE)
            {
                return "Move how?";
            }
            else if (character.GetMetadata(Metadatas.MODE) == Modes.TURN)
            {
                return "Turn how?";
            }
            else if (character.GetMetadata(Metadatas.MODE) == Modes.INVENTORY)
            {
                if (character.HasFocusItem)
                {
                    return $"Interact with {character.FocusItem!.Name}...";
                }
                else
                {
                    return "Inventory:";
                }
            }
            else if (character.GetMetadata(Metadatas.MODE) == Modes.GROUND_INVENTORY)
            {
                if (character.HasFocusItem)
                {
                    return $"Interact with {character.FocusItem!.Name}...";
                }
                else
                {
                    return "Ground Inventory:";
                }
            }
            else if (character.GetMetadata(Metadatas.MODE) == Modes.FEATURES)
            {
                if (character.HasFocusFeature)
                {
                    return $"Interact with {character.FocusFeature!.Name}...";
                }
                else
                {
                    return "Which Feature?";
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
