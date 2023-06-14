using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public CharacterController parent;
    public List<CharacterController> listEnemy = new List<CharacterController>();
    Vector3 startPos;

    public void Start()
    {
        startPos = transform.localPosition;
    }

    public void Update()
    {
        if (parent != null)
        {
            this.transform.localPosition = parent.transform.localPosition + startPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterController enemy = other.GetComponent<CharacterController>();
        if (enemy != parent && enemy != null && !listEnemy.Contains(enemy))
        {
            listEnemy.Add(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CharacterController enemy = other.GetComponent<CharacterController>();
        if (enemy != null && listEnemy.Contains(enemy))
        {
            listEnemy.Remove(enemy);
        }
    }

    public GameObject FindTheTarget()
    {
        if (listEnemy.Count == 0)
            return null;
        else return listEnemy[0].gameObject;
    }
}
