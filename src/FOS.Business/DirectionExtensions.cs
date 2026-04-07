using FOS.Data;

namespace FOS.Business
{
    public static class DirectionExtensions
    {
        public static string GetName(this Direction direction)
        {
            return direction switch
            {
                Direction.NORTH => "North",
                Direction.EAST => "East",
                Direction.SOUTH => "South",
                Direction.WEST => "West",
                _ => throw new NotImplementedException(),
            };
        }
        public static Direction GetPreviousDirection(this Direction direction)
        {
            return direction switch
            {
                Direction.NORTH => Direction.WEST,
                Direction.EAST => Direction.NORTH,
                Direction.SOUTH => Direction.EAST,
                Direction.WEST => Direction.SOUTH,
                _ => throw new NotImplementedException(),
            };
        }
        public static Direction GetNextDirection(this Direction direction)
        {
            return direction switch
            {
                Direction.NORTH => Direction.EAST,
                Direction.EAST => Direction.SOUTH,
                Direction.SOUTH => Direction.WEST,
                Direction.WEST => Direction.NORTH,
                _ => throw new NotImplementedException(),
            };
        }
        public static Direction GetOppositeDirection(this Direction direction)
        {
            return direction switch
            {
                Direction.NORTH => Direction.SOUTH,
                Direction.EAST => Direction.WEST,
                Direction.SOUTH => Direction.NORTH,
                Direction.WEST => Direction.EAST,
                _ => throw new NotImplementedException(),
            };
        }

    }
}
