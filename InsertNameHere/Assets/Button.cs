using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
	public bool pressed;
	bool UnPressing = false;
	float UnPressTimer = 0.0f;
	float lastTime = 0.0f;
	public float delayTimer;
	// Use this for initialization
	void Start () {

	}
	void OnCollisionEnter(Collision col){
		Pickupable p = col.gameObject.GetComponent<Pickupable>();
		if (p != null){
			pressed = true;
		}
	}
	void OnCollisionExit(Collision col){
		Pickupable p = col.gameObject.GetComponent<Pickupable>();
		if (p != null){
			UnPressing = true;
			UnPressTimer = 0.0f;
			lastTime = Time.time + delayTimer;
		}

	}
	void FixedUpdate() {
		if (lastTime < Time.time && UnPressing == true) {
			pressed = false;
			UnPressing = false;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
