using FOS.Business;
using FOS.Model.Initializer;

namespace FOS.Model
{
    public static class WorldInitializer
    {
        public static void Run(IWorld world)
        {
            TownInitializer.Run(
                world,
                t =>
                {
                    var inn = JusdatipInnInitializer.Run(world, t);
                    BlueRoomInitializer.Run(world, t, inn);
                });
        }
    }
}
