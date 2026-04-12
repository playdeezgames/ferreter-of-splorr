using FOS.Business;

namespace FOS.Model.Initializer
{
    internal static class BlueRoomLoftInitializer
    {
        internal static void Run(IWorld world, ILocation blueRoom)
        {
            world.CreateLocation(
                "The Loft",
                l =>
                {
                    world.CreateRoute("Ladder to Loft", Directions.UP, blueRoom, l);
                    world.CreateRoute("Ladder from Loft", Directions.DOWN, l, blueRoom);
                    l.CreateFeature(
                        "Crate",
                        f =>
                        {
                            f.SetTrigger(
                                Triggers.SEARCH,
                                world.CreateTrigger(
                                    TriggerTypes.BESTOW_INVENTORY,
                                    bit =>
                                    {
                                        bit.Inventory.AddItem(
                                            world.CreateItem(
                                                ItemTypes.GOLD,
                                                "Gold Pieces",
                                                i =>
                                                {
                                                    i.SetStatistic(StatisticTypes.QUANTITY, 5);
                                                }));
                                        bit.NextTrigger = world.CreateTrigger(
                                            TriggerTypes.ADD_MESSAGE,
                                            mt =>
                                            {
                                                mt.SetMetadata(Metadatas.MOOD, Moods.NORMAL);
                                                mt.SetMetadata(Metadatas.TEXT, "You find a 5 gold pieces!");
                                                mt.NextTrigger = world.CreateTrigger(
                                                    TriggerTypes.DESTROY_FEATURE_TRIGGER,
                                                    dt => dt.SetMetadata(Metadatas.TRIGGER_ID, Triggers.SEARCH));
                                            });
                                    }));
                        });
                });
        }
    }
}
