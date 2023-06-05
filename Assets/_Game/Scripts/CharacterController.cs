using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] SkinnedMeshRenderer _character;
    [SerializeField] SkinnedMeshRenderer _pant;

    public List<Material> listClothes;

    private AnimType currentAnimName = AnimType.Idle;
    public float rotationSpeed = 100.0f;

    public enum AnimType
    {
        Idle, Run, Attack, Ulti, Dance, Dead
    }

    public void ChangeAnimation(AnimType _type)
    {
        if (currentAnimName != _type)
        {
            currentAnimName = _type;
            switch (_type)
            {
                case AnimType.Idle:
                    _animator.SetTrigger("IsIdle");
                    break;
                case AnimType.Run:
                    _animator.SetTrigger("IsRun");
                    break;
                case AnimType.Attack:
                    _animator.SetTrigger("IsAttack");
                    break;
                case AnimType.Ulti:
                    _animator.SetTrigger("IsUlti");
                    break;
                case AnimType.Dance:
                    _animator.SetTrigger("IsDance");
                    break;
                case AnimType.Dead:
                    _animator.SetTrigger("IsDead");
                    break;
            }
        }
    }

    public void SetClothes(int clothesID)
    {
        if (clothesID < listClothes.Count)
        {


        }
    }
}
