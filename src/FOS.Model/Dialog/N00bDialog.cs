using FOS.Business;
using TGGD.Business;

namespace FOS.Model.Dialog
{
    internal static class N00bDialog
    {
        internal static IEnumerable<IDialogChoice> GetChoices(ICharacter character)
        {
            var choices = new List<IDialogChoice>();
            AddFeaturesChoices(choices, character);
            AddInventoryChoices(choices, character);
            AddGroundInventoryChoices(choices, character);
            AddVerbChoices(choices, character);
            return choices;
        }
        private static void AddGroundInventoryChoices(List<IDialogChoice> choices, ICharacter character)
        {
            if (character.HasMetadata(Metadatas.MODE) && !character.HasFocusItem)
            {
                if (character.GetMetadata(Metadatas.MODE) == Modes.GROUND_INVENTORY)
                {
                    foreach (var item in character.Location.Inventory.Items)
                    {
                        choices.Add(new DialogChoice(item.ItemId.ToString(), item.Name));
                    }
                }
            }
        }

        private static void AddInventoryChoices(List<IDialogChoice> choices, ICharacter character)
        {
            if (character.HasMetadata(Metadatas.MODE) && !character.HasFocusItem)
            {
                if (character.GetMetadata(Metadatas.MODE) == Modes.INVENTORY)
                {
                    foreach (var item in character.Inventory.Items)
                    {
                        choices.Add(new DialogChoice(item.ItemId.ToString(), item.Name));
                    }
                }
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
            if (character.HasMetadata(Metadatas.MODE) && !character.HasFocusFeature)
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
        internal static IEnumerable<IDialogLine> GetLines(ICharacter character)
        {
            var lines = new List<IDialogLine>();
            lines.AddRange(character.World.Messages.Select(x => new DialogLine(x.Mood, x.Text)));
            GetLocationLines(lines, character);
            GetCurrentFeatureLines(lines, character);
            GetFeaturesLines(lines, character);
            GetRoutesLines(lines, character);
            return lines;
        }

        private static void GetLocationLines(List<IDialogLine> lines, ICharacter character)
        {
            lines.AddRange(
                [
                    new DialogLine(Moods.NORMAL, "Yer the n00b!"),
                    new DialogLine(Moods.NORMAL, $"Yer facing {character.Grimoire.GetDirectionName(character.Direction)}."),
                    new DialogLine(Moods.NORMAL, $"Location: {character.Location.Name}.")
                ]);
        }

        private static void GetFeaturesLines(List<IDialogLine> lines, ICharacter character)
        {
            if (character.HasMetadata(Metadatas.MODE) && character.GetMetadata(Metadatas.MODE) != Modes.FEATURES)
            {
                return;
            }
            var features = character.Location.Features;
            if (features.Any())
            {
                lines.Add(new DialogLine(Moods.NORMAL, "Features:"));
            }
            foreach (var feature in features)
            {
                lines.Add(new DialogLine(Moods.NORMAL, $"{feature.Name}"));
            }
        }

        private static void GetRoutesLines(List<IDialogLine> lines, ICharacter character)
        {
            if (character.HasMetadata(Metadatas.MODE) && character.GetMetadata(Metadatas.MODE) != Modes.MOVE)
            {
                return;
            }
            var routes = character.Location.Routes;
            if (routes.Any())
            {
                lines.Add(new DialogLine(Moods.NORMAL, "Exits:"));
            }
            foreach (var route in routes)
            {
                lines.Add(new DialogLine(Moods.NORMAL, $"{route.GetDirectionName()}: {route.Name}"));
            }
        }
        private static void GetCurrentFeatureLines(List<IDialogLine> lines, ICharacter character)
        {
            var feature = character.FocusFeature;
            if (feature == null)
            {
                return;
            }
            lines.Add(new DialogLine(Moods.NORMAL, $"Interacting with: {feature.Name}"));
        }
        internal static string GetPrompt(ICharacter character)
        {
            if (!character.HasMetadata(Metadatas.MODE))
            {
                return "Now What?";
            }
            if (character.GetMetadata(Metadatas.MODE) == Modes.MOVE)
            {
                return "Move how?";
            }
            else if (character.GetMetadata(Metadatas.MODE) == Modes.TURN)
            {
                return "Turn how?";
            }
            else if (character.GetMetadata(Metadatas.MODE) == Modes.INVENTORY)
            {
                if (character.HasFocusItem)
                {
                    return $"Interact with {character.FocusItem!.Name}...";
                }
                else
                {
                    return "Inventory:";
                }
            }
            else if (character.GetMetadata(Metadatas.MODE) == Modes.GROUND_INVENTORY)
            {
                if (character.HasFocusItem)
                {
                    return $"Interact with {character.FocusItem!.Name}...";
                }
                else
                {
                    return "Ground Inventory:";
                }
            }
            else if (character.GetMetadata(Metadatas.MODE) == Modes.FEATURES)
            {
                if (character.HasFocusFeature)
                {
                    return $"Interact with {character.FocusFeature!.Name}...";
                }
                else
                {
                    return "Which Feature?";
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        internal static void HandleCommand(ICharacter character, string command)
        {
            character.World.ClearMessages();
            if (character.HasMetadata(Metadatas.MODE))
            {
                var mode = character.GetMetadata(Metadatas.MODE);
                if (mode == Modes.FEATURES)
                {
                    if (Guid.TryParse(command, out Guid featureId))
                    {
                        character.FocusFeature = character.World.GetFeature(featureId);
                        return;
                    }
                }
                else if (mode == Modes.INVENTORY || mode == Modes.GROUND_INVENTORY)
                {
                    if (Guid.TryParse(command, out Guid itemId))
                    {
                        character.FocusItem = character.World.GetItem(itemId);
                        return;
                    }
                }
            }
            Verbs.All[command].Perform(character);
        }
    }
}
