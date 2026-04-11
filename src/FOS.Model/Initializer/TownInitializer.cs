using FOS.Business;

namespace FOS.Model
{
    internal static class TownInitializer
    {
        internal static void Run(IWorld world, Action<List<ILocation>> initializer)
        {
            const int TOWN_COLUMNS = 3;
            const int TOWN_ROWS = 3;
            var town = new List<ILocation>();
            foreach (var column in Enumerable.Range(0, TOWN_COLUMNS))
            {
                foreach (var row in Enumerable.Range(0, TOWN_ROWS))
                {
                    var townLocation = world.CreateLocation(
                        $"Town Location ({column},{row})",
                        tl =>
                        {
                            tl.SetStatistic(StatisticTypes.COLUMN, column);
                            tl.SetStatistic(StatisticTypes.ROW, row);
                            town.Add(tl);
                        });
                }
            }
            foreach (var townLocation in town)
            {
                var column = townLocation.GetStatistic(StatisticTypes.COLUMN);
                var row = townLocation.GetStatistic(StatisticTypes.ROW);
                foreach (var direction in Directions.Cardinal)
                {
                    var nextColumn = direction.GetNextColumn(column);
                    var nextRow = direction.GetNextRow(row);
                    if (nextColumn >= 0 && nextRow >= 0 && nextColumn < TOWN_COLUMNS && nextRow < TOWN_ROWS)
                    {
                        var nextTownLocation =
                            town.Single(x =>
                                x.GetStatistic(StatisticTypes.COLUMN) == nextColumn &&
                                x.GetStatistic(StatisticTypes.ROW) == nextRow);
                        world.CreateRoute(
                            $"Road to {nextTownLocation.Name}",
                            direction,
                            townLocation,
                            nextTownLocation);
                    }
                }
            }
            initializer.Invoke(town);
        }
    }
}
