using System.Collections.Generic;
using UnityEngine;

public class BotPool : MonoBehaviour
{
    public static BotPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public GameObject[] spawnPoints;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        Invoke(nameof(PooledBots), 0.2f);
    }

    public void PooledBots()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            int spawn = Random.Range(0, spawnPoints.Length);
            tmp = Instantiate(objectToPool, spawnPoints[spawn].transform.position, Quaternion.identity);
            tmp.SetActive(true);
            pooledObjects.Add(tmp);
        }
    }
}
