using FOS.Business;

namespace FOS.Model
{
    internal abstract class MoveVerbType(
        string identifier,
        Func<ICharacter, string> getText,
        Func<ICharacter, string> getDirection) : IVerbType
    {
        public string Identifier => identifier;
        public bool CanPerform(ICharacter character, params string[] parameters)
        {
            return
                !character.IsDead() &&
                character.IsInMode(Modes.MOVE) &&
                character.Location.HasRoute(getDirection(character));
        }
        public string GetText(ICharacter character)
        {
            return getText(character);
        }
        protected abstract string GetSuccessMessage(ICharacter character, IRoute route);
        protected abstract string GetFailureMessage(ICharacter character, IRoute route);
        public void Perform(ICharacter character, params string[] parameters)
        {
            var route = character.Location.GetRoute(getDirection(character))!;
            if (route.Allows(character))
            {
                character.AddMessage(Moods.NORMAL, GetSuccessMessage(character, route));
                character.Location = route.Destination;
                character.ClearMode();
            }
            else
            {
                character.AddMessage(Moods.NORMAL, GetFailureMessage(character, route));
            }
        }
    }
}
