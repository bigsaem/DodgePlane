using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    Player player;
    //public Enemy spawnEnemy;
    //public Enemy spawnEnemy2;
    public Enemy[] enemies = new Enemy[5];
    public EnemyLaser enemylaser;
    float spawnDistance = 12;
    private float spawnLaserDistance = 6;
    public ScoreKeeper currentScore;
    public AudioClip chargingSound;
    

    void Start () {
        player = FindObjectOfType<Player>();
        StartCoroutine(RandomSpawn(enemies[0], 0.2f, 1));
        //StartCoroutine(RandomSpawn(enemies[4], 4, 5));

    }

    private void Update()
    {
        if (player.getSeconds() == 15)
        {
            StartCoroutine(RandomSpawn(enemies[1], 1, 2));

            player.addToTimer();

        }
        if(player.getSeconds() == 25)
        {
            StartCoroutine(RandomSpawn(enemies[2], 2, 3));
            StartCoroutine(RandomLaserSpawn(enemylaser, 5, 6));
            player.addToTimer();
        }
        if (player.getSeconds() == 40)
        {
            StartCoroutine(RandomSpawn(enemies[3], 3, 4));
            player.addToTimer();
        }
        if (player.getSeconds() == 60)
        {
            StartCoroutine(RandomSpawn(enemies[4], 4, 5));
            player.addToTimer();
        }


    }
    private IEnumerator RandomSpawn(Enemy enemy, float range1, float range2)
    {
        while (true)
        {
            SpawnEnemyLeft(enemy);
            yield return new WaitForSeconds(Random.Range(range1, range2));
            SpawnEnemyRight(enemy);
            yield return new WaitForSeconds(Random.Range(range1, range2));
            SpawnEnemyTop(enemy);
            yield return new WaitForSeconds(Random.Range(range1, range2));
            SpawnEnemyBottom(enemy);
            yield return new WaitForSeconds(Random.Range(range1, range2));
        }
        
    }
    private IEnumerator RandomLaserSpawn(EnemyLaser enemyLaser, float range1, float range2)
    {
        while (true)
        {
            SpawnEnemyLaserLeft(enemyLaser);
            yield return new WaitForSeconds(Random.Range(range1, range2));

            /*
            SpawnEnemyLaserRight(enemyLaser);
            yield return new WaitForSeconds(Random.Range(range1, range2));
            SpawnEnemyLaserTop(enemyLaser);
            yield return new WaitForSeconds(Random.Range(range1, range2));
            SpawnEnemyLaserBottom(enemyLaser);
            yield return new WaitForSeconds(Random.Range(range1, range2));
            */
        }
    }


    EnemyLaser SpawnEnemyLaserLeft(EnemyLaser enemyLaser)
    {
        AudioSource.PlayClipAtPoint(chargingSound, transform.position);
        Vector3 spawnPos = (player.transform.position)
        + new Vector3(-spawnLaserDistance * Mathf.Sin(player.getAngle()*Mathf.Deg2Rad), spawnLaserDistance * Mathf.Cos(player.getAngle() * Mathf.Deg2Rad));
        EnemyLaser e = Instantiate<EnemyLaser>(enemyLaser, spawnPos, Quaternion.identity);
        e.transform.Rotate(0, 0, player.getAngle() + 90);
        return e;
        
    }
    /*
    EnemyLaser SpawnEnemyLaserRight(EnemyLaser enemyLaser)
    {
        Vector3 spawnPos = player.transform.position + new Vector3(spawnLaserDistance, 0);
        EnemyLaser e = Instantiate<EnemyLaser>(enemyLaser, spawnPos, Quaternion.identity);
        e.transform.Rotate(0, 0, player.getAngle() + 90);
        return e;
    }

    EnemyLaser SpawnEnemyLaserTop(EnemyLaser enemyLaser)
    {
        Vector3 spawnPos = player.transform.position + new Vector3(0, spawnLaserDistance);
        EnemyLaser e = Instantiate<EnemyLaser>(enemyLaser, spawnPos, Quaternion.identity);
        e.transform.Rotate(0, 0, player.getAngle() + 90);
        return e;
    }

    EnemyLaser SpawnEnemyLaserBottom(EnemyLaser enemyLaser)
    {
        Vector3 spawnPos = player.transform.position + new Vector3(0, -spawnLaserDistance);
        EnemyLaser e = Instantiate<EnemyLaser>(enemyLaser, spawnPos, Quaternion.identity);
        e.transform.Rotate(0,0, player.getAngle() + 90);
        return e;
    }
    */

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
