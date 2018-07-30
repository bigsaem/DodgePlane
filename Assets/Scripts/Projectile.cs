using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{



    Player thePlayer;
    Enemy enemy;

    public float bulletSpeed;
    public float rotateValue;
    public float damage;

    private Rigidbody2D rigidb;

    private int duration;
    //private float timer;

    void Start()
    {

        //timer = 0;
        //duration = 0;
        rigidb = GetComponent<Rigidbody2D>();
        thePlayer = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();
    }

    void FixedUpdate()
    {
        /*
        Vector2 direction = (Vector2)enemy.transform.position - rigidb.position;

        direction.Normalize();
        //direction = direction;

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rigidb.angularVelocity = -rotateAmount * rotateValue;
        rigidb.velocity = transform.up * bulletSpeed;
        */



        /*
        var heading = this.transform.position - target.transform.position;
        var distance = heading.magnitude;
        directionToPlayer = heading / distance;
        */


    }
    private void Update()
    {
        
        if (Vector3.Distance(transform.position, thePlayer.transform.position) > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Enemy>() != null)
        {
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
        else if (col.GetComponent<GuidedProjectile>() != null)
        {
            Destroy(gameObject);
        }
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
