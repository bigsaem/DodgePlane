using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    private float bombSize = 100;
    private float currentSize = 1;
    private Vector3 startScale = Vector3.one;
    public ParticleSystem bombEffect;


    public void Explode()
    {
        ParticleSystem ps = Instantiate<ParticleSystem>(bombEffect);
        ps.transform.position = transform.position;
        ps.transform.parent = transform.parent;
        ps.Play();
        StartCoroutine(StartBomb());
    }

    IEnumerator StartBomb()
    {
        transform.localScale = startScale;
        currentSize = 1;
        while(currentSize < bombSize)
        {
            currentSize += Time.deltaTime * 80;
            transform.localScale = startScale * currentSize;
            yield return new WaitForEndOfFrame();
        }
        GetComponentInParent<Player>().invulnerable = false;
        gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<EnemyUnit>() != null)
        {
            col.GetComponent<EnemyUnit>().Die();
        }
    }
}
