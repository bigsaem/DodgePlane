using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    Rigidbody2D rb;
    Enemy enemy;
    public GameObject projectile;
    public Shield shield;
    public float eulerAngle;

    private float turnSpeed = 180f;
    public float health;
    private float speed = 5f;
    public bool dead = false;
    public float projectileSpeed;



    private ScoreKeeper scoreKeeper;
    private int scoreOverTime = 65;




    private float timer;
    public int seconds;


    private bool rocketPickUp = false;
    private bool rocketTimer = false;
    private int rocketStart;
    private float shotsPerSecond = 10;
    private bool firing = true;
    private float firingStart;

    private bool shieldPickUp = false;
    private bool shieldTimer = false;
    private int shieldStart;
    //public Renderer rend;

    private bool powerBoostPickUp = false;
    private bool powerBoostTimer = false;
    private int powerBoostStart;

    private bool pointBoostPickUp = false;
    private bool pointBoostTimer = false;
    private int pointBoostStart;

    public LevelManager levelManager;
    // Use this for initialization
    void Start () {
        //Instantiate(shield, transform.position, Quaternion.identity);
        rb = GetComponent<Rigidbody2D>();
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
        InvokeRepeating("ScorePoints", 0.0001f, 1.0f);
        timer = 0;
        
    }
    
    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;
        seconds = Mathf.FloorToInt(timer);
        //Debug.Log(timer);
        //Debug.Log(seconds);
        
        if (rocketPickUp)
        {
            if (firing)
            {
                firingStart = timer;
                
                Vector3 startPosition = transform.position + new Vector3(0, 0, 0);
                GameObject scatterShot0 = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
                GameObject scatterShot1 = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
                GameObject scatterShot2 = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
                GameObject scatterShot3 = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
                GameObject scatterShot4 = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
                GameObject scatterShot5 = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
                GameObject scatterShot6 = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
                GameObject scatterShot7 = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;



                scatterShot0.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
                scatterShot1.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed / 2, projectileSpeed / 2);
                scatterShot2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                scatterShot3.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed / 2, projectileSpeed / 2);
                scatterShot4.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0);
                scatterShot5.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed / 2, -projectileSpeed / 2);
                scatterShot6.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
                scatterShot7.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed / 2, -projectileSpeed / 2);
                firing = false;
            }
            if(firingStart + 0.3 < timer)
            {
                firing = true;
            }
            

            

            /*
            enemy = FindObjectOfType<Enemy>();
            Vector3 direction = transform.position - enemy.transform.position;
            float heading = direction.magnitude;
            
            
                Vector3 startPosition = transform.position + new Vector3(0, 0, 0);
                GameObject guidedMissile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
            
            */

            /*
            float probability = Time.deltaTime * shotsPerSecond;
            if (Random.value < probability)
            {
                Vector3 startPosition = transform.position + new Vector3(0, 0, 0);
                GameObject guidedMissile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
            }
            */


            if (rocketStart + 5 <= seconds)
            {
                rocketTimer = false;
                firing = false;
                if (!rocketTimer)
                {
                    //speed = 5f;
                    rocketPickUp = false;
                }
            }
        }
        
        /*
        if (shieldPickUp)
        {
            
            if (shieldStart + 10 <= seconds)
            {
                shieldTimer = false;
                if (!shieldTimer)
                {
                    //health = 200;
                    shieldPickUp = false;
                    GetComponent<Renderer>().material.color = Color.white;
                }
            }
            
        }
        */
    


        if (powerBoostPickUp)
        {
            
            if (powerBoostStart + 7.5 <= seconds)
            {
                powerBoostTimer = false;
                if (!powerBoostTimer)
                {
                    turnSpeed = 180f;
                    speed = 5f;
                    
                    //health = 200;
                    
                    
                    powerBoostPickUp = false;
                    
                    GetComponent<Renderer>().material.color = Color.white;
                    
                    
                }
            }
        }

        if (pointBoostPickUp)
        {
            
            if (pointBoostStart + 5 <= seconds)
            {
                pointBoostTimer = false;
                if (!pointBoostTimer)
                {
                    scoreOverTime = 65;
                    pointBoostPickUp = false;
                }
            }
        }

        if (dead)
        {
            return;
        }
        /*
        if (Input.GetKey(KeyCode.Y))
        {
            transform.Rotate(0, 0, 90);
        }
        */
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
        //print(transform.eulerAngles.x);
        //print(transform.eulerAngles.y);
        eulerAngle = transform.eulerAngles.z;
        //print(eulerAngle);
        //print(6*Mathf.Cos(eulerAngle * Mathf.Deg2Rad));
        //print(Mathf.Sin(eulerAngle * Mathf.Deg2Rad));
        //Vector3 spawnPos = (player.transform.position) + new Vector3(player.transform.position.x/Mathf.Abs(player.transform.position.x), player.transform.position.y/ Mathf.Abs(player.transform.position.y), 0);
        /*
         * if (speedBoostPickUp == true)
        {

        }
        */

    }
    public float getTurnSpeed()
    {
        return turnSpeed;
    }
    public float getAngle()
    {
        return eulerAngle;
    }
    public int getSeconds()
    {
        return seconds;
    }
    public void addToTimer()
    {
        timer += 1;
    }
    public void Die()
    {
        //start
        int score = scoreKeeper.score;

        if (PlayerPrefs.GetInt("highestScore") <= score)
        {
            PlayerPrefs.SetInt("highestScore", score);
        }
        print("The highest score: " + PlayerPrefs.GetInt("highestScore"));
        //end

        dead = true;
        print("Game Over");
        GetComponent<SpriteRenderer>().enabled = false;
        levelManager.LoadLevel("Lose");

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ProjectileEnemy missile = collision.gameObject.GetComponent<ProjectileEnemy>();
        GuidedProjectile guidedMissile = collision.gameObject.GetComponent<GuidedProjectile>();
        Laser laser = collision.gameObject.GetComponent<Laser>();
        bool laserPassed = true;
        if (missile)
        {
            
            Crash();
            
            if(health <= 0)
            {
                Die();
            }
        }
        if (guidedMissile)
        {

            Crash();
            
            if (health <= 0)
            {
                Die();
            }
        }
        if (laser && laserPassed)
        {
           
            
            
            Crash();
            if (health <= 0)
            {
                Die();
            }
            laserPassed = false;
            
            
        }
    }


    public void RocketBoost()
    {
        


        rocketStart = seconds;
        rocketTimer = true;
        firing = true;
        
        rocketPickUp = true;


        //AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
    public void ShieldBoost()
    {
        if (!shieldTimer)
        {
            shield = InstantiateShield(shield);
            shield.RenderOn();
            //rend = GetComponent<Renderer>();
            //rend.enabled = true;
            
            

        }
        
        
        
        
        //GetComponent<Renderer>().material.color = Color.blue;
        shieldStart = seconds;
        shieldTimer = true;
        //health = 400;
        shieldPickUp = true;
    }
    Shield InstantiateShield(Shield thisShield)
    {
        
        Shield s = Instantiate(thisShield, transform.position, Quaternion.identity);
        s.transform.Rotate(0, 0, getAngle());

        return s;
    }
    public void PowerBoost()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
        powerBoostStart = seconds;
        powerBoostTimer = true;
        turnSpeed = 360;
        speed = 10;
        //health = 1000000;
        powerBoostPickUp = true;
    }
    public void PointBoost()
    {
        pointBoostStart = seconds;
        pointBoostTimer = true;
        scoreOverTime = 130;
        pointBoostPickUp = true;
    }
    public void ScorePoints()
    {
        scoreKeeper.Score(scoreOverTime);
    }

    public void Crash()
    {
        //GetComponent<Renderer>().material.color = Color.white;

        if (!powerBoostTimer) {
            if (shieldTimer)
            {
                /* NEEDS FIXING!!!!!!!!!
                 !
                 !
                 !
                 !
                 !
                 !
                 !
                 !
                 !
                 !
                 !!!!!!!!!!!!!!!!!!!!!!!!!!!*/
                //DestroyObject(shield);
                //rend.enabled = false;
                shield.RenderOff();
                shieldTimer = false;
                
            }
            else
            {
                health -= 100;
            }
            
        }
        

        
        
        if(health <= 0)
        {
            
            Die();
        }
    }






    
}
