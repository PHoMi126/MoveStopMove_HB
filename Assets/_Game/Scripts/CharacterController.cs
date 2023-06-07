using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] SkinnedMeshRenderer _characterMesh;
    [SerializeField] SkinnedMeshRenderer _pantMesh;

    public List<Material> listClothes;

    private AnimType currentAnimState = AnimType.Idle;
    public float rotationSpeed = 100.0f;

    public enum AnimType
    {
        Idle, Run, Attack, Ulti, Dance, Dead
    }

    void Start()
    {
        SetClothes(Random.Range(0, 9));
    }

    public void ChangeAnimation(AnimType _state)
    {
        if (currentAnimState != _state)
        {
            currentAnimState = _state;
            _animator.SetTrigger(currentAnimState.ToString());
            /* switch (_state)
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
            } */
        }
    }

    public void SetClothes(int clothesID)
    {
        if (clothesID < listClothes.Count)
        {
            _characterMesh.material = listClothes[clothesID];
            _pantMesh.material = listClothes[clothesID];
        }
    }
}
