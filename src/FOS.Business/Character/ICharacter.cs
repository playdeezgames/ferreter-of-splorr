using FOS.Data;

namespace FOS.Business
{
    public interface ICharacter : IInventoryEntity
    {
        Guid CharacterId { get; }

        Direction Direction { get; set; }
        ILocation Location { get; set; }
        IFeature? FocusFeature { get; set; }
        bool HasFocusFeature { get; }
        IItem? FocusItem { get; set; }
        bool HasFocusItem { get; }
        void AddMessage(string mood, string text);
        string GetDirectionName();
    }
}
