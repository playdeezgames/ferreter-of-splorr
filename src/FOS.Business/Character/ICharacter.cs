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
        IFeature? Feature { get; set; }
        bool HasFeature { get; }
        void AddMessage(string mood, string text);
    }
}
