using UnityEngine;
using System.Collections;


[RequireComponent (typeof(Controller2D))]
public class Player : MonoBehaviour {

	public float jumHeight = 4;
	public float timeToJumpApex = .4f;

	float accelerationTimeAirborne;
	float accelerationTimeGrounded;
	float moveSpeed = 5;
	float gravity;
	Vector3 velocity;
	float velocityXSmoothing;

	float jumpVelocity;

	Controller2D controller;


	void Start () {
		controller = GetComponent<Controller2D> ();

		gravity = -(2 * jumHeight) / Mathf.Pow (timeToJumpApex, 2);

		jumpVelocity = Mathf.Abs (gravity) * timeToJumpApex;	
	
		print ("Gravity:" + gravity + "JumpVelocity:" + jumpVelocity);
	}
	

	void Update () {

		if (controller.collisions.above || controller.collisions.below) {

			velocity.y = 0;
		
		}


		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal") , Input.GetAxisRaw("Vertical"));

		if (Input.GetKeyDown (KeyCode.Z) && controller.collisions.below) {
		
			velocity.y = jumpVelocity;
		}



		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX , ref velocityXSmoothing , (controller.collisions.below)? accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}
}
