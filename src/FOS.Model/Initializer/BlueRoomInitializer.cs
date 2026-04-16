using FOS.Business;
using TGGD.Business;

namespace FOS.Model.Initializer
{
    internal static class BlueRoomInitializer
    {
        internal static void Run(IWorld world, List<ILocation> town, ILocation inn)
        {
            world.CreateLocation(
                "The Blue Room",
                tbr =>
                {
                    tbr.CreateFeature("Yer Bed", f =>
                    {
                        f.AppendTrigger(
                            Triggers.SEARCH,
                                TriggerTypes.BESTOW_INVENTORY,
                                t =>
                                {
                                    t.Inventory.CreateItem(ItemTypes.DAGGER, "Rusty Dagger");
                                }).
                            AppendTrigger(
                                TriggerTypes.ADD_MESSAGE,
                                t =>
                                {
                                    t.SetMetadata(Metadatas.MOOD, Moods.NORMAL);
                                    t.SetMetadata(Metadatas.TEXT, "You find a rusty dagger!");
                                    t.AppendTrigger(
                                        TriggerTypes.DESTROY_FEATURE_TRIGGER,
                                        dt => dt.SetMetadata(Metadatas.TRIGGER_ID, Triggers.SEARCH));
                                });
                    });
                    world.Avatar = tbr.CreateCharacter(
                        "N00b",
                        Directions.NORTH,
                        InitializeN00b);
                    BlueRoomLoftInitializer.Run(world, tbr);
                    var brtl = RNG.FromEnumerable(town.Where(x => !x.HasRoute(Directions.IN)));
                    town.Remove(brtl);
                    brtl.CreateRoute(
                        "The Blue Room Entrance",
                        Directions.IN,
                        tbr);
                    tbr.CreateRoute(
                        "The Blue Room Exit",
                        Directions.OUT,
                        brtl);
#if DEBUG
                    tbr.CreateRoute(
                        "Portal to Inn",
                        Directions.PORTAL,
                        inn);
#endif
                });
        }

        private static void InitializeN00b(ICharacter character)
        {
            character.SetTag(CharacterTags.N00B);
            character.SetStatistic(StatisticTypes.JOOLS, 0);
            character.InitializeHealth(3);
        }
    }
}
