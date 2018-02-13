using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;

	int maxNumJumps = 5;
	int curNumJump = 0;
	bool shouldJump = false;

	[SerializeField]
	float speed = 1; // Player speed

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> (); // Save value of rigid body attached to the game object
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space") && curNumJump < maxNumJumps && !shouldJump) {
			curNumJump++; // Add one to the number of jumps so far
			shouldJump = true; // Jump in the next FixedUpdate
		}
	}

	void FixedUpdate() {
		rb.velocity = new Vector2(Input.GetAxisRaw ("Horizontal") * speed, rb.velocity.y); // Move player left or right based on input

		// Jump
		if (shouldJump) {
			rb.velocity = new Vector2 (rb.velocity.x, 4);
			shouldJump = false; // Mark jump as processed
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Platform") {
			curNumJump = 0; // Reset number of jumps
		}
	}
}
