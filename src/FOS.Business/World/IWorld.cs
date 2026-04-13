namespace FOS.Business
{
    public interface IWorld
    {
        void Clear();
        void Initialize(Action<IWorld> initializer);
        ICharacter? Avatar { get; set; }
        ICharacter GetCharacter(Guid characterId);
        ILocation CreateLocation(string name, Action<ILocation>? initializer = null);
        IFeature GetFeature(Guid featureId);
        IItem CreateItem(
            string itemType,
            string name,
            Action<IItem>? initializer = null);
        IInventory CreateInventory();
        IEnumerable<IMessage> Messages { get; }
        void ClearMessages();
        void AddMessage(string mood, string text);
        IItem GetItem(Guid itemId);
    }
}
