using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    // Creating variables
    public float curSpeed, moveSpeed, sprintSpeed, sprintTime;
	public float rotateSpeed;
	public float jumpSpeed;
	public float fallSpeed;
	public float gravity;

    private float curSprintTime;
    private bool sprinting, canSprint, maxSprint;

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;

	void Start () {
		controller = GetComponent<CharacterController>();
        curSprintTime = 0;

        sprinting = false;
        canSprint = true;
        maxSprint = false;

        // Remember to set ALL variables to a default value here before releasing game!
	}

	void Update() {
        Movement();
	}

    void Movement() { // Just putting all movement-related code in one function for organazing
        if (controller.isGrounded)
        {
            #region Sprint
            // Later on we will have to add code for the regeneration of sprint so that we can't sprint half of the time

            if (Input.GetAxis("Sprint") > 0 && curSprintTime < sprintTime && canSprint)         // Checks if we have pressed the "Sprint" button, if the current sprint time is less than sprint time so we can't sprint forever and checks if we are able to sprint, also to make sure we can't sprint forever
            {
                curSpeed = sprintSpeed;                 // Sets the speed to sprint speed. This will later on need an algorithm for calculating the sprint speed depending on weight etc.
                sprinting = true;                       // We are sprinting
                curSprintTime += Time.deltaTime;        // Adds time to current sprint time so we can't sprint forever

                if (curSprintTime > sprintTime)         // If our current sprint time is greater than sprint time we can't sprint any longer...    
                    canSprint = false;                  // ...therefore we set can sprint to false. This way the player have to plan ahead and try to judge if he really needs to sprint

            }
            else    // If we can't sprint, regenerate
            {
                if (sprinting)      // If we sprinted the last frame set it to false
                    sprinting = false; 

                curSpeed = moveSpeed;       // Set the speed back to walk/run
                if (curSprintTime > 0)      // If the current sprint time is greater than 0, regenerate
                    curSprintTime -= Time.deltaTime;
                else
                    curSprintTime = 0;

                if (curSprintTime < sprintTime / 4)     // How long before we can sprint again, which is sprint time divided by 4
                    canSprint = true;

            }
            #endregion

            #region Unity Example Movement Code
        
            moveDirection = new Vector3(Input.GetAxis("LeftRight"), 0, Input.GetAxis("ForwardBackward"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= curSpeed;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

            #endregion

        }

        #region Unity Example Movement Code 2

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        transform.Rotate(Vector3.up * Input.GetAxis("MouseX") * rotateSpeed * Time.deltaTime * 100);
        #endregion
    }

	void OnGUI () {
        GUI.Box (new Rect (10, 10, Screen.width / 4, 30), "Sprinting: " + sprinting + "  Time: "  + curSprintTime + "  Can sprint: " + canSprint);


	}
}






