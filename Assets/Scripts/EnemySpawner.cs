using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    Player player;
    //public Enemy spawnEnemy;
    //public Enemy spawnEnemy2;
    public Enemy[] enemies = new Enemy[5];
    float spawnDistance = 12;
    public ScoreKeeper currentScore;
	
	void Start () {
        player = FindObjectOfType<Player>();
        StartCoroutine(RandomSpawn(enemies[0]));
	}

    private void Update()
    {
        if (currentScore.GetScore() >= 1000 && currentScore.GetScore() <= 1065)
        {
            StartCoroutine(RandomSpawn(enemies[1]));
            currentScore.SetScore(1065 + 65);

        }
        
    }
    private IEnumerator RandomSpawn(Enemy enemy)
    {
        while (true)
        {
            SpawnEnemyLeft(enemy);
            yield return new WaitForSeconds(Random.Range(0.2f, 1));
            SpawnEnemyRight(enemy);
            yield return new WaitForSeconds(Random.Range(0.2f, 1));
            SpawnEnemyTop(enemy);
            yield return new WaitForSeconds(Random.Range(0.2f, 1));
            SpawnEnemyBottom(enemy);
            yield return new WaitForSeconds(Random.Range(0.2f, 1));
        }
        
    }

    

    Enemy SpawnEnemyLeft(Enemy enemy)
    {
        Vector3 spawnPos = player.transform.position + new Vector3(-spawnDistance, Random.Range(-spawnDistance, spawnDistance));
        Enemy e = Instantiate<Enemy>(enemy, spawnPos, Quaternion.identity);
        return e;
    }

    Enemy SpawnEnemyRight(Enemy enemy)
    {
        Vector3 spawnPos = player.transform.position + new Vector3(spawnDistance, Random.Range(-spawnDistance, spawnDistance));
        Enemy e = Instantiate<Enemy>(enemy, spawnPos, Quaternion.identity);
        return e;
    }

    Enemy SpawnEnemyTop(Enemy enemy)
    {
        Vector3 spawnPos = player.transform.position + new Vector3(Random.Range(-spawnDistance, spawnDistance), spawnDistance);
        Enemy e = Instantiate<Enemy>(enemy, spawnPos, Quaternion.identity);
        return e;
    }

    Enemy SpawnEnemyBottom(Enemy enemy)
    {
        Vector3 spawnPos = player.transform.position + new Vector3(Random.Range(-spawnDistance, spawnDistance), -spawnDistance);
        Enemy e = Instantiate<Enemy>(enemy, spawnPos, Quaternion.identity);
        return e;
    }
}
