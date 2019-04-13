using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class charController : MonoBehaviour {

	private bool inSpace = false;
	public float health = 100;
	public float oxygen = 100;
	public float speed = 10.0F;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	public AudioClip metalRunning;

	private Text text;

	// Use this for initialization
	bool canJump = true;
	Rigidbody rb;
	public float jump;
	void Start () {

		Cursor.lockState = CursorLockMode.Locked;
		rb = GetComponent<Rigidbody> ();
		text = GameObject.FindWithTag ("UI").GetComponent<Text> ();
	}
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Ground") {
			canJump = true;
		}
	}
	void OnCollisionExit(Collision other) {
		if (other.gameObject.tag == "Ground") {
			canJump = false;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Space"){
			inSpace = true;
		}
	}
	void OnTriggerExit(Collider other){
		if(other.tag == "Space"){
			inSpace = false;

		}
	}
	public void airGain(float oxygenAmount){
		if (oxygen + oxygenAmount > 100) {
			oxygen = 100;
		} 
		else {
			oxygen = oxygen + oxygenAmount;
		}


	}
	public void Healthloss(float damage){
		health = health - damage;

	}
	public void healthGain (float healing) {
		if (health + healing > 100) {
			health = 100;
		}
		else {
			health = health + healing;

		}
	}
	void fixedUpdate(){
		if (inSpace){
			if ((oxygen - .01f) < 0) {
				oxygen = 0;
			}
			else {
				oxygen = oxygen - 0.07f;
			}
			if (oxygen <= 0) {
				if((health- 0.05f) < 0) {
					health = 0;
					Application.LoadLevel (Application.loadedLevel);
				}
				else {
					health = health - 0.01f;
				}
			}
		}

	}
	// Update is called once per frame
	void Update () {

		text.text = "Health: " + Mathf.Round(health) + "    ||   Oxygen:" + Mathf.Round(oxygen);
		float translation = Input.GetAxis ("Vertical") * speed;
		float straffe = Input.GetAxis ("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;

		if (canJump && (straffe != 0 || translation != 0)) {
			//playerSpeaker.clip = metalRunning;

		}
		transform.Translate (straffe,0,translation);
		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}
		if (Input.GetKeyDown (KeyCode.Tab)) {
			Cursor.lockState = CursorLockMode.Locked;
		}
		if (Input.GetKeyDown (KeyCode.Space) && canJump) {
			rb.velocity = Vector3.up * jump;
		}
		if (rb.velocity.y < 0 && canJump) {
			rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}
	}
}

