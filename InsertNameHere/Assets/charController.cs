using UnityEngine;
using System.Collections;

public class charController : MonoBehaviour {
	public float speed = 10.0F;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	// Use this for initialization
	bool canJump = true;
	Rigidbody rb;
	public float jump;
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		rb = GetComponent<Rigidbody> ();
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
	// Update is called once per frame
	void Update () {
		float translation = Input.GetAxis ("Vertical") * speed;
		float straffe = Input.GetAxis ("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;
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
