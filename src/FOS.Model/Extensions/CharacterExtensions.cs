using FOS.Business;

namespace FOS.Model
{
    internal static class CharacterExtensions
    {
        internal static void AddMessage(this ICharacter character, string mood, string text)
        {
            if (character.HasTag(CharacterTags.N00B))
            {
                character.World.AddMessage(mood, text);
            }
        }
        internal static void InitializeHealth(this ICharacter character, int maximumHealth)
        {
            character.SetStatistic(StatisticTypes.HEALTH, maximumHealth);
            character.SetStatisticMaximum(StatisticTypes.HEALTH, maximumHealth);
            character.SetStatisticMinimum(StatisticTypes.HEALTH, 0);
        }
        internal static int GetHealth(this ICharacter character)
        {
            return character.GetStatistic(StatisticTypes.HEALTH);
        }
        internal static int GetMaximumHealth(this ICharacter character)
        {
            return character.GetStatisticMaximum(StatisticTypes.HEALTH);
        }
    }
}
