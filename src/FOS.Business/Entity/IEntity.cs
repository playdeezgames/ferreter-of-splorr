namespace FOS.Business
{
    public interface IEntity
    {
        void SetStatistic(string statisticTypeId, int statisticValue);
        void SetStatisticMaximum(string statisticTypeId, int statisticMaximum);
        void SetStatisticMinimum(string statisticTypeId, int statisticMinimum);
        int GetStatistic(string statisticTypeId);
        int GetStatisticMaximum(string statisticTypeId);
        int GetStatisticMinimum(string statisticTypeId);
        int ChangeStatistic(string statisticTypeId, int delta);
        bool HasStatistic(string statisticTypeId);
        bool HasMetadata(string metadataId);
        void SetMetadata(string metadataId, string metadataValue);
        string GetMetadata(string metadataId);
        void ClearMetadata(string metadataId);
        bool HasTag(string tagId);
        void ClearTag(string tagId);
        void SetTag(string tagId);
        IWorld World { get; }
        IGrimoire Grimoire { get; }
    }
}