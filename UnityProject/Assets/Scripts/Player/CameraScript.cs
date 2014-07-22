using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float max, min;

	private Transform t;
	private Transform pt;

	void Start () {
		max = 320f;
		min = 80f;
	}
	
	void Update () {
		transform.Rotate (Vector3.left * Input.GetAxis ("MouseY") * GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().rotateSpeed * 100 * Time.deltaTime);

		if (transform.eulerAngles.x < max && transform.eulerAngles.x > 300f) {
			transform.eulerAngles = new Vector3(max, transform.eulerAngles.y, transform.eulerAngles.z);
		}
		if (transform.eulerAngles.x > min && transform.eulerAngles.x < 100f) {
			transform.eulerAngles = new Vector3(min, transform.eulerAngles.y, transform.eulerAngles.z);
		}
	}
}
