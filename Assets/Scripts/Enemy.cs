using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

    Player player;
    public float speed = 1;
    public bool startMoving;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        startMoving = false;
        Invoke("RotatePlane", 0.2f);
    }

    private void RotatePlane()
    {
        Vector3 comparingLine = transform.position - player.transform.position;
        float angle = Mathf.Atan2(comparingLine.y, comparingLine.x) * Mathf.Rad2Deg + 90;
        transform.eulerAngles = new Vector3(0, 0, angle);
        startMoving = true;
    }

    private void FixedUpdate()
    {
        if (startMoving)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, player.transform.position) > 30)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Player>() != null)
        {
            print("in");
            player.Die();
        }
    }
}
