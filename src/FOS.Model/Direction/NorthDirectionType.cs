namespace FOS.Model
{
    internal class NorthDirectionType : IDirectionType
    {
        public string Identifier => Directions.NORTH;

        public string Name => "North";

        public bool IsCardinal => true;

        public string Next => Directions.EAST;

        public string Previous => Directions.WEST;

        public string Opposite => Directions.SOUTH;

        public int GetNextColumn(int column) => column;

        public int GetNextRow(int row) => row - 1;
    }
}