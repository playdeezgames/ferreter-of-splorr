namespace FOS.Business
{
    public class Grimoire : IGrimoire
    {
        public void AddMessage(ICharacter character, string mood, string text)
        {
            if (character.HasTag(Tags.N00B))
            {
                character.World.AddMessage(mood, text);
            }
        }
    }
}
