using FOS.Data;
using TGGD.Business;

namespace FOS.Business
{
    public static class WorldInitializer
    {
        public static void InitializeWorld(IWorld world)
        {
            TownInitializer.InitializeTown(
                world,
                t =>
                {
                    world.CreateLocation(
                        LocationTypes.BLUE_ROOM,
                        "The Blue Room",
                        tbr =>
                        {
                            var brtl = RNG.FromEnumerable(t.Where(x => !x.HasRoute(Direction.IN)));
                            t.Remove(brtl);
                            world.CreateFeature(FeatureTypes.BED, "Yer Bed", tbr, f =>
                            {
                                f.SetTrigger(Triggers.SEARCH, world.CreateTrigger(
                                    TriggerTypes.BESTOW_INVENTORY,
                                    bit =>
                                    {
                                        bit.Inventory.AddItem(world.CreateItem(ItemTypes.DAGGER));
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
                            world.Avatar = world.CreateCharacter(CharacterTypes.N00B, tbr);
                            world.CreateLocation(
                                LocationTypes.LOFT,
                                "The Loft",
                                l =>
                                {
                                    world.CreateRoute(RouteTypes.LADDER, "Ladder to Loft", Direction.UP, tbr, l);
                                    world.CreateRoute(RouteTypes.LADDER, "Ladder from Loft", Direction.DOWN, l, tbr);
                                });
                            world.CreateRoute(
                                RouteTypes.DOOR,
                                "The Blue Room Entrance",
                                Direction.IN,
                                brtl,
                                tbr);
                            world.CreateRoute(
                                RouteTypes.DOOR,
                                "The Blue Room Exit",
                                Direction.OUT,
                                tbr,
                                brtl);
                        });
                });
        }
    }
}
