using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public CharacterController parent;
    CharacterController enemy;
    public List<CharacterController> listEnemy = new List<CharacterController>();
    Vector3 startPos;

    private void Start()
    {
        startPos = transform.localPosition;
    }

    private void Update()
    {
        if (parent != null)
        {
            transform.localPosition = parent.transform.localPosition + startPos;
        }
        if (enemy != null && enemy.isDead && listEnemy.Contains(enemy) && enemy != parent)
        {
            //listEnemy.Remove(enemy);
            for (int i = 0; i < listEnemy.Count; i++)
            {
                listEnemy.RemoveAt(i);
            }
        }
        listEnemy.RemoveAll(x => x.isDead);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            enemy = other.GetComponent<CharacterController>();
            //Debug.Log("OnTriggerEnter: " + other.name);
            if (enemy != null)
            {
                //Debug.Log("OnTriggerEnter: " + enemy.transform.parent.name);
                if (enemy != parent && !listEnemy.Contains(enemy))
                {
                    listEnemy.Add(enemy);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.LogError("OnTriggerExit : " + other.name);
        CharacterController enemy = other.GetComponent<CharacterController>();
        if (enemy != null && listEnemy.Contains(enemy))
        {
            listEnemy.Remove(enemy);
        }
    }

    public GameObject FindTheTarget()
    {
        if (listEnemy.Count == 0 && listEnemy != null)
        {
            return null;
        }
        else
        {
            return listEnemy[0].gameObject;
        }
    }
}
