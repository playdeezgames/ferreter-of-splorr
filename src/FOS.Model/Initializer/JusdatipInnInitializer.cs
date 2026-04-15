using FOS.Business;
using TGGD.Business;

namespace FOS.Model.Initializer
{
    internal static class JusdatipInnInitializer
    {
        internal static ILocation Run(IWorld world, List<ILocation> town)
        {
            return world.CreateLocation(
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
                        "Gorachan",
                        Directions.SOUTH,
                        InitializeGorachan);
                    world.CreateLocation(
                        "Inn Cellar",
                        InitializeCellar(jil));
                });
        }

        private static Action<ILocation>? InitializeCellar(ILocation innLocation)
        {
            return cellarLocation =>
            {
                innLocation.CreateRoute(
                    "Stairs to Cellar",
                    Directions.DOWN,
                    cellarLocation,
                    r => r.SetTag(QuestTags.INN_RATS_ACCEPTED));
                cellarLocation.CreateRoute(
                    "Stairs from Cellar",
                    Directions.UP,
                    innLocation);
                cellarLocation.AppendTrigger(
                    Triggers.SEARCH,
                    TriggerTypes.ADD_MESSAGE,
                    t =>
                    {
                        t.SetTag(TriggerTags.BLOCK_WHEN_OTHER_CHARACTERS);
                        t.SetMetadata(Metadatas.BLOCK_MOOD, Moods.NORMAL);
                        t.SetMetadata(Metadatas.BLOCK_TEXT, "You cannot search at this time!");
                        t.SetMetadata(Metadatas.MOOD, Moods.NORMAL);
                        t.SetMetadata(Metadatas.TEXT, "You search the cellar!");
                    }).AppendTrigger(
                        TriggerTypes.SPAWN_CREATURE,
                        t =>
                        {
                            t.SetTag(TriggerTags.BLOCK_WHEN_OTHER_CHARACTERS);
                            t.SetMetadata(Metadatas.CREATURE_TYPE, CreatureTypes.CELLAR_RAT);
                        }
                    );
            };
        }

        private static void InitializeGorachan(ICharacter character)
        {
            character.SetTag(CharacterTags.GORACHAN);
        }
    }
}
