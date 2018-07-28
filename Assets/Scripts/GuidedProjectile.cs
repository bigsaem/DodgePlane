using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class GuidedProjectile : MonoBehaviour {


    
    Player player;
    Enemy enemy;

    ScoreKeeper scoreKeeper;
    public int scoreValue;

    public float speed;
    public float rotateSpeed;
    public float damage;
    
    private Rigidbody2D rb;

    private int duration;
    private float timer;
    
    void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
        timer = 0;
        duration = 0;
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
    }

    void FixedUpdate()
    {
        Vector2 direction = (Vector2)player.transform.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;
        /*
        var heading = this.transform.position - target.transform.position;
        var distance = heading.magnitude;
        directionToPlayer = heading / distance;
        */

        rb.velocity = transform.up * speed;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        duration = Mathf.FloorToInt(timer % 60);
        if(duration > 10)
        {
            Destroy(gameObject);
        }
        if (Vector3.Distance(transform.position, player.transform.position) > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Player>() != null)
        {
            scoreKeeper.Score(scoreValue);
            Destroy(gameObject);
            
        }
        /*
        else if(col.GetComponent<Enemy>() != null)
        {
            if (enemy.getFriendlyFire())
            {
                Destroy(gameObject);
            }
            
        }
        */
        else if(col.GetComponent<GuidedProjectile>() != null)
        {
            scoreKeeper.Score(scoreValue);
            Destroy(gameObject);
            
        }
        else if(col.GetComponent<Projectile>() != null)
        {
            scoreKeeper.Score(scoreValue);
            Destroy(gameObject);
            
        }
    }
    public float getDamage()
    {
        return damage;
    }


    /*
    Player player;

    
    Vector3 heading;
    private float distance;
    public Vector3 direction;

    public float damage = 100f;

    // Use this for initialization
    void Awake () {
        player = FindObjectOfType<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        heading = transform.position - player.transform.position;
        distance = heading.magnitude;
        direction = heading / distance;

	}

    public Vector3 getDirection()
    {
        return direction;
    }
    public float getDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
    */
}
