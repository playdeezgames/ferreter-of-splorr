using FOS.Business;
using TGGD.Business;

namespace FOS.Model.Dialog
{
    internal static class N00bDialogChoices
    {
        internal static IEnumerable<IDialogChoice> GetChoices(ICharacter character)
        {
            var choices = new List<IDialogChoice>();
            AddFeaturesChoices(choices, character);
            AddInventoryChoices(choices, character);
            AddGroundInventoryChoices(choices, character);
            AddVerbChoices(choices, character);
            return choices;
        }
        private static void AddGroundInventoryChoices(List<IDialogChoice> choices, ICharacter character)
        {
            if (character.HasMetadata(Metadatas.MODE) && !character.HasFocusItem)
            {
                if (character.GetMetadata(Metadatas.MODE) == Modes.GROUND_INVENTORY)
                {
                    foreach (var item in character.Location.Inventory.Items)
                    {
                        choices.Add(new DialogChoice(item.ItemId.ToString(), item.Name));
                    }
                }
            }
        }

        private static void AddInventoryChoices(List<IDialogChoice> choices, ICharacter character)
        {
            if (character.HasMetadata(Metadatas.MODE) && !character.HasFocusItem)
            {
                if (character.GetMetadata(Metadatas.MODE) == Modes.INVENTORY)
                {
                    foreach (var item in character.Inventory.Items)
                    {
                        choices.Add(new DialogChoice(item.ItemId.ToString(), item.Name));
                    }
                }
            }
        }

        private static void AddVerbChoices(List<IDialogChoice> choices, ICharacter character)
        {
            foreach (var entry in Verbs.All)
            {
                if (entry.Value.CanPerform(character))
                {
                    choices.Add(new DialogChoice(entry.Key, entry.Value.GetText(character)));
                }
            }
        }

        private static void AddFeaturesChoices(List<IDialogChoice> choices, ICharacter character)
        {
            if (character.HasMetadata(Metadatas.MODE) && !character.HasFocusFeature)
            {
                if (character.GetMetadata(Metadatas.MODE) == Modes.FEATURES)
                {
                    foreach (var feature in character.Location.Features)
                    {
                        choices.Add(new DialogChoice(feature.FeatureId.ToString(), feature.Name));
                    }
                }
            }
        }
    }
}
