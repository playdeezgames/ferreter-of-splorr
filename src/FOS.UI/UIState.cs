using TGGD.UI;

namespace FOS.UI
{
    public abstract class UIState(IEnumerable<IDialogLine> lines, IEnumerable<IDialogChoice> choices) : IUIState
    {
        private readonly List<IDialogLine> _lines = [.. lines];
        private readonly List<IDialogChoice> _choices = [.. choices];

        public IEnumerable<IDialogChoice> GetChoices()
        {
            return _choices;
        }

        public IEnumerable<IDialogLine> GetLines()
        {
            return _lines;
        }

        protected void ClearChoices()
        {
            _choices.Clear();
        }

        protected void ClearLines()
        {
            _lines.Clear();
        }
        protected void AddChoice(string command, string text)
        {
            _choices.Add(new DialogChoice(command, text));
        }
        protected void AddLine(string mood, string text)
        {
            _lines.Add(new DialogLine(mood, text));
        }
        public abstract IUIState HandleInput(string input);
    }
}
