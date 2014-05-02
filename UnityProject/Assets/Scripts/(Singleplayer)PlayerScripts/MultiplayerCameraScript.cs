using UnityEngine;
using System.Collections;

public class MultiplayerCameraScript : MonoBehaviour {
	
	private Transform t;
	private Transform pt;

	private float rotateSpeed;

	void Start () {
		rotateSpeed = 10;
	}
	
	void Update () {
		transform.Rotate (Vector3.left * Input.GetAxis ("MouseY") * GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().rotateSpeed * 100 * Time.deltaTime);

		if (transform.eulerAngles.x < 320f && transform.eulerAngles.x > 300f) {
			transform.eulerAngles = new Vector3(320f, transform.eulerAngles.y, transform.eulerAngles.z);
		}
		if (transform.eulerAngles.x > 40f && transform.eulerAngles.x < 100f) {
			transform.eulerAngles = new Vector3(40f, transform.eulerAngles.y, transform.eulerAngles.z);
		}
	}
}
