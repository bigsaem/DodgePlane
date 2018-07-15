using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour {
    Player player;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > 20)
        {
            Destroy(gameObject);
        }
    }
    public float damage = 100f;

    public float getDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
