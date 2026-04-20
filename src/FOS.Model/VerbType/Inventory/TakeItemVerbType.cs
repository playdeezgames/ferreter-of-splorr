using FOS.Business;

namespace FOS.Model
{
    internal class TakeItemVerbType : IVerbType
    {
        public string Identifier => ItemVerbs.TAKE_ITEM;

        public bool CanPerform(ICharacter character, params string[] parameters)
        {
            return
                !character.IsDead() &&
                character.HasMode() &&
                character.GetMode() == Modes.GROUND_INVENTORY &&
                character.HasFocusItem;
        }

        public string GetText(ICharacter character)
        {
            return "Take...";
        }

        public void Perform(ICharacter character, params string[] parameters)
        {
            var item = character.FocusItem!;
            character.FocusItem = null;
            character.Location.Inventory.RemoveItem(item);
            character.Inventory.AddItem(item);
            character.AddMessage(Moods.NORMAL, $"You take {item.Name}.");
        }
    }
}