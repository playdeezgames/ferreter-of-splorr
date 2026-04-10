using FOS.Business.Initializer;

namespace FOS.Business
{
    public static class WorldInitializer
    {
        public static void Run(IWorld world)
        {
            TownInitializer.Run(
                world,
                t =>
                {
                    BlueRoomInitializer.Run(world, t);
                });
        }
    }
}
