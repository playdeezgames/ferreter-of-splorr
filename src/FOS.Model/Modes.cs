using FOS.Business;

namespace FOS.Model
{
    internal static class Modes
    {
        internal static readonly string TURN = nameof(TURN);
        internal static readonly string MOVE = nameof(MOVE);
        internal static readonly string FEATURES = nameof(FEATURES);
        internal static readonly string INVENTORY = nameof(INVENTORY);
        internal static readonly string GROUND_INVENTORY = nameof(GROUND_INVENTORY);
        internal static readonly string CHARACTERS = nameof(CHARACTERS);
        internal static readonly string STATISTICS = nameof(STATISTICS);

        internal static bool HasMode(this ICharacter character)
        {
            return character.HasMetadata(Metadatas.MODE);
        }

        internal static void SetMode(this ICharacter character, string mode)
        {
            character.SetMetadata(Metadatas.MODE, mode);
        }

        internal static string GetMode(this ICharacter character)
        {
            return character.GetMetadata(Metadatas.MODE);
        }

        internal static void ClearMode(this ICharacter character)
        {
            character.ClearMetadata(Metadatas.MODE);
        }

        internal static bool IsInMode(this ICharacter character, string mode)
        {
            return character.HasMode() && character.GetMode() == mode;
        }
    }
}
