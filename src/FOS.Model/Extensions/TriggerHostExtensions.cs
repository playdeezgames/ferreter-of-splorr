using FOS.Business;

namespace FOS.Model
{
    internal static class TriggerHostExtensions
    {
        internal static void FireTrigger<THost>(this THost triggerHost, string triggerCategory, ICharacter character) where THost : ITriggerHost
        {
            if (!triggerHost.HasTrigger(triggerCategory))
            {
                return;
            }
            triggerHost.GetTrigger(triggerCategory).Fire(character);
        }

    }
}
