using FOS.Business;
using TGGD.Business;

namespace FOS.Model.Dialog
{
    internal static class N00bChoices
    {
        private record ChoiceGenerator(
            Func<ICharacter, bool> Condition,
            Func<ICharacter, IEnumerable<IDialogChoice>> ChoiceSource);

        private readonly static IEnumerable<ChoiceGenerator> choiceGenerators =
            [
                new ChoiceGenerator(
                    x=>
                        x.HasMode() &&
                        x.GetMode() == Modes.FEATURES &&
                        !x.HasFocusFeature,
                    x=>
                        x.Location.
                            Features.
                            Select(x =>
                                new DialogChoice(
                                    [FeatureVerbs.FOCUS_FEATURE, x.FeatureId.ToString()],
                                    x.Name))),
                new ChoiceGenerator(
                    x=>
                        x.HasMode() &&
                        x.GetMode() == Modes.INVENTORY &&
                        !x.HasFocusItem,
                    x=>
                        x.Inventory.
                            Items.
                            Select(x =>
                                new DialogChoice(
                                    [ItemVerbs.FOCUS_ITEM, x.ItemId.ToString()],
                                    x.Name))),
                new ChoiceGenerator(
                    x=>
                        x.HasMode() &&
                        x.GetMode() == Modes.GROUND_INVENTORY &&
                        !x.HasFocusItem,
                    x=>
                        x.Location.
                            Inventory.
                            Items.
                            Select(x =>
                                new DialogChoice(
                                    [ItemVerbs.FOCUS_ITEM, x.ItemId.ToString()],
                                    x.Name))),
                new ChoiceGenerator(
                    x=>
                        x.HasMode() &&
                        x.GetMode() == Modes.CHARACTERS &&
                        !x.HasFocusCharacter,
                    x=>
                        x.Location.
                            GetOtherCharacters(x).
                            Select(y =>
                                new DialogChoice(
                                    [CharacterVerbs.FOCUS_CHARACTER, y.CharacterId.ToString()],
                                    y.Name))),
                new ChoiceGenerator(
                    x=> true,
                    x=>
                        Verbs.All.
                            Where(y =>
                                y.Value.
                                    CanPerform(x)).
                                    Select(z =>
                                        new DialogChoice(
                                            [z.Key],
                                            z.Value.GetText(x))))
            ];

        internal static IEnumerable<IDialogChoice> GetChoices(ICharacter character)
        {
            return choiceGenerators.
                Where(y =>
                y.Condition(character)).
                    Select(z =>
                        z.ChoiceSource(character)).
                            SelectMany(x => x);
        }
    }
}
