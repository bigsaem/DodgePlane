using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : EnemyUnit {
    private float timer;
    public int seconds;
    
    // Use this for initialization
    void Start () {
		
	}
    private void Awake()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        seconds = Mathf.FloorToInt(timer);
        if(timer > 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        
    }
}
