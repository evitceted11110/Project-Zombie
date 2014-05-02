using UnityEngine;
using System.Collections;

public class MultiplayerPlayerMovement : MonoBehaviour {

	public float moveSpeed;
	public float rotateSpeed;
	public float jumpSpeed;
	public float fallSpeed;
	public float gravity;

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;

	void Start () {
		controller = GetComponent<CharacterController>();
	}

	void Update() {
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("LeftRight"), 0, Input.GetAxis("ForwardBackward"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= moveSpeed;

			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		transform.Rotate (Vector3.up * Input.GetAxis("MouseX") * rotateSpeed * Time.deltaTime * 100);
	}
}
