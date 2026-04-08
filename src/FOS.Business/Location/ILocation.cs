namespace FOS.Business
{
    public interface ILocation
    {
        Guid LocationId { get; }
        void AddCharacter(ICharacter character);
    }
}
