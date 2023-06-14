using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public CharacterController owner;
    Transform target;

    public void Shoot(Transform _target)
    {
        target = _target;
        Vector3 targetPos = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        LeanTween.move(this.gameObject, target.position, 0.5f).setOnComplete(() =>
        {
            Destroy(this.gameObject);
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            CharacterController otherController = other.GetComponent<CharacterController>();
            if (otherController != null && otherController != owner)
            {
                otherController.Dead();
            }
        }
    }
}
