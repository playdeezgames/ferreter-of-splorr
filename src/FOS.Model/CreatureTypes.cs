namespace FOS.Model
{
    internal class CreatureTypes
    {
        private static string GetName(string name) => $"{nameof(CreatureTypes)}.{name}";
        internal readonly static string CELLAR_RAT = GetName(nameof(CELLAR_RAT));
    }
}
