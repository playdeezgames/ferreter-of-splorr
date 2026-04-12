namespace FOS.Model
{
    internal class WestDirectionType : IDirectionType
    {
        public string Identifier => Directions.WEST;

        public string Name => "West";

        public bool IsCardinal => true;

        public string Next => Directions.NORTH;

        public string Previous => Directions.SOUTH;

        public string Opposite => Directions.EAST;

        public int GetNextColumn(int column) => column - 1;

        public int GetNextRow(int row) => row;
    }
}