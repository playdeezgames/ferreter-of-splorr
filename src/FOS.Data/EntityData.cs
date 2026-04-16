namespace FOS.Data
{
    public class EntityData
    {
        public Dictionary<string, int> Statistics { get; set; } = [];
        public Dictionary<string, int> StatisticMinimums { get; set; } = [];
        public Dictionary<string, int> StatisticMaximums { get; set; } = [];
        public Dictionary<string, string> Metadatas { get; set; } = [];
        public HashSet<string> Tags { get; set; } = [];
    }
}