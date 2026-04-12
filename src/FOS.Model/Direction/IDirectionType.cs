namespace FOS.Model
{
    internal interface IDirectionType
    {
        string Identifier { get; }
        string Name { get; }
        bool IsCardinal { get; }
        string Next { get; }
        string Previous { get; }
        string Opposite { get; }
        int GetNextColumn(int column);
        int GetNextRow(int row);
    }
}
