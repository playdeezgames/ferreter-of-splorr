using FOS.Business;
using FOS.Data;
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
                    world.CreateFeature("Yer Bed", tbr, f =>
                    {
                        f.SetTrigger(
                            Triggers.SEARCH,
                            world.CreateTrigger(
                                TriggerTypes.BESTOW_INVENTORY,
                                bit =>
                                {
                                    bit.Inventory.AddItem(world.CreateItem(ItemTypes.DAGGER, "Rusty Dagger"));
                                    bit.NextTrigger = world.CreateTrigger(
                                        TriggerTypes.ADD_MESSAGE,
                                        mt =>
                                        {
                                            mt.SetMetadata(Metadatas.MOOD, Moods.NORMAL);
                                            mt.SetMetadata(Metadatas.TEXT, "You find a rusty dagger!");
                                            mt.NextTrigger = world.CreateTrigger(
                                                TriggerTypes.DESTROY_FEATURE_TRIGGER,
                                                dt => dt.SetMetadata(Metadatas.TRIGGER_ID, Triggers.SEARCH));
                                        });
                                }));
                    });
                    world.Avatar = world.CreateCharacter(tbr, c => c.SetTag(Tags.N00B));
                    world.CreateLocation(
                        "The Loft",
                        l =>
                        {
                            world.CreateRoute("Ladder to Loft", Direction.UP, tbr, l);
                            world.CreateRoute("Ladder from Loft", Direction.DOWN, l, tbr);
                        });
                    var brtl = RNG.FromEnumerable(town.Where(x => !x.HasRoute(Direction.IN)));
                    town.Remove(brtl);
                    world.CreateRoute(
                        "The Blue Room Entrance",
                        Direction.IN,
                        brtl,
                        tbr);
                    world.CreateRoute(
                        "The Blue Room Exit",
                        Direction.OUT,
                        tbr,
                        brtl);
                });
        }
    }
}
