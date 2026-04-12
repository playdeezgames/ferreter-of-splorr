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
                    jitl.CreateFeature(
                        "Inn Sign",
                        f =>
                        {
                            f.SetTrigger(
                                Triggers.EXAMINE,
                                world.CreateTrigger(
                                    TriggerTypes.ADD_MESSAGE,
                                    et =>
                                    {
                                        et.SetMetadata(Metadatas.MOOD, Moods.NORMAL);
                                        et.SetMetadata(Metadatas.TEXT, "Justdatip Inn");
                                        et.NextTrigger = world.CreateTrigger(
                                            TriggerTypes.ADD_MESSAGE,
                                            et2 =>
                                            {
                                                et2.SetMetadata(Metadatas.MOOD, Moods.NORMAL);
                                                et2.SetMetadata(Metadatas.TEXT, "Gorachan, Proprietor");
                                            });
                                    }));
                        });
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
