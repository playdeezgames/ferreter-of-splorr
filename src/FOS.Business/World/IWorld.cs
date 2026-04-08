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
        ILocation CreateLocation(string locationType);
        IRoute CreateRoute(string routeType, Direction direction, ILocation fromLocation, ILocation toLocation);
    }
}
