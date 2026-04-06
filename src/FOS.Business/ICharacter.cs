namespace FOS.Business
{
    public interface ICharacter
    {
        Guid CharacterId { get; }
        IWorld World { get; }
    }
}
