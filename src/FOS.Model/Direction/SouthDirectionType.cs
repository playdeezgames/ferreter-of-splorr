namespace FOS.Model
{
    internal class SouthDirectionType : IDirectionType
    {
        public string Identifier => Directions.SOUTH;

        public string Name => "South";

        public bool IsCardinal => true;

        public string Next => Directions.WEST;

        public string Previous => Directions.EAST;

        public string Opposite => Directions.NORTH;

        public int GetNextColumn(int column) => column;

        public int GetNextRow(int row) => row + 1;
    }
}