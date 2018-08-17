using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : EnemyUnit {
    Player player;
    ScoreKeeper scoreKeeper;
    
    public int scoreValue;
    private void Awake()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > 15)
        {
            Destroy(gameObject);
        }
    }
    public float damage;

    public float getDamage()
    {
        return damage;
    }

    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Player>() != null)
        {
            scoreKeeper.Score(scoreValue);
            Instantiate(explosion, transform.position, Quaternion.identity);
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
        /*
        else if (col.GetComponent<GuidedProjectile>() != null)
        {
            scoreKeeper.Score(scoreValue);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
        */
        else if (col.GetComponent<Projectile>() != null)
        {
            scoreKeeper.Score(scoreValue);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
    }
    
}
