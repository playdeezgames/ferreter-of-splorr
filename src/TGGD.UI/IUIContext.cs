namespace TGGD.UI
{
    public interface IUIContext
    {
        IEnumerable<string> GetLines();
        void HandleInput(string input);
        Task InitializeAsync();
    }
}
