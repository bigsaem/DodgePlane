using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    Player player;
    public Renderer rend;
    
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.position = player.transform.position;
        //transform.Rotate(0, 0, player.getAngle());
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, player.getTurnSpeed() * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -player.getTurnSpeed() * Time.deltaTime);
        }
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].position.x > Screen.width / 2)
            {
                transform.Rotate(0, 0, -player.getTurnSpeed() * Time.deltaTime);
            }
            if (Input.touches[0].position.x < Screen.width / 2)
            {
                transform.Rotate(0, 0, player.getTurnSpeed() * Time.deltaTime);
            }
        }
    }
    public void RenderOff()
    {
        rend.enabled = false;
    }
    public void RenderOn()
    {
        rend.enabled = true;
    }
}
