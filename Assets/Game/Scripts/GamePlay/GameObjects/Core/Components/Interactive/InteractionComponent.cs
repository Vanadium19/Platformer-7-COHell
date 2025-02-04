using System.Collections.Generic;

namespace Game.Core.Components
{
    public class InteractionComponent : IInteractionList
    {
        private readonly List<Iinteractable> _interactables = new();

        public void AddInteractable(Iinteractable value)
        {
            if (!_interactables.Contains(value))
                _interactables.Add(value);
        }

        public void RemoveInteractable(Iinteractable value)
        {
            _interactables.Remove(value);
        }

        public void Interact()
        {
            _interactables.ForEach(interactable => interactable.Interact());
        }
    }
}