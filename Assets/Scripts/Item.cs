using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public GameObject sparkle;
    Player player;
    public float speed;
    public bool startMoving;
    public int itemNumber;

	// Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnEnable()
    {
        startMoving = false;
        Invoke("RotateItem", 0.2f);
    }

    private void RotateItem()
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
        if (Vector3.Distance(transform.position, player.transform.position) > 20)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Player>() != null)
        {
            print("in");
            if(itemNumber == 0)
            {
                player.RocketBoost();
            }else if(itemNumber == 1)
            {
                player.ShieldBoost();
            }else if(itemNumber == 2)
            {
                player.PowerBoost();
            }else if(itemNumber == 3)
            {
                player.PointBoost();
            }else if(itemNumber == 4)
            {
                player.BombObjects();
            }
            
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Instantiate(sparkle, transform.position, Quaternion.identity);
    }
}
