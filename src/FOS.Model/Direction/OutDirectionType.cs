namespace FOS.Model
{
    internal class OutDirectionType : IDirectionType
    {
        public string Identifier => Directions.OUT;

        public string Name => "Out";

        public bool IsCardinal => false;

        public string Next => Directions.OUT;

        public string Previous => Directions.OUT;

        public string Opposite => Directions.IN;

        public int GetNextColumn(int column) => column;

        public int GetNextRow(int row) => row;
    }
}