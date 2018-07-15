using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

    public GameObject projectile;
    Player player;
    public float speed = 1;
    public bool startMoving;
    public float shorsPerSecond = 0.5f;
    public float projectileSpeed;
    public AudioClip fireSound;
    //private ScoreKeeper scoreKeeper;
    //public int scoreValue = 150;


    private void Start()
    {
        //scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
        
    }
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        float probability = Time.deltaTime * shorsPerSecond;
        if(Random.value < probability)
        {
            Fire();
        }
        

    }

    void Fire()
    {
        Vector3 startPosition = transform.position + new Vector3(0, 0, 0);
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(fireSound, transform.position);


        var heading = missile.transform.position - player.transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        

        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(-direction.x * projectileSpeed , -direction.y * projectileSpeed);
    }

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
            player.Die();
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    
}
