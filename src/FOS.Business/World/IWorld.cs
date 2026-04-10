using FOS.Data;
using TGGD.Business;

namespace FOS.Business
{
    public interface IWorld : IDialog
    {
        void Clear();
        void Initialize();
        ICharacter CreateCharacter(string characterType, ILocation location);
        ICharacter? Avatar { get; set; }
        void HandleCommand(string command);
        ILocation CreateLocation(string locationType, string name);
        IRoute CreateRoute(string routeType, string name, Direction direction, ILocation fromLocation, ILocation toLocation);
        IFeature CreateFeature(string featureType, string name, ILocation location);
        IFeature GetFeature(Guid featureId);
        ITrigger CreateTrigger(string triggerType);
        IItem CreateItem(string itemType);
        IInventory CreateInventory();
        IEnumerable<IMessage> Messages { get; }
    }
}
