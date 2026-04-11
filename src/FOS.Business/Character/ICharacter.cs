using FOS.Data;
using TGGD.Business;

namespace FOS.Business
{
    public interface ICharacter : IInventoryEntity
    {
        Guid CharacterId { get; }
        IEnumerable<IDialogChoice> GetChoices();
        IEnumerable<IDialogLine> GetLines();
        string Prompt { get; }
        void HandleCommand(string command);
        Direction Direction { get; set; }
        ILocation Location { get; set; }
        IFeature? FocusFeature { get; set; }
        bool HasFocusFeature { get; }
        IItem? FocusItem { get; set; }
        bool HasFocusItem { get; }
        void AddMessage(string mood, string text);
    }
}
