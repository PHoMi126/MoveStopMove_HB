using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Animator _animator;

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
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ChangeAnimation(AnimType.Idle);
            _rigidbody.velocity = Vector3.zero;

        }
    }

    public void ChangeAnimation(AnimType _type)
    {
        if (currentAnimName != _type)
        {
            currentAnimName = _type;
            switch (_type)
            {
                case AnimType.Idle:
                    _animator.SetBool("IsIdle", true);
                    _animator.SetBool("IsRun", false);
                    break;
                case AnimType.Run:
                    _animator.SetBool("IsRun", true);
                    _animator.SetBool("IsIdle", false);
                    break;
                case AnimType.Dance:
                    _animator.SetBool("IsDance", true);
                    break;
            }
        }
    }
}
