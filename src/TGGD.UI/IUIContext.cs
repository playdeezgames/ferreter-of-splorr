namespace TGGD.UI
{
    public interface IUIContext: IUIState
    {
        Task InitializeAsync();
    }
}
