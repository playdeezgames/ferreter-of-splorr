using FOS.Business;
using FOS.Data;
using TGGD.UI;

namespace FOS.UI
{
    public class UIContext : IUIContext
    {
        private IUIState? _uiState = null;
        private readonly IWorld _world = World.Create(new WorldData());

        public IEnumerable<IDialogChoice> GetChoices()
        {
            return _uiState?.GetChoices() ?? [];
        }

        public IEnumerable<IDialogLine> GetLines()
        {
            return _uiState?.GetLines() ?? [];
        }

        public IUIState HandleInput(string input)
        {
            _uiState = _uiState!.HandleInput(input);
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
