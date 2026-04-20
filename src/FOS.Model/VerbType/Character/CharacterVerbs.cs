using FOS.Business;

namespace FOS.Model
{
    internal static class CharacterVerbs
    {
        private static string GetName(string name) => $"{nameof(CharacterVerbs)}.{name}";
        private readonly static string BLUR = GetName(nameof(BLUR));
        private readonly static string FIGHT = GetName(nameof(FIGHT));
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                .. GorachanVerbs.All,
                new VerbType(
                    FIGHT,
                    (x, p)=> !x.IsDead() && x.HasFocusCharacter && x.FocusCharacter!.HasTag(CharacterTags.ENEMY),
                    x=>"Fight!",
                    AttackEnemy),
                new VerbType(
                    BLUR,
                    (x, p) => !x.IsDead() && x.HasFocusCharacter,
                    x => "Characters...",
                    (x, p) => x.FocusCharacter = null)
            ];

        private static void AttackEnemy(ICharacter character, IEnumerable<string> parameters)
        {
            character.Attack(character.FocusCharacter!);
            if (character.HasFocusCharacter)
            {
                character.FocusCharacter!.Attack(character);
            }
        }
    }
}
