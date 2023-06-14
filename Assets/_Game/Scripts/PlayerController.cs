using UnityEngine;

public class PlayerController : CharacterController
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] FloatingJoystick _joystick;

    [SerializeField] float _moveSpeed;

    public void FixedUpdate()
    {
        if (_joystick != null)
        {
            if (Input.GetMouseButton(0))
            {
                ChangeAnimation(AnimState.Run);
                _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

            }
            else if (Input.GetMouseButtonUp(0))
            {
                ChangeAnimation(AnimState.Idle);
                _rigidbody.velocity = Vector3.zero;
            }
        }
    }
}