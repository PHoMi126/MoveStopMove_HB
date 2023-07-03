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

    private void Update()
    {
        Invoke(nameof(End), 0.5f);
    }

    IEnumerator EnemySpawn()
    {
        while (enemyCount < 10)
        {
            xPos = Random.Range(-55, -12);
            zPos = Random.Range(-35, 40);
            Instantiate(enemy, new Vector3(xPos, 0.05f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }

    void End()
    {
        if (enemyCount == 0)
        {
            Time.timeScale = 0f;
        }
    }
}
