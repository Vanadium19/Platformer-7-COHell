namespace Game.Core.Components
{
    public interface IInteractionList
    {
        public void AddInteractable(IInteraction value);
        public void RemoveInteractable(IInteraction value);
    }
}