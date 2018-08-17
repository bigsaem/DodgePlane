using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour {
    public GameObject explosion;
    protected ScoreKeeper scoreKeeper;

    protected virtual void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    public void Die()
    {
        //AudioSource.PlayClipAtPoint(explode, transform.position);
        //GetComponent<SpriteRenderer>().enabled = false;
        //GetComponent<Collider2D>().enabled = false;
        //GetComponent<TrailRenderer>().enabled = false;
        AddScore();
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Invoke("DestroyThis", 1.5f);
        
    }

    protected virtual void AddScore()
    {

    }

    protected void DestroyThis()
    {
        Destroy(gameObject);
    }
}
