using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsivePlatform : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    [SerializeField] private Transform _endPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _delay = 2f;

    private float _timer = 0f;
   
    private Vector3 _initialPosition;
    private Vector3 _targetPosition;
    private bool _isPlayerOnPlatform; 
    private bool _isMovingDown;
   
    private void Start()
    {
        _initialPosition = transform.position;
        _targetPosition = _endPosition.position;
    }

    private void FixedUpdate()
    {
        
        if (_isPlayerOnPlatform && !_isMovingDown)
        {
            
            _timer += Time.fixedDeltaTime;
           
            if (_timer >= _delay)
            {
                _isMovingDown = true;
            }
        }

        
        if (_isMovingDown)
        {
            MovePlatformDown();
        }
        else if (!_isPlayerOnPlatform && transform.position != _initialPosition)
        {
            MovePlatformUp();
        }
    }

    private void MovePlatformDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.fixedDeltaTime);

        if (transform.position == _targetPosition)
        {
            _isMovingDown = false;
        }
    }

    private void MovePlatformUp()
    {

        transform.position = Vector3.MoveTowards(transform.position, _initialPosition, _speed * Time.fixedDeltaTime);

        if (transform.position == _initialPosition)
        {
            _timer = 0f;
            _isMovingDown = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        {
            _isPlayerOnPlatform = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
       
        {
            _isPlayerOnPlatform = false;
        }
    }
}
