using UnityEngine;

public class PlayerController : CharacterController
{
    [SerializeField] private Rigidbody _rigidbody;
    public FloatingJoystick _joystick;

    [SerializeField] private float _moveSpeed;

    public void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            ChangeAnimation(AnimState.Run);
            _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
            //CharacterObject.transform.LookAt(new Vector3(_joystick.Vertical, this.transform.position.y, _joystick.Horizontal));

        }
        else if (Input.GetMouseButtonUp(0))
        {
            ChangeAnimation(AnimState.Idle);
            _rigidbody.velocity = Vector3.zero;
        }

        CharacterObject.transform.LookAt(new Vector3(_joystick.Horizontal, this.transform.position.y, _joystick.Vertical));

        /* Vector3 direction = Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal;
        _rigidbody.AddForce(direction * _moveSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        CharacterObject.transform.LookAt(new Vector3(_joystick.Vertical, this.transform.position.y, _joystick.Horizontal)); */
    }
}
