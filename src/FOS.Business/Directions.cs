using FOS.Data;

namespace FOS.Business
{
    public static class Directions
    {
        public static readonly Direction[] Cardinal = [Direction.NORTH, Direction.EAST, Direction.SOUTH, Direction.WEST];
        public static string GetName(this Direction direction)
        {
            return direction switch
            {
                Direction.NORTH => "North",
                Direction.EAST => "East",
                Direction.SOUTH => "South",
                Direction.WEST => "West",
                Direction.DOWN => "Down",
                Direction.UP => "Up",
                Direction.IN => "In",
                Direction.OUT => "Out",
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
                _ => direction,
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
                _ => direction,
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
                Direction.IN => Direction.OUT,
                Direction.OUT => Direction.IN,
                Direction.UP => Direction.DOWN,
                Direction.DOWN => Direction.UP,
                _ => throw new NotImplementedException(),
            };
        }
        public static int GetNextColumn(this Direction direction, int column)
        {
            return direction switch
            {
                Direction.EAST => column + 1,
                Direction.WEST => column - 1,
                _ => column
            };
        }
        public static int GetNextRow(this Direction direction, int row)
        {
            return direction switch
            {
                Direction.NORTH => row - 1,
                Direction.SOUTH => row + 1,
                _ => row
            };
        }
    }
}
