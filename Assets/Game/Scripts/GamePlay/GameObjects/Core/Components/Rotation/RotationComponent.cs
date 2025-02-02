using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class RotationComponent : ITickable
    {
        private const string Axis = "Mouse X";
        
        private readonly Transform _transform;
        private readonly float _sensitivity;
        
        private float _horizontalAngle;

        public RotationComponent(Transform transform, float sensitivity)
        {
            _transform = transform;
            _sensitivity = sensitivity;
        }

        public void Tick()
        {
            Rotate();
        }

        private void Rotate()
        {
            _horizontalAngle += _sensitivity * Input.GetAxis(Axis);

            _transform.rotation = Quaternion.Euler(0, _horizontalAngle, 0);
        }
    }
}