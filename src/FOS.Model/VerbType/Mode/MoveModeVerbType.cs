using FOS.Business;

namespace FOS.Model
{
    internal class MoveModeVerbType : IVerbType
    {
        public string Identifier => Verbs.MOVE_MODE;

        public bool CanPerform(ICharacter character)
        {
            return !character.HasMetadata(Metadatas.MODE);
        }

        public string GetText(ICharacter character)
        {
            return "Move...";
        }

        public void Perform(ICharacter character)
        {
            character.SetMetadata(Metadatas.MODE, Modes.MOVE);
        }
    }
}