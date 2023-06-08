using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] SkinnedMeshRenderer _characterMesh;
    [SerializeField] SkinnedMeshRenderer _pantMesh;
    [SerializeField] Transform _weaponBase;
    [SerializeField] Transform _weaponTransform;
    [SerializeField] TargetController _targetController;
    [SerializeField] GameObject _weaponPrefab;

    public GameObject CharacterObject;
    public List<Material> listClothes;


    private AnimState currentAnimState = AnimState.Idle;
    public float attackTime;

    public enum CharacterType
    {
        Player,
        Enemy,
    }
    public enum AnimState
    {
        Idle, Run, Attack, Ulti, Dance, Dead
    }

    void Start()
    {
        SetClothes(Random.Range(0, 8));
    }

    void Update()
    {
        attackTime -= Time.deltaTime;
        if (attackTime <= 0)
        {
            Attack();
        }
    }

    public void ChangeAnimation(AnimState _state)
    {
        if (currentAnimState != _state)
        {
            currentAnimState = _state;
            _animator.SetTrigger(currentAnimState.ToString());
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

    public void Attack()
    {
        if (_targetController != null && _targetController.listEnemy.Count > 0)
        {
            attackTime = 3f;
            ChangeAnimation(AnimState.Attack);
        }
    }

    public void ThrowWeapon()
    {
        if (_targetController.FindTheTarget() != null)
        {
            GameObject weaponObject = GameObject.Instantiate(_weaponPrefab);
            weaponObject.transform.position = _weaponBase.transform.position;
            weaponObject.transform.rotation = _weaponBase.transform.rotation;

            //weaponObject.GetComponent<WeaponController>().Shoot(_targetController.FindTheTarget().transform);
        }
        _weaponTransform.gameObject.SetActive(false);
    }

    public void EndAttack()
    {
        _weaponTransform.gameObject.SetActive(true);
        ChangeAnimation(AnimState.Idle);
    }

    public virtual void Dead()
    {
        ChangeAnimation(AnimState.Dead);
    }
}
