using FOS.Data;

namespace FOS.Business
{
    internal class Character : ICharacter
    {
        private readonly WorldData _data;
        private readonly Guid _characterId;

        internal Character(WorldData data, Guid characterId)
        {
            _data = data;
            _characterId = characterId;
        }

        public Guid CharacterId => _characterId;

        public IWorld World => new World(_data);
    }
}
