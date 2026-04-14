using FOS.Data;

namespace FOS.Business
{
    public interface IWorld
    {
        void Clear();
        void Initialize(Action<IWorld> initializer);
        ICharacter? Avatar { get; set; }
        ICharacter GetCharacter(Guid characterId);
        ILocation CreateLocation(string name, Action<ILocation>? initializer = null);
        ILocation GetLocation(Guid locationId);
        ITrigger GetTrigger(Guid triggerId);
        IFeature GetFeature(Guid featureId);
        IInventory CreateInventory(InventoryType inventoryType, Guid parentId);
        IEnumerable<IMessage> Messages { get; }
        void ClearMessages();
        void AddMessage(string mood, string text);
        IItem GetItem(Guid itemId);
    }
}
