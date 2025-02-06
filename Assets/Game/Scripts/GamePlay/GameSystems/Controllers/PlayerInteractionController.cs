using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class PlayerInteractionController : ITickable
    {
        private readonly IInteraction _interaction;

        public PlayerInteractionController(IInteraction interaction)
        {
            _interaction = interaction;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                _interaction.Interact();
        }
    }
}