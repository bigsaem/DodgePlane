using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundReposition : MonoBehaviour {
    public GameObject[] mapArray;
    Player player;
    private void Awake()
    {
        mapArray = GameObject.FindGameObjectsWithTag("map");
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        Vector3 center;
        center.x = Mathf.FloorToInt((player.transform.position.x +8) / 16);
        center.y = Mathf.FloorToInt((player.transform.position.y + 8) / 16);
        center.z = 1;
        Reposition(center * 16);
    }


    private void Reposition(Vector3 center)
    {
        for (int c = 0; c < mapArray.Length / 3; c++)
        {
            for (int r = 0; r < mapArray.Length / 3; r++)
            {
                Vector3 newPos = new Vector3(center.x + c * 16 - 16, center.y + r * 16 - 16, 0);
                mapArray[c * 3 + r].transform.position = newPos;
            }
        }
    }
}
