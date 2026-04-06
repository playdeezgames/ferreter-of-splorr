namespace FOS.Business
{
    public interface IWorld
    {
        void Clear();
        void Initialize();
        ICharacter CreateCharacter();
        ICharacter? Avatar { get; set; }
    }
}
