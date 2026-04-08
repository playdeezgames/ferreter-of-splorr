using TGGD.Business;

namespace FOS.Business
{
    internal class N00bCharacterType : ICharacterType
    {
        public string Identifier => CharacterTypes.N00B;

        public IEnumerable<IDialogChoice> GetChoices(ICharacter character)
        {
            var result = new List<IDialogChoice>();
            foreach (var entry in Verbs.All)
            {
                if (entry.Value.CanPerform(character))
                {
                    result.Add(new DialogChoice(entry.Key, entry.Value.GetText(character)));
                }
            }
            return result;
        }

        public IEnumerable<IDialogLine> GetLines(ICharacter character)
        {
            var location = character.Location;
            var result = new List<IDialogLine>
            {
                new DialogLine(Moods.NORMAL, "Yer the n00b!"),
                new DialogLine(Moods.NORMAL, $"Yer facing {character.Direction.GetName()}."),
                new DialogLine(Moods.NORMAL, $"Location: {location.Name}.")
            };
            var features = location.Features;
            if (features.Any())
            {
                result.Add(new DialogLine(Moods.NORMAL, "Features:"));
            }
            foreach (var feature in features)
            {
                result.Add(new DialogLine(Moods.NORMAL, $"{feature.Name}"));
            }
            var routes = location.Routes;
            if (routes.Any())
            {
                result.Add(new DialogLine(Moods.NORMAL, "Exits:"));
            }
            foreach (var route in routes)
            {
                result.Add(new DialogLine(Moods.NORMAL, $"{route.Direction.GetName()}: {route.Name}"));
            }
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
