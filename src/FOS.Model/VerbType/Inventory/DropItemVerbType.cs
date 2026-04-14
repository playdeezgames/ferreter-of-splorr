using FOS.Business;

namespace FOS.Model
{
    internal class DropItemVerbType : IVerbType
    {
        public string Identifier => ItemVerbs.DROP_ITEM;

        public bool CanPerform(ICharacter character)
        {
            return
                character.HasMode() &&
                character.GetMode() == Modes.INVENTORY &&
                character.HasFocusItem;
        }

        public string GetText(ICharacter character)
        {
            return "Drop";
        }

        public void Perform(ICharacter character)
        {
            var item = character.FocusItem!;
            character.FocusItem = null;
            character.Inventory.RemoveItem(item);
            character.Location.Inventory.AddItem(item);
            character.AddMessage(Moods.NORMAL, $"You drop {item.Name}.");
        }
    }
}