namespace TGGD.Business
{
    public class DialogChoice(string command, string text) : IDialogChoice
    {
        public string Command => command;

        public string Text => text;
    }
}
