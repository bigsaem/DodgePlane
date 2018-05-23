using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    Player player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = (Vector3.Lerp(transform.position, player.transform.position + Vector3.back * 10, 0.5f));
	}
}
