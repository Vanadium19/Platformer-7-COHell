using System.Collections.Generic;

namespace Game.Core.Components
{
    public class InteractionComponent : IInteractionList, IInteraction
    {
        private readonly List<IInteraction> _interactables = new();

        public void AddInteractable(IInteraction value)
        {
            if (!_interactables.Contains(value))
                _interactables.Add(value);
        }

        public void RemoveInteractable(IInteraction value)
        {
            _interactables.Remove(value);
        }

        public void Interact()
        {
            _interactables.ForEach(interactable => interactable.Interact());
        }
    }
}