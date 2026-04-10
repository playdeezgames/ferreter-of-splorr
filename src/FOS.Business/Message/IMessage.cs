namespace FOS.Business
{
    public interface IMessage
    {
        string Mood { get; }
        string Text { get; }
    }
}
