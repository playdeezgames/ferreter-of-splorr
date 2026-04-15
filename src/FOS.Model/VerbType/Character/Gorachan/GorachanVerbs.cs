using FOS.Business;

namespace FOS.Model
{
    internal static class GorachanVerbs
    {
        private static string GetName(string name) => $"{nameof(CharacterVerbs)}.{name}";
        private static readonly string INTRODUCTION = GetName(nameof(INTRODUCTION));
        private static readonly string ACCEPT_QUEST = GetName(nameof(ACCEPT_QUEST));
        private static bool IsInteractingWithGorachan(this ICharacter character) => character.IsInMode(Modes.CHARACTERS) && (character.FocusCharacter?.HasTag(CharacterTags.GORACHAN) ?? false);
        private static bool HasAcceptedQuest(this ICharacter character)
        {
            return character.HasTag(QuestTags.INN_RATS_ACCEPTED);
        }
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new VerbType(
                    INTRODUCTION,
                    IsInteractingWithGorachan,
                    x=> "\"Hello!\"",
                    x=> x.AddMessage(Moods.NORMAL, "Gorachan says, \"Henlo!\".")),
                new VerbType(
                    ACCEPT_QUEST,
                    x=> x.IsInteractingWithGorachan() && !x.HasAcceptedQuest(),
                    x=> "I need work!",
                    x=>
                    {
                        x.SetTag(QuestTags.INN_RATS_ACCEPTED);
                        x.AddMessage(Moods.NORMAL, "As a matter of fact, there are rats infesting my cellar, and could use help clearing them out.");
                        x.AddMessage(Moods.NORMAL, "I'll pay you 1 jools per rat tail, but only as many as 10.");
                    })
            ];
    }
}
