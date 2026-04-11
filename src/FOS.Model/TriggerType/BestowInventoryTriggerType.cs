using FOS.Business;

namespace FOS.Model
{
    internal class BestowInventoryTriggerType : ITriggerType
    {
        public string Identifier => TriggerTypes.BESTOW_INVENTORY;

        public void Fire(ITrigger trigger, ICharacter character)
        {
            foreach (var item in trigger.Inventory.Items)
            {
                trigger.Inventory.RemoveItem(item);
                character.Inventory.AddItem(item);
            }
        }
    }
}