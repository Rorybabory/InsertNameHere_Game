
using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {
	GameObject mainCamera;
	bool carrying;
	GameObject carriedObject;
	public float distance;
	public float smooth;
	public float minDist;
	private GameObject player;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag("MainCamera");
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		if(carrying) {
			carry(carriedObject);
			checkDrop();
			//rotateObject();
		} else {
			pickup();
		}
	}

	void rotateObject() {
		carriedObject.transform.Rotate(5,10,15);
	}

	void carry(GameObject o) {
		o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
		o.transform.rotation = Quaternion.identity;
	}

	void pickup() {
		if(Input.GetKeyDown (KeyCode.E)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				if(hit.rigidbody.tag == "OxygenTank"){
					player.GetComponent<charController> ().airGain (30.0f);
					Destroy (hit.rigidbody.gameObject);
				}
				if(hit.rigidbody.tag == "SmallOxygenTank"){
					player.GetComponent<charController> ().airGain (15.0f);
					Destroy (hit.rigidbody.gameObject);
				}
				if(hit.rigidbody.tag == "LargeOxygenTank"){
					player.GetComponent<charController> ().airGain (50.0f);
					Destroy (hit.rigidbody.gameObject);
				}
				if (hit.rigidbody.tag == "HealthPack") {
					player.GetComponent<charController> ().healthGain (25.0f);
					Destroy (hit.rigidbody.gameObject);
				}
				if (hit.rigidbody.tag == "LargeHealthPack") {
					player.GetComponent<charController> ().healthGain (50.0f);
					Destroy (hit.rigidbody.gameObject);
				}
				Pickupable p = hit.collider.GetComponent<Pickupable>();
				if(p != null && Vector3.Distance(transform.position,p.gameObject.transform.position)<=minDist) {
					carrying = true;
					carriedObject = p.gameObject;
					//p.gameObject.rigidbody.isKinematic = true;
					p.gameObject.GetComponent<Rigidbody>().useGravity = false;
				}
			}
		}
	}

	void checkDrop() {
		if(Input.GetKeyDown (KeyCode.E)) {
			dropObject();
		}
	}

	void dropObject() {
		carrying = false;
		//carriedObject.gameObject.rigidbody.isKinematic = false;
		carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
		carriedObject = null;
	}
}
