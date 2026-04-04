using TGGD.UI;

namespace FOS.UI
{
    public class UIContext : IUIContext
    {
        private readonly List<string> _lines = [];

        public IEnumerable<string> GetLines()
        {
            return _lines;
        }

        public void HandleInput(string input)
        {
            _lines.Add($"Added Line: {input}");
        }

        public Task InitializeAsync()
        {
            return Task.Run(() => 
            {
                _lines.Clear();
                _lines.Add("Hello, world!");
            });
        }
    }
}
