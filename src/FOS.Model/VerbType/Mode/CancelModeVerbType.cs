using FOS.Business;

namespace FOS.Model
{
    internal class CancelModeVerbType : IVerbType
    {
        public string Identifier => ModeVerbs.CANCEL_MODE;

        public bool CanPerform(ICharacter character)
        {
            return
                !character.IsDead() &&
                character.HasMode() &&
                (
                    character.GetMode() == Modes.TURN ||
                    character.GetMode() == Modes.STATISTICS ||
                    (character.GetMode() == Modes.GROUND_INVENTORY && !character.HasFocusItem) ||
                    (character.GetMode() == Modes.INVENTORY && !character.HasFocusItem) ||
                    (character.GetMode() == Modes.CHARACTERS && !character.HasFocusCharacter) ||
                    character.GetMode() == Modes.MOVE ||
                    (character.GetMode() == Modes.FEATURES && !character.HasFocusFeature));
        }
        private static readonly IReadOnlyDictionary<string, string> verbTexts =
            new Dictionary<string, string>
            {
                [Modes.TURN] = "Don't Turn",
                [Modes.STATISTICS] = "Leave Statistics",
                [Modes.GROUND_INVENTORY] = "Leave Ground Inventory",
                [Modes.INVENTORY] = "Leave Inventory",
                [Modes.CHARACTERS] = "Disengage Characters",
                [Modes.MOVE] = "Don't Move",
                [Modes.FEATURES] = "Disengage Features"
            };
        public string GetText(ICharacter character)
        {
            return verbTexts[character.GetMode()];
        }

        public void Perform(ICharacter character)
        {
            character.ClearMode();
        }
    }
}