using TGGD.Business;

namespace FOS.Business
{
    internal class N00bCharacterType : ICharacterType
    {
        public string Identifier => CharacterTypes.N00B;

        public IEnumerable<IDialogChoice> GetChoices(ICharacter character)
        {
            var result = new List<IDialogChoice>();
            foreach(var entry in Verbs.All)
            {
                if(entry.Value.CanPerform(character))
                {
                    result.Add(new DialogChoice(entry.Key, entry.Value.GetText(character)));
                }
            }
            return result;
        }

        public IEnumerable<IDialogLine> GetLines(ICharacter character)
        {
            var result = new List<IDialogLine>
            {
                new DialogLine(Moods.NORMAL, "Yer the n00b!"),
                new DialogLine(Moods.NORMAL, $"Yer facing {character.Direction.GetName()}.")
            };
            return result;
        }

        public void HandleCommand(ICharacter character, string command)
        {
            Verbs.All[command].Perform(character);
        }

        public void Initialize(ICharacter character)
        {
        }
    }
}
