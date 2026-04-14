using FOS.Business;

namespace FOS.Model
{
    internal class BlurItemVerbType : IVerbType
    {
        public string Identifier => VerbTypes.BLUR_ITEM;

        public bool CanPerform(ICharacter character)
        {
            return character.HasFocusItem;
        }

        public string GetText(ICharacter character)
        {
            return "Inventory...";
        }

        public void Perform(ICharacter character)
        {
            character.FocusItem = null;
        }
    }
}