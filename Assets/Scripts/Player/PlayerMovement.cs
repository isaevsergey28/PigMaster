using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private JoystickInput _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private MovingSpriteController _movingSpriteController;
    
    private bool _isCanMove = true;
    private float _movementCorrection = 0.05f;
    private void FixedUpdate()
    {
        if(_isCanMove)
        {
            Move();
            UpdateSprite();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out Stone stone))
        {
            if (_movingSpriteController.IsRightSpriteActive() || _movingSpriteController.IsLeftSpriteActive())
            {
                if (other.collider.transform.position.y - transform.position.y > 0)
                {
                    transform.position = 
                        new Vector2(transform.position.x, transform.position.y - _movementCorrection);
                }
                else
                {
                    transform.position = 
                        new Vector2(transform.position.x, transform.position.y + _movementCorrection);
                }
            }
            else if(_movingSpriteController.IsUpSpriteActive() || _movingSpriteController.IsDownSpriteActive())
            {
                if (other.collider.transform.position.x - transform.position.x > 0)
                {
                    transform.position = 
                        new Vector2(transform.position.x - _movementCorrection, transform.position.y);
                }
                else
                {
                    transform.position =
                        new Vector2(transform.position.x + _movementCorrection, transform.position.y);
                }
            }
        }
    }

    private void Move()
    {
        if (Mathf.Abs(_joystick.HorizontalInput) > Mathf.Abs(_joystick.VerticalInput))
        {
            _rigidbody.velocity = 
                new Vector3(_joystick.HorizontalInput, 0).normalized * _moveSpeed;
        }
        else
        {
            _rigidbody.velocity = 
                new Vector3(0, _joystick.VerticalInput).normalized * _moveSpeed;        
        }
    }
    
    private void UpdateSprite()
    {
        if (_joystick.HorizontalInput > 0 && Mathf.Abs(_joystick.HorizontalInput) > Mathf.Abs(_joystick.VerticalInput))
        {
           _movingSpriteController.ChangeSprite(SpriteDirection.Right);
        }
        else if (_joystick.HorizontalInput < 0 && Mathf.Abs(_joystick.HorizontalInput) > Mathf.Abs(_joystick.VerticalInput))
        {
            _movingSpriteController.ChangeSprite(SpriteDirection.Left);
        }
        else if (_joystick.VerticalInput > 0 && Mathf.Abs(_joystick.HorizontalInput) < Mathf.Abs(_joystick.VerticalInput))
        {
            _movingSpriteController.ChangeSprite(SpriteDirection.Up);
        }
        else if (_joystick.VerticalInput < 0 && Mathf.Abs(_joystick.HorizontalInput) < Mathf.Abs(_joystick.VerticalInput))
        {
            _movingSpriteController.ChangeSprite(SpriteDirection.Down);
        }
    }
}