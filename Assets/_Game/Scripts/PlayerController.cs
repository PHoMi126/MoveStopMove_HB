using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : CharacterController
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick _joystick;

    [SerializeField] private float _moveSpeed;

    public Transform target;

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            ChangeAnimation(AnimType.Run);
            _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ChangeAnimation(AnimType.Idle);
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "AI")
        {
            transform.LookAt(target);
            ChangeAnimation(AnimType.Attack);
        }
    }
}
