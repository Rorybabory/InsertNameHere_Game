using UnityEngine;
using System.Collections;

public class camMouseLook : MonoBehaviour {
	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;
	public float max_rotation;
	public float min_rotation;
	private float current_rotation=0;
	private float roty;
	GameObject character;
	// Use this for initialization
	void Start () {
		character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		


		var md = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));
		md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
		mouseLook += smoothV;

		mouseLook.y = (mouseLook.y < min_rotation) ? min_rotation : mouseLook.y;
		mouseLook.y = (mouseLook.y > max_rotation) ? max_rotation : mouseLook.y;
		transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x,character.transform.up);

}
}
