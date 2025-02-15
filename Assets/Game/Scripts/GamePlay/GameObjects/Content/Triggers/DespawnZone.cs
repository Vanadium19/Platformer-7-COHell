using System;
using Game.Content.Environment;
using Game.Core;
using UnityEngine;

namespace Game.Content.Triggers
{
    public class DespawnZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity) && entity.TryGet(out Box box))
                box.Remove();
        }
    }
}