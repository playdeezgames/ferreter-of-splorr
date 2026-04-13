using FOS.Business;
using TGGD.Business;

namespace FOS.Model.Initializer
{
    internal static class BlueRoomInitializer
    {
        internal static void Run(IWorld world, List<ILocation> town)
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
                                    t.Inventory.AddItem(world.CreateItem(ItemTypes.DAGGER, "Rusty Dagger"));
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
                    world.Avatar = tbr.CreateCharacter("N00b", Directions.NORTH, c => c.SetTag(Tags.N00B));
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
                    tbr.CreateCharacter("Yermom", Directions.EAST, ym => { });
                    tbr.CreateCharacter("Nacho Mama", Directions.WEST, nm => { });
#endif
                });
        }
    }
}
