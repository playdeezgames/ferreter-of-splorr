using FOS.Data;

namespace FOS.Business
{
    public interface IWorld
    {
        void Clear();
        void Initialize(Action<IWorld> initializer);
        ICharacter CreateCharacter(ILocation location, Action<ICharacter>? initializer = null);
        ICharacter? Avatar { get; set; }
        ILocation CreateLocation(string name, Action<ILocation>? initializer = null);
        IRoute CreateRoute(
            string name,
            Direction direction,
            ILocation fromLocation,
            ILocation toLocation,
            Action<IRoute>? initializer = null);
        IFeature CreateFeature(
            string name,
            ILocation location,
            Action<IFeature>? initializer = null);
        IFeature GetFeature(Guid featureId);
        ITrigger CreateTrigger(string triggerType, Action<ITrigger>? initializer = null);
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
