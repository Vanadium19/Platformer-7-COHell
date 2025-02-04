using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class PlayerInteractionController : ITickable
    {
        private readonly IIInteraction _interaction;

        public PlayerInteractionController(IIInteraction interaction)
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