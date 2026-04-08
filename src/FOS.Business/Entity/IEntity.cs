namespace FOS.Business
{
    public interface IEntity
    {
        void SetStatistic(string statisticTypeId, int statisticValue);
        int GetStatistic(string statisticTypeId);
    }
}