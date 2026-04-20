using FOS.Business;
using FOS.Data;
using FOS.Model;
using TGGD.Business;
using TGGD.UI;

namespace FOS.UI
{
    public class UIContext : IUIContext
    {
        private IUIState? _uiState = null;
        private readonly IWorld _world = new World(new WorldData(), new Grimoire());

        public string Prompt => _uiState?.Prompt ?? string.Empty;

        public IEnumerable<IDialogChoice> GetChoices()
        {
            return _uiState?.GetChoices() ?? [];
        }

        public IEnumerable<IDialogLine> GetLines()
        {
            return _uiState?.GetLines() ?? [];
        }

        public IUIState HandleCommand(params string[] command)
        {
            _uiState = _uiState!.HandleCommand(command);
            return this;
        }

        public Task InitializeAsync()
        {
            return Task.Run(() =>
            {
                _uiState = new TitleState(_world);
            });
        }
    }
}
