namespace TGGD.Business
{
    public class DialogChoice(IEnumerable<string> command, string text) : IDialogChoice
    {
        public IEnumerable<string> Command => command;

        public string Text => text;
    }
}
