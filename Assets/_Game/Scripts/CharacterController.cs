using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer _characterMesh;
    [SerializeField] SkinnedMeshRenderer _pantMesh;
    [SerializeField] Transform _weaponTransform;
    [SerializeField] TargetController _targetController;

    public GameObject weaponPrefab;
    public Animator animator;

    public GameObject CharacterObject;

    public float attackTime;
    public List<Material> listClothes;

    private AnimState currentAnimState = AnimState.Idle;
    public bool isDead = false;
    public enum AnimState
    {
        Idle, Run, Attack, Ulti, Dance, Dead
    }

    void Start()
    {
        SetClothes(Random.Range(0, 8));
        //Physics.IgnoreCollision(weaponPrefab.GetComponent<MeshCollider>(), GetComponent<BoxCollider>());
        isDead = false;
    }

    void Update()
    {
        attackTime -= Time.deltaTime;
        if (attackTime <= 0 && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && _targetController != null && _targetController.listEnemy.Count > 0)
        {
            Attack();
        }
    }

    public void ChangeAnimation(AnimState _state)
    {
        if (isDead)
            return;
        if (currentAnimState != _state)
        {
            currentAnimState = _state;
            animator.SetTrigger(currentAnimState.ToString());
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
        attackTime = 3f;
        ThrowWeapon();
        CharacterObject.transform.localEulerAngles = new Vector3(0f, CharacterObject.transform.localEulerAngles.y, 0f);
        Invoke(nameof(EndAttack), 0.5f);
    }

    public void ThrowWeapon()
    {
        if (_targetController.FindTheTarget() != null)
        {
            CharacterObject.transform.LookAt(_targetController.FindTheTarget().transform);
            ChangeAnimation(AnimState.Attack);
            GameObject weaponObject = Instantiate(weaponPrefab);
            weaponObject.name = "Weapon " + this.gameObject.name;
            weaponObject.transform.SetPositionAndRotation(_weaponTransform.transform.position, _weaponTransform.transform.rotation);
            weaponObject.GetComponent<WeaponController>().owner = this;
            weaponObject.GetComponent<WeaponController>().Shoot(_targetController.FindTheTarget().transform);
        }
        _weaponTransform.gameObject.SetActive(false);
    }

    public void EndAttack()
    {
        _weaponTransform.gameObject.SetActive(true);
        ChangeAnimation(AnimState.Idle);
    }

    public void Dead()
    {
        ChangeAnimation(AnimState.Dead);
        isDead = true;
    }
}
