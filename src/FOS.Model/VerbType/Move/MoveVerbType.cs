using FOS.Business;

namespace FOS.Model
{
    internal class MoveVerbType(
        string identifier,
        Func<ICharacter, string> getText,
        Func<ICharacter, string> getDirection,
        Func<ICharacter, IRoute, string> getSuccessMessage,
        Func<ICharacter, IRoute, string> getFailureMessage) : IVerbType
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
        public void Perform(ICharacter character, params string[] parameters)
        {
            var route = character.Location.GetRoute(getDirection(character))!;
            if (route.Allows(character))
            {
                character.AddMessage(Moods.NORMAL, getSuccessMessage(character, route));
                character.Location = route.Destination;
                character.ClearMode();
            }
            else
            {
                character.AddMessage(Moods.NORMAL, getFailureMessage(character, route));
            }
        }
    }
}
