namespace TGGD.Business
{
    public interface IDialogChoice
    {
        public IEnumerable<string> Command { get; }
        public string Text { get; }
    }
}
