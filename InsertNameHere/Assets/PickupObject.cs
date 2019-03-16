using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {
	GameObject mainCamera;
	GameObject player;

	bool carrying;
	GameObject carriedObject;
	public float distance;
	public float smooth;
	public float minDist;
	int ignoreTimer = 0;
	bool isIgnoring = false;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag("MainCamera");
		player = GameObject.FindWithTag ("Player");
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
		if (isIgnoring == true) {
			ignoreTimer++;
			if (ignoreTimer > 10) {
				isIgnoring = false;
				Physics.IgnoreCollision(carriedObject.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
			}
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
				Pickupable p = hit.collider.GetComponent<Pickupable>();
				if(p != null && Vector3.Distance(transform.position,p.gameObject.transform.position)<=minDist) {
					carrying = true;
					carriedObject = p.gameObject;
					//p.gameObject.rigidbody.isKinematic = true;
					carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					p.gameObject.GetComponent<Rigidbody>().useGravity = false;
					carriedObject.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0.0f,0.0f,0.0f);
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
		carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
		carriedObject.gameObject.GetComponent<Rigidbody> ().useGravity = true;
		carriedObject.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0.0f,0.0f,0.0f);
		Physics.IgnoreCollision(carriedObject.GetComponent<Collider>(), player.GetComponent<Collider>());
		carriedObject.gameObject.GetComponent<Rigidbody> ().velocity = carriedObject.gameObject.GetComponent<Rigidbody> ().velocity * 0.0f;
		isIgnoring = true;
		ignoreTimer = 0;
	}
}
