using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    Rigidbody2D rb;
    public GameObject projectile;

    private float turnSpeed = 180f;
    public float health = 200f;
    public float speed;
    public bool dead = false;

    private ScoreKeeper scoreKeeper;
    public int scoreOverTime = 65;

    public LevelManager levelManager;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
        InvokeRepeating("ScorePoints", 0.0001f, 1.0f);
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
        int score = scoreKeeper.score;
       
        if (PlayerPrefs.GetInt("highestScore") <= score)
        {
            PlayerPrefs.SetInt("highestScore", score);
        }
        print("The highest score: " + PlayerPrefs.GetInt("highestScore"));
        
        dead = true;
        print("Game Over");
        GetComponent<SpriteRenderer>().enabled = false;
        levelManager.LoadLevel("Lose");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ProjectileEnemy missile = collision.gameObject.GetComponent<ProjectileEnemy>();
        if (missile)
        {
            health -= missile.getDamage();
            missile.Hit();
            if(health <= 0)
            {
                Die();
                
            }
            
        }
    }
    public void ScorePoints()
    {
        scoreKeeper.Score(scoreOverTime);
    }    
}
