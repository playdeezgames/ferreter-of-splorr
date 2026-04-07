using FOS.Data;
using TGGD.Business;

namespace FOS.Business
{
    public interface ICharacter
    {
        Guid CharacterId { get; }
        IWorld World { get; }
        IEnumerable<IDialogChoice> GetChoices();
        IEnumerable<IDialogLine> GetLines();
        void HandleCommand(string command);
        Direction Direction { get; set; }
    }
}
