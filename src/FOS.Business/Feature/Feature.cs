using FOS.Data;

namespace FOS.Business
{
    internal class Feature : Entity<FeatureData>, IFeature
    {
        private readonly WorldData _data;
        private readonly Guid _featureId;
        internal Feature(WorldData data, Guid featureId)
        {
            _data = data;
            _featureId = featureId;
        }

        public Guid FeatureId => _featureId;

        public string Name => GetEntityData().Name;

        internal override FeatureData GetEntityData()
        {
            return _data.Features[_featureId];
        }
    }
}
