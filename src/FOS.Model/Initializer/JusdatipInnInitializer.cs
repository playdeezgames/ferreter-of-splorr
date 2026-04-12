using FOS.Business;
using TGGD.Business;

namespace FOS.Model.Initializer
{
    internal static class JusdatipInnInitializer
    {
        internal static void Run(IWorld world, List<ILocation> town)
        {
            world.CreateLocation(
                "Justdatip Inn",
                jil =>
                {
                    var jitl = RNG.FromEnumerable(town.Where(x => !x.HasRoute(Directions.IN)));
                    town.Remove(jitl);
                    world.CreateRoute(
                        "Inn Entrance",
                        Directions.IN,
                        jitl,
                        jil);
                    world.CreateRoute(
                        "Inn Exit",
                        Directions.OUT,
                        jil,
                        jitl);

                });
        }
    }
}
