using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class CameraController : IInitializable, ILateTickable
    {
        private const string Axis = "Mouse Y";
        
        private readonly float _sensitivity;
        private readonly float _verticalMinAngle;
        private readonly float _verticalMaxAngle;
        
        private Transform _transform;
        private float _verticalAngle;
        private float _horizontalAngle;

        public CameraController(float sensitivity, float verticalMinAngle, float verticalMaxAngle)
        {
            _sensitivity = sensitivity;
            _verticalMinAngle = verticalMinAngle;
            _verticalMaxAngle = verticalMaxAngle;
        }

        public void Initialize()
        {
            _transform = Camera.main.transform;
            _verticalAngle = _transform.localEulerAngles.x;
        }

        public void LateTick()
        {
            Rotate();
        }

        private void Rotate()
        {
            _horizontalAngle = _transform.eulerAngles.y;
            _verticalAngle -= Input.GetAxis(Axis) * _sensitivity;
            _verticalAngle = Mathf.Clamp(_verticalAngle, _verticalMinAngle, _verticalMaxAngle);
            
            _transform.rotation = Quaternion.Euler(_verticalAngle, _horizontalAngle, 0);
        }
    }
}