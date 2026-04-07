using TGGD.Business;

namespace FOS.Business
{
    internal class N00bCharacterType : ICharacterType
    {
        public string Identifier => CharacterTypes.N00B;

        public IEnumerable<IDialogChoice> GetChoices(ICharacter character)
        {
            var result = new List<IDialogChoice>();
            return result;
        }

        public IEnumerable<IDialogLine> GetLines(ICharacter character)
        {
            var result = new List<IDialogLine>();
            result.Add(new DialogLine(Moods.NORMAL, "Yer the n00b!"));
            return result;
        }

        public void HandleCommand(ICharacter character, string command)
        {
            //do nothing!
        }
    }
}
