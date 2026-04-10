namespace FOS.Business
{
    internal class DaggerItemType : IItemType
    {
        public string Identifier => ItemTypes.DAGGER;

        public void Initialize(IItem item)
        {
        }
    }
}