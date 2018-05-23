using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    Rigidbody2D rb;
    public float turnSpeed = 30;
    public float speed = 30;
    public bool dead = false;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (dead)
        {
            return;
        }
		if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -turnSpeed * Time.deltaTime);
        }
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].position.x > Screen.width / 2)
            {
                transform.Rotate(0, 0, -turnSpeed * Time.deltaTime);
            }
            if (Input.touches[0].position.x < Screen.width / 2)
            {
                transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
            }
        }
        
        transform.Translate(Vector3.up * speed * Time.deltaTime);

    }

    public void Die()
    {
        dead = true;
        print("Game Over");
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
