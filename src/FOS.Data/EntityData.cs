namespace FOS.Data
{
    public class EntityData
    {
        public Dictionary<string, int> Statistics { get; set; } = [];
        public Dictionary<string, string> Metadatas { get; set; } = [];
        public HashSet<string> Tags { get; set; } = [];
    }
}