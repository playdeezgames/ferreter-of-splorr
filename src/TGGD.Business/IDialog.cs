namespace TGGD.Business
{
    public interface IDialog
    {
        IEnumerable<IDialogLine> GetLines();
        IEnumerable<IDialogChoice> GetChoices();
        string Prompt { get; }
    }
}
