using TGGD.Business;

namespace FOS.Business
{
    internal class N00bCharacterType : ICharacterType
    {
        public string Identifier => CharacterTypes.N00B;

        public IEnumerable<IDialogChoice> GetChoices(ICharacter character)
        {
            var choices = new List<IDialogChoice>();
            AddCurrentFeatureChoices(choices, character);
            AddFeaturesChoices(choices, character);
            AddVerbChoices(choices, character);
            return choices;
        }

        private static void AddCurrentFeatureChoices(List<IDialogChoice> choices, ICharacter character)
        {
            var feature = character.Feature;
            if (feature != null)
            {
                return;
            }
        }

        private static void AddVerbChoices(List<IDialogChoice> choices, ICharacter character)
        {
            foreach (var entry in Verbs.All)
            {
                if (entry.Value.CanPerform(character))
                {
                    choices.Add(new DialogChoice(entry.Key, entry.Value.GetText(character)));
                }
            }
        }

        private static void AddFeaturesChoices(List<IDialogChoice> choices, ICharacter character)
        {
            if (character.HasMetadata(Metadatas.MODE) && !character.HasFeature)
            {
                if (character.GetMetadata(Metadatas.MODE) == Modes.FEATURES)
                {
                    foreach (var feature in character.Location.Features)
                    {
                        choices.Add(new DialogChoice(feature.FeatureId.ToString(), feature.Name));
                    }
                }
            }
        }

        private static void GetFeaturesLines(List<IDialogLine> lines, ILocation location)
        {
            var features = location.Features;
            if (features.Any())
            {
                lines.Add(new DialogLine(Moods.NORMAL, "Features:"));
            }
            foreach (var feature in features)
            {
                lines.Add(new DialogLine(Moods.NORMAL, $"{feature.Name}"));
            }
        }

        private static void GetRoutesLines(List<IDialogLine> lines, ILocation location)
        {
            var routes = location.Routes;
            if (routes.Any())
            {
                lines.Add(new DialogLine(Moods.NORMAL, "Exits:"));
            }
            foreach (var route in routes)
            {
                lines.Add(new DialogLine(Moods.NORMAL, $"{route.Direction.GetName()}: {route.Name}"));
            }
        }

        public IEnumerable<IDialogLine> GetLines(ICharacter character)
        {
            var location = character.Location;
            var lines = new List<IDialogLine>
            {
                new DialogLine(Moods.NORMAL, "Yer the n00b!"),
                new DialogLine(Moods.NORMAL, $"Yer facing {character.Direction.GetName()}."),
                new DialogLine(Moods.NORMAL, $"Location: {location.Name}.")
            };
            GetCurrentFeatureLines(lines, character);
            GetFeaturesLines(lines, location);
            GetRoutesLines(lines, location);

            return lines;
        }

        private static void GetCurrentFeatureLines(List<IDialogLine> lines, ICharacter character)
        {
            var feature = character.Feature;
            if (feature == null)
            {
                return;
            }
            lines.Add(new DialogLine(Moods.NORMAL, $"Interacting with: {feature.Name}"));
        }

        public void HandleCommand(ICharacter character, string command)
        {
            if (character.HasMetadata(Metadatas.MODE))
            {
                if (character.GetMetadata(Metadatas.MODE) == Modes.FEATURES)
                {
                    if (Guid.TryParse(command, out Guid featureId))
                    {
                        character.Feature = character.World.GetFeature(featureId);
                        return;
                    }
                }
            }
            Verbs.All[command].Perform(character);
        }

        public void Initialize(ICharacter character)
        {
        }
    }
}
