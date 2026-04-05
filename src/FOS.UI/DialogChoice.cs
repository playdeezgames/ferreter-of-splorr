using TGGD.UI;

namespace FOS.UI
{
    internal class DialogChoice(string command, string text) : IDialogChoice
    {
        public string Command => command;

        public string Text => text;
    }
}
