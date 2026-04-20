using TGGD.Business;

namespace TGGD.UI
{
    public interface IUIState : IDialog
    {
        IUIState HandleCommand(IEnumerable<string> command);
    }
}
