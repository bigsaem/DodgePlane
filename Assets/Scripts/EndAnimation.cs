using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : MonoBehaviour {
    public float delay = 0.8f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length + delay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
