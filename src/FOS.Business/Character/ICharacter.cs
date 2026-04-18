namespace FOS.Business
{
    public interface ICharacter : IInventoryEntity
    {
        Guid CharacterId { get; }

        string Direction { get; set; }
        ILocation Location { get; set; }
        IFeature? FocusFeature { get; set; }
        bool HasFocusFeature { get; }
        IItem? FocusItem { get; set; }
        bool HasFocusItem { get; }
        ICharacter? FocusCharacter { get; set; }
        bool HasFocusCharacter { get; }
        string Name { get; }
        void Destroy();
        bool IsAvatar { get; }
    }
}
