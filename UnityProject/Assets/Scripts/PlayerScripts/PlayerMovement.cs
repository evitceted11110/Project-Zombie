using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed;
	public float rotateSpeed;

	void Awake () {

	}

	void Update () {
		Movement();
	}

	void Movement () {
		if (Input.GetKey(KeyCode.W)) {
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S)) {
			transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.A)) {
			transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.D)) {
			transform.Translate(Vector3.left * -moveSpeed * Time.deltaTime);
		}
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime);

	}
}
