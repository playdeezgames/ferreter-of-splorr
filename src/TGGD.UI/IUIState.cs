using TGGD.Business;

namespace TGGD.UI
{
    public interface IUIState: IDialog
    {
        IUIState HandleCommand(string command);
    }
}
