using FOS.Business;
using TGGD.Business;

namespace FOS.Model.Dialog
{
    internal static class N00bChoices
    {
        internal static IEnumerable<IDialogChoice> GetChoices(ICharacter character)
        {
            return [
                    .. AddFeaturesChoices(character),
                    .. AddInventoryChoices(character),
                    .. AddGroundInventoryChoices(character),
                    .. AddCharactersChoices(character),
                    .. AddVerbChoices(character)
                ];
        }
        private static IEnumerable<IDialogChoice> AddGroundInventoryChoices(ICharacter character)
        {
            if (
                !character.HasMode() ||
                character.GetMode() != Modes.GROUND_INVENTORY ||
                character.HasFocusItem)
            {
                return [];
            }
            return character.Location.Inventory.Items.Select(x => new DialogChoice(x.ItemId.ToString(), x.Name));
        }

        private static IEnumerable<IDialogChoice> AddInventoryChoices(ICharacter character)
        {
            if (
                !character.HasMode() ||
                character.GetMode() != Modes.INVENTORY ||
                character.HasFocusItem)
            {
                return [];
            }
            return character.Inventory.Items.Select(x => new DialogChoice(x.ItemId.ToString(), x.Name));
        }

        private static IEnumerable<IDialogChoice> AddVerbChoices(ICharacter character)
        {
            return Verbs.All.
                Where(x => x.Value.CanPerform(character)).
                Select(x => new DialogChoice(x.Key, x.Value.GetText(character)));
        }

        private static IEnumerable<IDialogChoice> AddFeaturesChoices(ICharacter character)
        {
            if (
                !character.HasMode() ||
                character.GetMode() != Modes.FEATURES ||
                character.HasFocusFeature)
            {
                return [];
            }
            return character.Location.Features.Select(x => new DialogChoice(x.FeatureId.ToString(), x.Name));
        }

        private static IEnumerable<IDialogChoice> AddCharactersChoices(ICharacter character)
        {
            if (
                !character.HasMode() ||
                character.GetMode() != Modes.CHARACTERS ||
                character.HasFocusCharacter)
            {
                return [];
            }
            return character.
                Location.
                GetOtherCharacters(character).
                Select(x => new DialogChoice(x.CharacterId.ToString(), x.Name));
        }
    }
}
