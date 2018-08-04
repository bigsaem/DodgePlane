using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : EnemyUnit {

    public GameObject projectile;


    
    GameObject guidedMissile;

    Player player;
    GuidedProjectile guidedProjectile;
    private bool guidedProjInstant;

    


    public float speed = 1;
    public bool startMoving;
    public float shotsPerSecond = 0.5f;
    public float projectileSpeed;
    public bool guidedMissileActive;
    public bool nonGuidedMissileActive;
    public bool shotgunMissileActive;
    public bool friendlyFire = true;

    public int damage = 100;
    public int scoreValue;
    private ScoreKeeper scoreKeeper;

    public AudioClip explode;
    public AudioClip fireSound;


    public Vector3 directionToPlayer;


    






    //Bezier Point variables
    /*
    private float currentDuration = 0;
    private float duration = 10;
    */


    //private ScoreKeeper scoreKeeper;
    //public int scoreValue = 150;


    private void Start()
    {
        
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        guidedProjInstant = true;
    }

    void Update()
    {
        float probability = Time.deltaTime * shotsPerSecond;
        if(Random.value < probability)
        {
            if (nonGuidedMissileActive)
            {
                Fire();
            }
            
            if (guidedMissileActive)
            {



                FireGuided();


            }
            if (shotgunMissileActive)
            {
                FireScatter();
            }
            
            
        }
        

    }

    void Fire()
    {
        Vector3 startPosition = transform.position + new Vector3(0, 0, 0);
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(fireSound, transform.position);


        Vector3 heading = missile.transform.position - player.transform.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;
        

        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(-direction.x * projectileSpeed , -direction.y * projectileSpeed);
    }

    /*NEED UPDATE!!!!!!!!!!!!!!*/
    
    void FireGuided()
    {
        Vector3 startPosition = transform.position + new Vector3(0, 0, 0);
        guidedMissile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;

        AudioSource.PlayClipAtPoint(fireSound, transform.position);

        


    }
    void FireScatter()
    {
        float angle0 = 0.1f;
        float angle1 = 6.2f;
        //float angle2 = 0.3f;

        Vector3 startPosition = transform.position + new Vector3(0, 0, 0);
        GameObject scatterShot0 = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        GameObject scatterShot1 = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        //GameObject scatterShot2 = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        GameObject scatterShot3 = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        //GameObject scatterShot4 = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;




        Vector3 heading = scatterShot0.transform.position - player.transform.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;



        Vector2 heading1 = new Vector2(scatterShot1.transform.position.x - (scatterShot1.transform.position.x + (player.transform.position.x - scatterShot1.transform.position.x)*Mathf.Cos(angle0))
            -(player.transform.position.y - scatterShot1.transform.position.y)*Mathf.Sin(angle0), 
            scatterShot1.transform.position.y - (scatterShot1.transform.position.y + (player.transform.position.y - scatterShot1.transform.position.y)*Mathf.Cos(angle0))
            + (player.transform.position.x - scatterShot1.transform.position.x) * Mathf.Sin(angle0));
        float distance1 = heading1.magnitude;
        Vector2 direction1 = heading1 / distance1;

        /*
        Vector2 heading2 = new Vector2(scatterShot2.transform.position.x - (scatterShot2.transform.position.x + (player.transform.position.x - scatterShot2.transform.position.x) * Mathf.Cos(-angle0))
            - (player.transform.position.y - scatterShot2.transform.position.y) * Mathf.Sin(-angle0),
            scatterShot2.transform.position.y - (scatterShot2.transform.position.y + (player.transform.position.y - scatterShot2.transform.position.y) * Mathf.Cos(-angle0))
            + (player.transform.position.x - scatterShot2.transform.position.x) * Mathf.Sin(-angle0));
        float distance2 = heading1.magnitude;
        Vector2 direction2 = heading1 / distance1;
        */

        Vector2 heading3 = new Vector2(scatterShot3.transform.position.x - (scatterShot3.transform.position.x + (player.transform.position.x - scatterShot3.transform.position.x) * Mathf.Cos(angle1))
            - (player.transform.position.y - scatterShot3.transform.position.y) * Mathf.Sin(angle1),
            scatterShot3.transform.position.y - (scatterShot3.transform.position.y + (player.transform.position.y - scatterShot3.transform.position.y) * Mathf.Cos(angle1))
            + (player.transform.position.x - scatterShot3.transform.position.x) * Mathf.Sin(angle1));
        float distance3 = heading3.magnitude;
        Vector2 direction3 = heading3 / distance3;

        /*
        Vector2 heading4 = new Vector2(scatterShot4.transform.position.x - (scatterShot4.transform.position.x + (player.transform.position.x - scatterShot4.transform.position.x) * Mathf.Cos(-angle1))
            - (player.transform.position.y - scatterShot4.transform.position.y) * Mathf.Sin(-angle1),
            scatterShot4.transform.position.y - (scatterShot4.transform.position.y + (player.transform.position.y - scatterShot4.transform.position.y) * Mathf.Cos(-angle1))
            + (player.transform.position.x - scatterShot4.transform.position.x) * Mathf.Sin(-angle1));
        float distance4 = heading1.magnitude;
        Vector2 direction4 = heading1 / distance1;
        */

        scatterShot0.GetComponent<Rigidbody2D>().velocity = new Vector2(-direction.x * projectileSpeed, -direction.y * projectileSpeed);
        scatterShot1.GetComponent<Rigidbody2D>().velocity = new Vector2(-direction1.x * projectileSpeed, -direction1.y * projectileSpeed);
        //scatterShot2.GetComponent<Rigidbody2D>().velocity = new Vector2(-direction2.x * projectileSpeed, -direction2.y * projectileSpeed);
        scatterShot3.GetComponent<Rigidbody2D>().velocity = new Vector2(-direction3.x * projectileSpeed, -direction3.y * projectileSpeed);
        //scatterShot4.GetComponent<Rigidbody2D>().velocity = new Vector2(-direction4.x * projectileSpeed, -direction4.y * projectileSpeed);
    }

    public bool getFriendlyFire()
    {
        return friendlyFire;
    }
    
    public int getDamage()
    {
        return damage;
    }

    /*
    private Vector3 CalculateBezierPoint (float t, Vector3 startPosition, Vector3 endPosition, Vector3 controlPoint)
    {
        float u = 1 - t;
        float uu = u * u;

        Vector3 point = uu * startPosition;
        point += 2 * u * t * controlPoint;
        point += t * t * endPosition;

        return point;
    }
    */

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
            player.Crash();
            scoreKeeper.Score(scoreValue);
            Die();
            
        }
        if(col.GetComponent<Projectile>() != null)
        {
            scoreKeeper.Score(scoreValue);
            Die();
            
        }
    }

    void Die()
    {
        AudioSource.PlayClipAtPoint(explode, transform.position);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Invoke("DestroyThis", 0.8f);
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }

    
    
}
