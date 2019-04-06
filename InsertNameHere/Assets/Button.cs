using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
	public bool pressed;
	public bool down;
	public float fireRate = 1.0f;
	public float nextFire = 0.0f;
	// Use this for initialization
	void Start () {

	}
	void OnCollisionEnter(Collision col){
		Pickupable p = col.gameObject.GetComponent<Pickupable>();
		if (p != null){
			
			down = true;
		}

	}
	void OnCollisionExit(Collision col){
		Pickupable p = col.gameObject.GetComponent<Pickupable>();
		if (p != null){
			nextFire = Time.time + fireRate;
			down = false;
		}

	}
	// Update is called once per frame
	void Update () {
		if (down == false && Time.time > nextFire) {
			pressed = false;
		} else if (down == true) {
			pressed = true;
		}
	}
}
