using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDiren : MonoBehaviour
{
    public GameObject enemyPrefab; // 敌人的预制体
    public Transform spawnPoint; // 出生点
    public Transform[] targetPoints; // 多个目标点
    public float timeBetweenWaves = 5f; // 每波之间的间隔时间
    public int[] numberOfEnemiesInWaves = { 5, 10, 15 }; // 每波的敌人数量
    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (currentWave < numberOfEnemiesInWaves.Length)
        {
            for (int i = 0; i < numberOfEnemiesInWaves[currentWave]; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(1f); // 生成敌人之间的间隔时间
            }

            yield return new WaitForSeconds(timeBetweenWaves); // 波次之间的间隔时间
            currentWave++;
        }
    }

    void SpawnEnemy()
    {
        //   Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Vector3 spawnPosition = spawnPoint.position + new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f));

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, spawnPoint.rotation);
        TestXulu enemyScript = enemy.GetComponent<TestXulu>();
        enemyScript.SetTarget(targetPoints);
       /* if (enemyScript != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            // 将玩家对象设置为敌人的目标
            enemyScript.SetTarget(player.transform);
        
        }*/
    }
}
