using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController2D))]
public class PlayerInput : MonoBehaviour {

	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	public float moveSpeed = 6;

	private float accelerationTimeAirborne = .2f;
	private float accelerationTimeGrounded = .1f;

	private float gravity;
	private float jumpVelocity;
	private Vector3 velocity;
	private float velocityXSmoothing;

	CharacterController2D controller;

	void Start() {
		controller = GetComponent<CharacterController2D> ();
	}

	void Update() {
		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (Input.GetAxisRaw ("Jump") != 0 && controller.collisions.below) {
			velocity.y = jumpVelocity;
		}

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}
}