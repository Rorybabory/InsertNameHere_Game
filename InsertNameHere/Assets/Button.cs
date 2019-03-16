using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
	public bool pressed;

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
			pressed = false;
		}

	}
	// Update is called once per frame
	void Update () {
		
	}
}
