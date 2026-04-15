namespace FOS.Model
{
    internal static class QuestTags
    {
        private static string GetName(string name) => $"{nameof(QuestTags)}.{name}";
        internal static readonly string INN_RATS_ACCEPTED = GetName(nameof(INN_RATS_ACCEPTED));
    }
}
