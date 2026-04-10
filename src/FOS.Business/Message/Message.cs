using FOS.Data;

namespace FOS.Business
{
    internal class Message(WorldData data, int index) : IMessage
    {
        public string Mood => data.Messages[index].Mood;

        public string Text => data.Messages[index].Text;
    }
}
