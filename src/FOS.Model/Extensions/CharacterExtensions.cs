using FOS.Business;
using TGGD.Business;

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

        private static void AddMessages(this IEnumerable<ICharacter> characters, string mood, string text)
        {
            foreach (var character in characters)
            {
                character.AddMessage(mood, text);
            }
        }

        internal static int GetAttackDice(this ICharacter character)
        {
            return character.GetStatistic(StatisticTypes.ATTACK_DICE);
        }

        internal static int GetMaximumAttack(this ICharacter character)
        {
            return character.GetStatistic(StatisticTypes.MAXIMUM_ATTACK);
        }

        internal static int GetDefendDice(this ICharacter character)
        {
            return character.GetStatistic(StatisticTypes.DEFEND_DICE);
        }

        internal static int GetMaximumDefend(this ICharacter character)
        {
            return character.GetStatistic(StatisticTypes.MAXIMUM_DEFEND);
        }

        private static int RollAttack(this ICharacter character)
        {
            return Math.Min(character.GetMaximumAttack(), Enumerable.Range(0, character.GetAttackDice()).
                Select(x => RNG.GenerateBool(5, 1)).
                Count(x => x));
        }

        private static int RollDefend(this ICharacter character)
        {
            return Math.Min(character.GetMaximumDefend(), Enumerable.Range(0, character.GetDefendDice()).
                Select(x => RNG.GenerateBool(5, 1)).
                Count(x => x));
        }

        private static void TakeDamage(this ICharacter character, int damage)
        {
            character.ChangeStatistic(StatisticTypes.HEALTH, -damage);
        }

        internal static bool IsDead(this ICharacter character)
        {
            return character.GetHealth() == character.GetStatisticMinimum(StatisticTypes.HEALTH);
        }

        private static void Kill(this ICharacter character)
        {
            foreach (var otherCharacter in character.Location.GetOtherCharacters(character).Where(x => x.FocusCharacter?.CharacterId == character.CharacterId))
            {
                otherCharacter.FocusCharacter = null;
            }
            foreach (var item in character.Inventory.Items)
            {
                character.Inventory.RemoveItem(item);
                character.Location.Inventory.AddItem(item);
            }
            if (!character.IsAvatar)
            {
                character.Destroy();
            }
        }

        internal static void Attack(this ICharacter character, ICharacter otherCharacter)
        {
            IEnumerable<ICharacter> both = [character, otherCharacter];
            both.AddMessages(Moods.NORMAL, $"{character.Name} attacks {otherCharacter.Name}!");
            var attackRoll = character.RollAttack();
            both.AddMessages(Moods.NORMAL, $"{character.Name} rolls an attack of {attackRoll}!");
            var defendRoll = otherCharacter.RollDefend();
            both.AddMessages(Moods.NORMAL, $"{otherCharacter.Name} rolls a defend of {defendRoll}!");
            var damage = Math.Max(attackRoll - defendRoll, 0);
            both.AddMessages(Moods.NORMAL, $"{otherCharacter.Name} takes {damage} damage!");
            otherCharacter.TakeDamage(damage);
            if (otherCharacter.IsDead())
            {
                both.AddMessages(Moods.NORMAL, $"{character.Name} kills {otherCharacter.Name}!");
                otherCharacter.Kill();
            }
            else
            {
                both.AddMessages(Moods.NORMAL, $"{otherCharacter.Name} has {otherCharacter.GetHealth()}/{otherCharacter.GetMaximumHealth()} health remaining!");
            }
        }
    }
}
