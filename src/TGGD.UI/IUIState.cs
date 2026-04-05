namespace TGGD.UI
{
    public interface IUIState
    {
        IEnumerable<IDialogLine> GetLines();
        IEnumerable<IDialogChoice> GetChoices();
        IUIState HandleInput(string input);
    }
}
