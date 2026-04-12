namespace FOS.Business
{
    public interface IItem : IEntity
    {
        Guid ItemId { get; }
        string Name { get; }
    }
}
