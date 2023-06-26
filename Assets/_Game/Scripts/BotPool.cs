using System.Collections;
using UnityEngine;

public class BotPool : MonoBehaviour
{
    public GameObject enemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (enemyCount < 20)
        {
            xPos = Random.Range(-55, 17);
            zPos = Random.Range(-35, 45);
            Instantiate(enemy, new Vector3(xPos, 0.05f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
