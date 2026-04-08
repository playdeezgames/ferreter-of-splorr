using FOS.Data;

namespace FOS.Business
{
    public interface ILocation
    {
        Guid LocationId { get; }
        void AddCharacter(ICharacter character);
        void SetRoute(Direction direction, IRoute result);
        string Name { get; }
        IEnumerable<IRoute> Routes { get; }
    }
}
