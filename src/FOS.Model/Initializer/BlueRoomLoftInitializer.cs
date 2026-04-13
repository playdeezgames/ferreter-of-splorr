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
                    blueRoom.CreateRoute(
                        "Ladder to Loft",
                        Directions.UP,
                        l);
                    l.CreateRoute(
                        "Ladder from Loft",
                        Directions.DOWN,
                        blueRoom);
                    l.CreateFeature(
                        "Crate",
                        f =>
                        {
                            f.AppendTrigger(
                                Triggers.SEARCH,
                                TriggerTypes.BESTOW_INVENTORY,
                                t =>
                                {
                                    t.Inventory.CreateItem(
                                            ItemTypes.GOLD,
                                            "Gold Pieces",
                                            i =>
                                            {
                                                i.SetStatistic(StatisticTypes.QUANTITY, 5);
                                            });
                                }).AppendTrigger(
                                    TriggerTypes.ADD_MESSAGE,
                                    t =>
                                    {
                                        t.SetMetadata(Metadatas.MOOD, Moods.NORMAL);
                                        t.SetMetadata(Metadatas.TEXT, "You find a 5 gold pieces!");
                                        t.AppendTrigger(
                                            TriggerTypes.DESTROY_FEATURE_TRIGGER,
                                            dt => dt.SetMetadata(Metadatas.TRIGGER_ID, Triggers.SEARCH));
                                    });
                        });
                });
        }
    }
}
