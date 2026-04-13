using FOS.Business;
using TGGD.Business;

namespace FOS.Model.Initializer
{
    internal static class JusdatipInnInitializer
    {
        internal static void Run(IWorld world, List<ILocation> town)
        {
            world.CreateLocation(
                "Jusdatip Inn",
                jil =>
                {
                    var jitl = RNG.FromEnumerable(town.Where(x => !x.HasRoute(Directions.IN)));
                    town.Remove(jitl);
                    jitl.CreateFeature(
                        "Inn Sign",
                        f =>
                        {
                            f.
                                AppendTrigger(
                                    Triggers.EXAMINE,
                                    TriggerTypes.ADD_MESSAGE,
                                    t =>
                                    {
                                        t.SetMetadata(Metadatas.MOOD, Moods.NORMAL);
                                        t.SetMetadata(Metadatas.TEXT, "Justdatip Inn");
                                    }).
                                AppendTrigger(
                                    TriggerTypes.ADD_MESSAGE,
                                    t =>
                                    {
                                        t.SetMetadata(Metadatas.MOOD, Moods.NORMAL);
                                        t.SetMetadata(Metadatas.TEXT, "Gorachan, Proprietor");
                                    });
                        });
                    jitl.CreateRoute(
                        "Inn Entrance",
                        Directions.IN,
                        jil);
                    jil.CreateRoute(
                        "Inn Exit",
                        Directions.OUT,
                        jitl);
                    jil.CreateCharacter(
                        Directions.SOUTH,
                        gc =>
                        {
                            //TODO: this is Gorachan
                        });
                    world.CreateLocation(
                        "Inn Cellar",
                        icl =>
                        {
                            jil.CreateRoute(
                                "Stairs to Cellar",
                                Directions.DOWN,
                                icl);
                            icl.CreateRoute(
                                "Stairs from Cellar",
                                Directions.UP,
                                jil);
                        });
                });
        }
    }
}
