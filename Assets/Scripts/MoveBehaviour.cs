using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour {

	public LayerMask groundL;
	public Transform transform;

	private float jumpForce = 9f;
	private float maximumSpeed = 12f;
	private float sprintMultiplier = 2f;
	private float baseSpeed = 2.0f;
	private Rigidbody2D rb;

	void Start() {
		transform = GetComponent<Transform>();
		rb = GetComponent<Rigidbody2D>();
	}


	void Update() {
		UpdateMovement();
	}

	void FixedUpdate() {
		if (Mathf.Abs(rb.velocity.x) > maximumSpeed)
			rb.velocity = new Vector2 (maximumSpeed * Mathf.Sign(rb.velocity.x),rb.velocity.y);
		
		rb.gravityScale = (rb.velocity.y < 0) ? 5 : 2;

	}

	void UpdateMovement() {

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded()) {
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}

		if (Input.GetKey(KeyCode.LeftArrow)) 
			rb.AddForce(Vector2.left * baseSpeed, ForceMode2D.Impulse);
		

		if (Input.GetKey(KeyCode.RightArrow)) 
			rb.AddForce(Vector2.right * baseSpeed, ForceMode2D.Impulse);
		

		if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow))
			rb.velocity = new Vector2 (0, rb.velocity.y);

		if(Input.GetKeyDown(KeyCode.LeftShift)) maximumSpeed *= sprintMultiplier;
		if(Input.GetKeyUp(KeyCode.LeftShift))   maximumSpeed /= sprintMultiplier;

	}

	bool isGrounded() {
		RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 3.0f, groundL);
		return ray.collider != null;
	}

}
