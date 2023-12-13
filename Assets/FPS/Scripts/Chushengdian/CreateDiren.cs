using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDiren : MonoBehaviour
{
    public GameObject enemyPrefab; // ���˵�Ԥ����
    public Transform spawnPoint; // ������
    public Transform[] targetPoints; // ���Ŀ���
    public float timeBetweenWaves = 5f; // ÿ��֮��ļ��ʱ��
    public int[] numberOfEnemiesInWaves = { 5, 10, 15 }; // ÿ���ĵ�������
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
                yield return new WaitForSeconds(1f); // ���ɵ���֮��ļ��ʱ��
            }

            yield return new WaitForSeconds(timeBetweenWaves); // ����֮��ļ��ʱ��
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

            // ����Ҷ�������Ϊ���˵�Ŀ��
            enemyScript.SetTarget(player.transform);
        
        }*/
    }
}
