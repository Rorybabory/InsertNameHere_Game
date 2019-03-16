using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorHandler : MonoBehaviour {
	public GameObject left;
	public GameObject right;
	public GameObject center;
	public float speed;
	public bool open;
	public GameObject button;
	float startY;
	float startX;
	float startZ;
	// Use this for initialization
	void Start () {
		startY = center.transform.position.y;
		startX = center.transform.position.x;
		startZ = center.transform.position.z;
	}
	void Open() {
		Debug.Log(right.transform.position.z);
		if (center.transform.position.y <= startY+5.0f) {
			float offset = speed*Time.deltaTime;
			center.transform.position = new Vector3(center.transform.position.x,center.transform.position.y+offset,center.transform.position.z);
		}
		if (left.transform.position.z >= startZ-2.0f) {
			float offset = speed*Time.deltaTime;
			left.transform.position = new Vector3(left.transform.position.x,left.transform.position.y,left.transform.position.z-offset);
		}
		if (right.transform.position.z <= startZ+2.0f) {
			float offset = speed*Time.deltaTime;
			right.transform.position = new Vector3(right.transform.position.x,right.transform.position.y,right.transform.position.z+offset);

		}
	}
	void Close(){
		if (center.transform.position.y >= startY) {
			float offset = speed*Time.deltaTime;
			center.transform.position = new Vector3(center.transform.position.x,center.transform.position.y-offset,center.transform.position.z);
		}
		if (left.transform.position.z <= startZ) {
			float offset = speed*Time.deltaTime;
			left.transform.position = new Vector3(left.transform.position.x,left.transform.position.y,left.transform.position.z+offset);
		}
		if (right.transform.position.z >= startZ) {
			float offset = speed*Time.deltaTime;
			right.transform.position = new Vector3(right.transform.position.x,right.transform.position.y,right.transform.position.z-offset);
		}
	}
	// Update is called once per frame
	void Update () {
		open = button.gameObject.GetComponent<Button>().pressed;

		if (open == true){
			Open();
		}else{
			Close();
		}
	}
}
