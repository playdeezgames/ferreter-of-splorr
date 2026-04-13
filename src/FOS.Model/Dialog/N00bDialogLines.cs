using FOS.Business;
using TGGD.Business;

namespace FOS.Model.Dialog
{
    internal static class N00bDialogLines
    {
        internal static IEnumerable<IDialogLine> GetLines(ICharacter character)
        {
            return
                [
                    .. character.World.Messages.Select(x => new DialogLine(x.Mood, x.Text)),
                    .. GetLocationLines(character),
                    .. GetFocusFeatureLines(character),
                    .. GetFocusItemLines(character),
                    .. GetFeaturesLines(character),
                    .. GetRoutesLines(character)
                ];
        }

        private static IEnumerable<IDialogLine> GetFocusItemLines(ICharacter character)
        {
            var focusItem = character.FocusItem;
            if (focusItem == null)
            {
                return [];
            }
            return [new DialogLine(Moods.NORMAL, $"Interacting with {focusItem.Name}.")];
        }

        private static IEnumerable<DialogLine> GetLocationLines(ICharacter character)
        {
            return
                [
                    new DialogLine(Moods.NORMAL, "Yer the n00b!"),
                    new DialogLine(Moods.NORMAL, $"Yer facing {character.Grimoire.GetDirectionName(character.Direction)}."),
                    new DialogLine(Moods.NORMAL, $"Location: {character.Location.Name}.")
                ];
        }

        private static IEnumerable<IDialogLine> GetFeaturesLines(ICharacter character)
        {
            if (character.HasMetadata(Metadatas.MODE) && character.GetMetadata(Metadatas.MODE) != Modes.FEATURES)
            {
                return [];
            }
            List<IDialogLine> lines = new();
            var features = character.Location.Features;
            if (features.Any())
            {
                lines.Add(new DialogLine(Moods.NORMAL, "Features:"));
            }
            foreach (var feature in features)
            {
                lines.Add(new DialogLine(Moods.NORMAL, $"{feature.Name}"));
            }
            return lines;
        }

        private static IEnumerable<IDialogLine> GetRoutesLines(ICharacter character)
        {
            if (character.HasMetadata(Metadatas.MODE) && character.GetMetadata(Metadatas.MODE) != Modes.MOVE)
            {
                return [];
            }
            var routes = character.Location.Routes;
            List<IDialogLine> lines = new();
            if (routes.Any())
            {
                lines.Add(new DialogLine(Moods.NORMAL, "Exits:"));
            }
            foreach (var route in routes)
            {
                lines.Add(new DialogLine(Moods.NORMAL, $"{route.GetDirectionName()}: {route.Name}"));
            }
            return lines;
        }
        private static IEnumerable<IDialogLine> GetFocusFeatureLines(ICharacter character)
        {
            var feature = character.FocusFeature;
            if (feature == null)
            {
                return [];
            }
            return [new DialogLine(Moods.NORMAL, $"Interacting with: {feature.Name}")];
        }
    }
}
