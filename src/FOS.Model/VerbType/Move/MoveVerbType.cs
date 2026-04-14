using FOS.Business;

namespace FOS.Model
{
    internal abstract class MoveVerbType(string identifier) : IVerbType
    {
        public string Identifier => identifier;
        public bool CanPerform(ICharacter character)
        {
            return
                character.IsInMode(Modes.MOVE) &&
                character.Location.HasRoute(GetDirection(character));
        }
        public abstract string GetText(ICharacter character);
        public abstract string GetDirection(ICharacter character);
        protected abstract string GetSuccessMessage(ICharacter character, IRoute route);
        public void Perform(ICharacter character)
        {
            var route = character.Location.GetRoute(GetDirection(character))!;
            character.AddMessage(Moods.NORMAL, GetSuccessMessage(character, route));
            character.Location = route.Destination;
            character.ClearMode();
        }
    }
}
