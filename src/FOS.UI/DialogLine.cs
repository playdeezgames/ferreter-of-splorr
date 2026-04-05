using TGGD.UI;

namespace FOS.UI
{
    internal class DialogLine(string mood, string text) : IDialogLine
    {
        public string Mood => mood;

        public string Text => text;
    }
}
