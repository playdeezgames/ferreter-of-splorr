namespace FOS.Business
{
    public interface IItem
    {
        Guid ItemId { get; }
        string Name { get; }
    }
}
