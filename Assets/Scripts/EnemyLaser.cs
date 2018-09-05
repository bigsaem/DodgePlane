using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : EnemyUnit {


    Player player;
    public GameObject laser;
    private float timer;
    public int seconds;
    public float angle;
    public AudioClip fireSound;

    private void Awake()
    {
        
        timer = 0;
        player = FindObjectOfType<Player>();
        
    }
    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        seconds = Mathf.FloorToInt(timer);
        angle = transform.eulerAngles.z;
        if (timer > 1)
        {
            Vector3 startPosition = transform.position;
            GameObject thickLaser = Instantiate(laser, startPosition, Quaternion.identity);
            AudioSource.PlayClipAtPoint(fireSound, thickLaser.transform.position);
            thickLaser.transform.Rotate(0, 0, angle);
            Destroy(gameObject);
        }
        
    }

}
