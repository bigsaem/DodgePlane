using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    Player player;
    public Enemy spawnEnemy;
    float spawnDistance = 12;
	
	void Start () {
        player = FindObjectOfType<Player>();
        StartCoroutine(RandomSpawn());
	}

    private IEnumerator RandomSpawn()
    {
        while (true)
        {
            SpawnEnemyLeft();
            yield return new WaitForSeconds(Random.Range(0.2f, 1));
            SpawnEnemyRight();
            yield return new WaitForSeconds(Random.Range(0.2f, 1));
            SpawnEnemyTop();
            yield return new WaitForSeconds(Random.Range(0.2f, 1));
            SpawnEnemyBottom();
            yield return new WaitForSeconds(Random.Range(0.2f, 1));
        }
        
    }

    Enemy SpawnEnemyLeft()
    {
        Vector3 spawnPos = player.transform.position + new Vector3(-spawnDistance, Random.Range(-spawnDistance, spawnDistance));
        Enemy e = Instantiate<Enemy>(spawnEnemy, spawnPos, Quaternion.identity);
        return e;
    }

    Enemy SpawnEnemyRight()
    {
        Vector3 spawnPos = player.transform.position + new Vector3(spawnDistance, Random.Range(-spawnDistance, spawnDistance));
        Enemy e = Instantiate<Enemy>(spawnEnemy, spawnPos, Quaternion.identity);
        return e;
    }

    Enemy SpawnEnemyTop()
    {
        Vector3 spawnPos = player.transform.position + new Vector3(Random.Range(-spawnDistance, spawnDistance), spawnDistance);
        Enemy e = Instantiate<Enemy>(spawnEnemy, spawnPos, Quaternion.identity);
        return e;
    }

    Enemy SpawnEnemyBottom()
    {
        Vector3 spawnPos = player.transform.position + new Vector3(Random.Range(-spawnDistance, spawnDistance), -spawnDistance);
        Enemy e = Instantiate<Enemy>(spawnEnemy, spawnPos, Quaternion.identity);
        return e;
    }
}
