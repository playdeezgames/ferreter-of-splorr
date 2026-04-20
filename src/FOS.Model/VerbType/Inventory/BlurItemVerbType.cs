using FOS.Business;

namespace FOS.Model
{
    internal class BlurItemVerbType : IVerbType
    {
        public string Identifier => ItemVerbs.BLUR_ITEM;

        public bool CanPerform(ICharacter character, params string[] parameters)
        {
            return !character.IsDead() && character.HasFocusItem;
        }

        public string GetText(ICharacter character)
        {
            return "Inventory...";
        }

        public void Perform(ICharacter character, params string[] parameters)
        {
            character.FocusItem = null;
        }
    }
}