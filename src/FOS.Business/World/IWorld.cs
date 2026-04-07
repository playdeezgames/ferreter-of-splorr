using TGGD.Business;

namespace FOS.Business
{
    public interface IWorld : IDialog
    {
        void Clear();
        void Initialize();
        ICharacter CreateCharacter(string characterType);
        ICharacter? Avatar { get; set; }
        void HandleCommand(string command);
    }
}
