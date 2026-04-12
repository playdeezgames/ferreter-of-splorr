namespace FOS.Model
{
    internal class UpDirectionType : IDirectionType
    {
        public string Identifier => Directions.UP;

        public string Name => "Up";

        public bool IsCardinal => false;

        public string Next => Directions.UP;

        public string Previous => Directions.UP;

        public string Opposite => Directions.DOWN;

        public int GetNextColumn(int column) => column;

        public int GetNextRow(int row) => row;
    }
}