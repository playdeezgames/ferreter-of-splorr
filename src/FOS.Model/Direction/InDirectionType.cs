namespace FOS.Model
{
    internal class InDirectionType : IDirectionType
    {
        public string Identifier => Directions.IN;

        public string Name => "In";

        public bool IsCardinal => false;

        public string Next => Directions.IN;

        public string Previous => Directions.IN;

        public string Opposite => Directions.OUT;

        public int GetNextColumn(int column) => column;

        public int GetNextRow(int row) => row;
    }
}