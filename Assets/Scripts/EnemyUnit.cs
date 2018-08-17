using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour {
    public GameObject explosion;

    public void Die()
    {
        //AudioSource.PlayClipAtPoint(explode, transform.position);
        //GetComponent<SpriteRenderer>().enabled = false;
        //GetComponent<Collider2D>().enabled = false;
        //GetComponent<TrailRenderer>().enabled = false;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Invoke("DestroyThis", 1.5f);
        
    }

    protected void DestroyThis()
    {
        Destroy(gameObject);
    }
}
