using FOS.Business;

namespace FOS.Model
{
    internal class SpawnCreatureTriggerType : ITriggerType
    {
        public string Identifier => TriggerTypes.SPAWN_CREATURE;

        public void Fire(ITrigger trigger, ICharacter character)
        {
            SpawnCreature(character.Location, trigger.GetMetadata(Metadatas.CREATURE_TYPE));
        }

        private static readonly IReadOnlyDictionary<string, Action<ILocation>> creatureGenerator =
            new Dictionary<string, Action<ILocation>>
            {
                [CreatureTypes.CELLAR_RAT] = l => l.CreateCharacter("Cellar Rat", Directions.NORTH, InitializeCellarRat)
            };

        private static void InitializeCellarRat(ICharacter character)
        {
            character.SetTag(CharacterTags.ENEMY);
            character.InitializeHealth(1);
        }

        private static void SpawnCreature(ILocation location, string creatureType)
        {
            creatureGenerator[creatureType](location);
        }
    }
}