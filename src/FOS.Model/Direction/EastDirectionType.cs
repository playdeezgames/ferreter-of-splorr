namespace FOS.Model
{
    internal class EastDirectionType : IDirectionType
    {
        public string Identifier => Directions.EAST;

        public string Name => "East";

        public bool IsCardinal => true;

        public string Next => Directions.SOUTH;

        public string Previous => Directions.NORTH;

        public string Opposite => Directions.WEST;

        public int GetNextColumn(int column)
        {
            return column + 1;
        }

        public int GetNextRow(int row)
        {
            return row;
        }
    }
}