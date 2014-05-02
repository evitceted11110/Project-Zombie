using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	
	private Transform t;
	private Transform pt;

	public float max;
	public float min;

	private float rotateSpeed;

	void Start () {
		transform.eulerAngles = Vector3.zero;
		rotateSpeed = 10;
	}
	
	void Update () {
		transform.Rotate (Vector3.left * Input.GetAxis ("MouseY") * GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().rotateSpeed * 100 * Time.deltaTime);

		if (transform.eulerAngles.x < max && transform.eulerAngles.x > 200f) {
			transform.eulerAngles = new Vector3(max, transform.eulerAngles.y, 0f);
		}
		if (transform.eulerAngles.x > min && transform.eulerAngles.x < 200f) {
			transform.eulerAngles = new Vector3(min, transform.eulerAngles.y, 0f);
		}
	}
}