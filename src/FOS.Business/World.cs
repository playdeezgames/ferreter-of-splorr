using FOS.Data;

namespace FOS.Business
{
    public class World: IWorld
    {
        protected readonly WorldData _data;

        internal World(WorldData worldData)
        {
            _data = worldData;
        }

        public static IWorld Create(WorldData worldData)
        {
            return new World(worldData);
        }

        public void Embark()
        {
        }
    }
}
