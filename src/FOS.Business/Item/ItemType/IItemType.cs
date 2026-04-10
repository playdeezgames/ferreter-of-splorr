namespace FOS.Business
{
    internal interface IItemType
    {
        string Identifier { get; }
        void Initialize(IItem item);
    }
}
