using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {


    Player player;
    public Item[] items = new Item[4];
    float spawnDistance = 12;
    private int itemNumber;
    private float timer;
    private int seconds;

	// Use this for initialization
	void Start () {
        timer = 0;
        player = FindObjectOfType<Player>();
        /*
        foreach(Item item in items)
        {
            StartCoroutine(RandomSpawn(item));
        }
        */
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        seconds = Mathf.FloorToInt(timer);
        /*
        if (seconds == 5)
        {
            StartCoroutine(RandomSpawn(items[0]));
            timer += 1;
        }
        */
        if (seconds == 10)
        {
            StartCoroutine(RandomSpawn(items[1], 4, 8));
            //StartCoroutine(RandomSpawn(items[4], 1, 3));
            timer += 1;
        }
        if (seconds == 15)
        {
            StartCoroutine(RandomSpawn(items[2], 8, 11));
            timer += 1;
        }
        if (seconds == 20)
        {
            StartCoroutine(RandomSpawn(items[3], 8, 11));
            timer += 1;
        }
        if (seconds == 25)
        {
            StartCoroutine(RandomSpawn(items[4], 15, 25));
            timer += 1;
        }
        //itemNumber = Mathf.FloorToInt(Random.Range(0.01f, 4.99f));
        //StartCoroutine(RandomSpawn(items[itemNumber]));
    }
    private IEnumerator RandomSpawn(Item item, float rangeInner, float rangeOuter)
    {
        while (true)
        {
            SpawnEnemyLeft(item);
            yield return new WaitForSeconds(Random.Range(rangeInner, rangeOuter));
            SpawnEnemyRight(item);
            yield return new WaitForSeconds(Random.Range(rangeInner, rangeOuter));
            SpawnEnemyTop(item);
            yield return new WaitForSeconds(Random.Range(rangeInner, rangeOuter));
            SpawnEnemyBottom(item);
            yield return new WaitForSeconds(Random.Range(rangeInner, rangeOuter));
        }

    }

    Item SpawnEnemyLeft(Item item)
    {
        Vector3 spawnPos = player.transform.position + new Vector3(-spawnDistance, Random.Range(-spawnDistance, spawnDistance));
        Item e = Instantiate<Item>(item, spawnPos, Quaternion.identity);
        return e;
    }

    Item SpawnEnemyRight(Item item)
    {
        Vector3 spawnPos = player.transform.position + new Vector3(spawnDistance, Random.Range(-spawnDistance, spawnDistance));
        Item e = Instantiate<Item>(item, spawnPos, Quaternion.identity);
        return e;
    }

    Item SpawnEnemyTop(Item item)
    {
        Vector3 spawnPos = player.transform.position + new Vector3(Random.Range(-spawnDistance, spawnDistance), spawnDistance);
        Item e = Instantiate<Item>(item, spawnPos, Quaternion.identity);
        return e;
    }

    Item SpawnEnemyBottom(Item item)
    {
        Vector3 spawnPos = player.transform.position + new Vector3(Random.Range(-spawnDistance, spawnDistance), -spawnDistance);
        Item e = Instantiate<Item>(item, spawnPos, Quaternion.identity);
        return e;
    }

}
