using FOS.Business;

namespace FOS.Model
{
    internal static class GorachanVerbs
    {
        private static string GetName(string name) => $"{nameof(CharacterVerbs)}.{name}";
        private static readonly string INTRODUCTION = GetName(nameof(INTRODUCTION));
        private static readonly string ACCEPT_QUEST = GetName(nameof(ACCEPT_QUEST));
        private static readonly string TURN_IN_RAT_TAIL = GetName(nameof(TURN_IN_RAT_TAIL));
        private static bool IsInteractingWithGorachan(this ICharacter character, IEnumerable<string> parameters) =>
            !character.IsDead() && character.IsInMode(Modes.CHARACTERS) && (character.FocusCharacter?.HasTag(CharacterTags.GORACHAN) ?? false);
        private static bool HasAcceptedQuest(this ICharacter character) =>
            character.HasTag(QuestTags.INN_RATS_ACCEPTED);
        private static bool HasRatTail(this ICharacter character) =>
            character.Inventory.Items.Any(ItemIsRatTail);
        private static bool HasRatTailsRemaining(this ICharacter character) =>
            character.GetStatistic(StatisticTypes.RAT_TAILS_REMAINING) > 0;
        private static bool ItemIsRatTail(IItem item) =>
            item.HasTag(ItemTags.IS_RAT_TAIL);
        private static void TurnInRatTail(this ICharacter character)
        {
            var ratTail = character.Inventory.Items.First(ItemIsRatTail);
            character.Inventory.RemoveItem(ratTail);
            ratTail.Destroy();
            character.ChangeStatistic(StatisticTypes.JOOLS, 1);
            var remaining = character.ChangeStatistic(StatisticTypes.RAT_TAILS_REMAINING, -1);
            character.AddMessage(Moods.NORMAL, "\"Thanks! I use these for nefarious purposes.\"");
            character.AddMessage(Moods.NORMAL, "-1 Rat Tail");
            character.AddMessage(Moods.NORMAL, "+1 Jools");
            if (remaining == 0)
            {
                character.AddMessage(Moods.NORMAL, "\"No more rats, mate. I've got enough.\"");
            }
        }
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new VerbType(
                    INTRODUCTION,
                    IsInteractingWithGorachan,
                    x=> "\"Hello!\"",
                    (x, p)=> x.AddMessage(Moods.NORMAL, "Gorachan says, \"Henlo!\".")),
                new VerbType(
                    ACCEPT_QUEST,
                    (x, p) => x.IsInteractingWithGorachan(p) && !x.HasAcceptedQuest(),
                    x=> "I need work!",
                    (x, p)=>
                    {
                        x.SetTag(QuestTags.INN_RATS_ACCEPTED);
                        x.SetStatistic(StatisticTypes.RAT_TAILS_REMAINING, 10);
                        x.AddMessage(Moods.NORMAL, "As a matter of fact, there are rats infesting my cellar, and could use help clearing them out.");
                        x.AddMessage(Moods.NORMAL, "I'll pay you 1 jools per rat tail, but only as many as 10.");
                    }),
                new VerbType(
                    TURN_IN_RAT_TAIL,
                    (x, p) => x.IsInteractingWithGorachan(p) && x.HasAcceptedQuest() && x.HasRatTail() && x.HasRatTailsRemaining(),
                    x => "Turn in Rat Tail",
                    (x, _) => x.TurnInRatTail())
            ];
    }
}
