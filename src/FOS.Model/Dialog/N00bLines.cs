using FOS.Business;
using TGGD.Business;

namespace FOS.Model.Dialog
{
    internal static class N00bLines
    {
        private record LineGenerator(Func<ICharacter, bool> Condition, Func<ICharacter, IEnumerable<IDialogLine>> LineSource);

        private readonly static IEnumerable<LineGenerator> lineGenerators =
            [
                new LineGenerator(x=>true, x=>x.World.Messages.Select(x => new DialogLine(x.Mood, x.Text))),
                new LineGenerator(x=>x.IsDead(), GetDeadLines),
                new LineGenerator(x=>!x.IsDead(), GetLocationLines),
                new LineGenerator(x=>!x.IsDead() && x.HasFocusFeature, GetFocusFeatureLines),
                new LineGenerator(x=>!x.IsDead() && x.HasFocusItem, GetFocusItemLines),
                new LineGenerator(x=>!x.IsDead() && x.HasFocusCharacter, GetFocusCharacterLines),
                new LineGenerator(x=>!x.IsDead() && (!x.HasMode() || (x.IsInMode(Modes.FEATURES) && !x.HasFocusFeature)), GetFeaturesLines),
                new LineGenerator(x=>!x.IsDead() && (!x.HasMode() || (x.IsInMode(Modes.CHARACTERS) && !x.HasFocusCharacter)), GetCharactersLines),
                new LineGenerator(x=>!x.IsDead() && x.IsInMode(Modes.STATISTICS), GetStatisticsLines),
                new LineGenerator(x=>!x.IsDead() && (!x.HasMode() || x.IsInMode(Modes.MOVE)), GetRoutesLines)
            ];

        private static IEnumerable<IDialogLine> GetDeadLines(ICharacter character)
        {
            return [
                new DialogLine(Moods.NORMAL, "Yer dead!")
                ];
        }

        internal static IEnumerable<IDialogLine> GetLines(ICharacter character)
        {
            return lineGenerators.Where(x => x.Condition(character)).Select(x => x.LineSource(character)).SelectMany(x => x);
        }

        private static IEnumerable<IDialogLine> GetFocusCharacterLines(ICharacter character)
        {
            var otherCharacter = character.FocusCharacter!;
            List<IDialogLine> lines = [new DialogLine(Moods.NORMAL, $"Interacting with: {otherCharacter.Name}")];
            if (otherCharacter.HasStatistic(StatisticTypes.HEALTH))
            {
                lines.Add(new DialogLine(Moods.NORMAL, $"Health: {otherCharacter.GetHealth()}/{otherCharacter.GetMaximumHealth()}"));
            }
            return lines.AsEnumerable();
        }

        private static IEnumerable<IDialogLine> GetStatisticsLines(ICharacter character)
        {
            List<IDialogLine> lines =
                [
                    new DialogLine(Moods.NORMAL, $"Jools: {character.GetStatistic(StatisticTypes.JOOLS)}"),
                    new DialogLine(Moods.NORMAL, $"Health: {character.GetHealth()}/{character.GetMaximumHealth()}"),
                    new DialogLine(Moods.NORMAL, $"Attack Dice: {character.GetAttackDice()}(Maximum: {character.GetMaximumAttack()})"),
                    new DialogLine(Moods.NORMAL, $"Defend Dice: {character.GetDefendDice()}(Maximum: {character.GetMaximumDefend()})")
                ];
            return lines.AsEnumerable();
        }

        private static IEnumerable<IDialogLine> GetCharactersLines(ICharacter character)
        {
            List<IDialogLine> lines = [];
            var otherCharacters = character.Location.GetOtherCharacters(character);
            if (otherCharacters.Any())
            {
                lines.Add(new DialogLine(Moods.NORMAL, "Other Characters:"));
            }
            foreach (var otherCharacter in otherCharacters)
            {
                lines.Add(new DialogLine(Moods.NORMAL, $"{otherCharacter.Name}"));
            }
            return lines.AsEnumerable();
        }

        private static IEnumerable<IDialogLine> GetFocusItemLines(ICharacter character)
        {
            var focusItem = character.FocusItem!;
            return [new DialogLine(Moods.NORMAL, $"Interacting with {focusItem.Name}.")];
        }

        private static IEnumerable<DialogLine> GetLocationLines(ICharacter character)
        {
            return
                [
                    new DialogLine(Moods.NORMAL, $"Yer name is {character.Name}!"),
                    new DialogLine(Moods.NORMAL, $"Yer facing {Directions.All[character.Direction].Name}."),
                    new DialogLine(Moods.NORMAL, $"Location: {character.Location.Name}.")
                ];
        }

        private static IEnumerable<IDialogLine> GetFeaturesLines(ICharacter character)
        {
            List<IDialogLine> lines = [];
            var features = character.Location.Features;
            if (features.Any())
            {
                lines.Add(new DialogLine(Moods.NORMAL, "Features:"));
            }
            foreach (var feature in features)
            {
                lines.Add(new DialogLine(Moods.NORMAL, $"{feature.Name}"));
            }
            return lines.AsEnumerable();
        }

        private static IEnumerable<IDialogLine> GetRoutesLines(ICharacter character)
        {
            var routes = character.Location.Routes;
            List<IDialogLine> lines = [];
            if (routes.Any())
            {
                lines.Add(new DialogLine(Moods.NORMAL, "Exits:"));
            }
            foreach (var route in routes)
            {
                lines.Add(new DialogLine(Moods.NORMAL, $"{Directions.All[route.Direction].Name}: {route.Name}"));
            }
            return lines.AsEnumerable();
        }
        private static IEnumerable<IDialogLine> GetFocusFeatureLines(ICharacter character)
        {
            var feature = character.FocusFeature!;
            return [new DialogLine(Moods.NORMAL, $"Interacting with: {feature.Name}")];
        }
    }
}
