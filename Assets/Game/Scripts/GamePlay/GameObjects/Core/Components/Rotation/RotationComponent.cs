using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class RotationComponent : IRotater
    {
        private readonly Transform _transform;
        private readonly float _sensitivity;

        private float _horizontalAngle;

        public RotationComponent(Transform transform, float sensitivity)
        {
            _transform = transform;
            _sensitivity = sensitivity;
        }

        public void Rotate(float angle)
        {
            _horizontalAngle += _sensitivity * angle;

            _transform.rotation = Quaternion.Euler(0, _horizontalAngle, 0);
        }
    }
}