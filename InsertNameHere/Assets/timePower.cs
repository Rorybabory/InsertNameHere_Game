using UnityEngine;
using System.Collections;

public class timePower : MonoBehaviour {
	GameObject recorded;
	Vector3 positionRecorded;
	public float minDist;
	GameObject mainCamera;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag("MainCamera");
	}
	void play() {
		if(Input.GetKeyDown (KeyCode.P)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;
			Debug.Log ("Playing");
			Vector3 V = new Vector3 (0.5f,0.5f,0.5f);
			recorded.transform.position = positionRecorded;
		}
	}
	void record() {
		if(Input.GetKeyDown (KeyCode.R)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				Pickupable p = hit.collider.GetComponent<Pickupable>();
				if(p != null) {
					Debug.Log ("Recorded");
					recorded = p.gameObject;
					positionRecorded = p.gameObject.transform.position;
				}
			}
		}
	}
	// Update is called once per frame
	void Update () {
		play ();
		record ();
	}
}
