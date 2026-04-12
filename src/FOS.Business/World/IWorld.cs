namespace FOS.Business
{
    public interface IWorld
    {
        void Clear();
        void Initialize(Action<IWorld> initializer);
        ICharacter? Avatar { get; set; }
        ILocation CreateLocation(string name, Action<ILocation>? initializer = null);
        IRoute CreateRoute(
            string name,
            string direction,
            ILocation fromLocation,
            ILocation toLocation,
            Action<IRoute>? initializer = null);
        IFeature GetFeature(Guid featureId);
        ITrigger CreateTrigger(string triggerType,
            Action<ITrigger>? initializer = null);
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
