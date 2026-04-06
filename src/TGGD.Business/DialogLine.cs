namespace TGGD.Business
{
    public class DialogLine(string mood, string text) : IDialogLine
    {
        public string Mood => mood;

        public string Text => text;
    }
}
