using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class Character : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    private AnimType currentAnimName = AnimType.Idle;
    public float rotationSpeed = 100.0f;

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
