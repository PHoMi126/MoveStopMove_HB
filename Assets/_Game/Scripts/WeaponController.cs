using UnityEngine;

public class WeaponController : MonoBehaviour
{
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
}
