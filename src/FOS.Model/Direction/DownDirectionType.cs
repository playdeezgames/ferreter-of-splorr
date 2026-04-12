namespace FOS.Model
{
    internal class DownDirectionType : IDirectionType
    {
        public string Identifier => Directions.DOWN;

        public string Name => "Down";

        public bool IsCardinal => false;

        public string Next => Directions.DOWN;

        public string Previous => Directions.DOWN;

        public string Opposite => Directions.UP;

        public int GetNextColumn(int column)
        {
            return column;
        }

        public int GetNextRow(int row)
        {
            return row;
        }
    }
}