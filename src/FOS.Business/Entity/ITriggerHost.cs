namespace FOS.Business
{
    public interface ITriggerHost
    {
        bool HasTrigger(string triggerCategory);
        ITrigger GetTrigger(string triggerCategory);
        ITrigger AppendTrigger(string triggerCategory, string triggerTypeId, Action<ITrigger>? initializer = null);
        void ClearTrigger(string triggerCategory);
    }
}
