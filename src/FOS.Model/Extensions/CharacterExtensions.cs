using FOS.Business;

namespace FOS.Model
{
    internal static class CharacterExtensions
    {
        internal static void AddMessage(this ICharacter character, string mood, string text)
        {
            if (character.HasTag(CharacterTags.N00B))
            {
                character.World.AddMessage(mood, text);
            }
        }

    }
}
