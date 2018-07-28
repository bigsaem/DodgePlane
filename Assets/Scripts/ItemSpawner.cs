using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {


    Player player;
    public Item[] items = new Item[4];
    float spawnDistance = 12;
    private int itemNumber;
    
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
        StartCoroutine(RandomSpawn(items[0]));
        StartCoroutine(RandomSpawn(items[1]));
        StartCoroutine(RandomSpawn(items[2]));
        StartCoroutine(RandomSpawn(items[3]));
    }
	
	// Update is called once per frame
	void Update () {
        //itemNumber = Mathf.FloorToInt(Random.Range(0.01f, 4.99f));
        //StartCoroutine(RandomSpawn(items[itemNumber]));
    }
    private IEnumerator RandomSpawn(Item item)
    {
        while (true)
        {
            SpawnEnemyLeft(item);
            yield return new WaitForSeconds(Random.Range(5.0f, 10.0f));
            SpawnEnemyRight(item);
            yield return new WaitForSeconds(Random.Range(5.0f, 10.0f));
            SpawnEnemyTop(item);
            yield return new WaitForSeconds(Random.Range(5.0f, 10.0f));
            SpawnEnemyBottom(item);
            yield return new WaitForSeconds(Random.Range(5.0f, 10.0f));
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
