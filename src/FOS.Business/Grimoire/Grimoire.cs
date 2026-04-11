namespace FOS.Business
{
    public class Grimoire : IGrimoire
    {
        public ICharacterType GetCharacterType(string characterTypeId)
        {
            return CharacterTypes.All[characterTypeId];
        }
    }
}
