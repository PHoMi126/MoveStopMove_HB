using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Character
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick _joystick;

    [SerializeField] private float _moveSpeed;

    private AnimType currentAnimName = AnimType.Idle;

    public enum AnimType
    {
        Idle, Run, Dance
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ChangeAnimation(AnimType.Run);
            _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
            transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotationSpeed, 0));
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ChangeAnimation(AnimType.Idle);
            _rigidbody.velocity = Vector3.zero;
        }
    }
}
