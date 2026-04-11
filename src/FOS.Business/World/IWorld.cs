using FOS.Data;
using TGGD.Business;

namespace FOS.Business
{
    public interface IWorld : IDialog
    {
        void Clear();
        void Initialize(Action<IWorld> initializer);
        ICharacter CreateCharacter(string characterType, ILocation location, Action<ICharacter>? initializer = null);
        ICharacter? Avatar { get; set; }
        void HandleCommand(string command);
        ILocation CreateLocation(string locationType, string name, Action<ILocation>? initializer = null);
        IRoute CreateRoute(
            string routeType,
            string name,
            Direction direction,
            ILocation fromLocation,
            ILocation toLocation,
            Action<IRoute>? initializer = null);
        IFeature CreateFeature(
            string featureType,
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
