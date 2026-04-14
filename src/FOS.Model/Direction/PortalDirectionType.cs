namespace FOS.Model
{
    internal class PortalDirectionType : IDirectionType
    {
        public string Identifier => Directions.PORTAL;

        public string Name => "Portal";

        public bool IsCardinal => false;

        public string Next => Directions.PORTAL;

        public string Previous => Directions.PORTAL;

        public string Opposite => Directions.PORTAL;

        public int GetNextColumn(int column) => column;

        public int GetNextRow(int row) => row;
    }
}