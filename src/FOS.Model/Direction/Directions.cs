using FOS.Data;

namespace FOS.Model
{
    public static class Directions
    {
        internal static readonly string NORTH = nameof(NORTH);
        internal static readonly string EAST = nameof(EAST);
        internal static readonly string SOUTH = nameof(SOUTH);
        internal static readonly string WEST = nameof(WEST);
        internal static readonly string UP = nameof(UP);
        internal static readonly string DOWN = nameof(DOWN);
        internal static readonly string IN = nameof(IN);
        internal static readonly string OUT = nameof(OUT);
        internal static IReadOnlyDictionary<string, IDirectionType> All =
            new List<IDirectionType>
            {
                new NorthDirectionType(),
                new EastDirectionType(),
                new SouthDirectionType(),
                new WestDirectionType(),
                new UpDirectionType(),
                new DownDirectionType(),
                new InDirectionType(),
                new OutDirectionType()
            }.ToDictionary(x => x.Identifier, x => x);
        ////////////////////
        public static readonly Direction[] Cardinal = [Direction.NORTH, Direction.EAST, Direction.SOUTH, Direction.WEST];
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
