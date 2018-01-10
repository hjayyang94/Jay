using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	public float gravity;
	public Vector3 moveDir;

	// Use this for initialization
	void Start () {
		moveSpeed = 20f;
		jumpForce = 20f;
		gravity = 30f;
		moveDir = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = gameObject.GetComponent<CharacterController> ();

        transform.Rotate(0, Input.GetAxis("Rotate") * 100 * Time.deltaTime,0f);

		if (controller.isGrounded) {

			moveDir = new Vector3 (0f, 0f, Input.GetAxis ("Vertical") * Time.deltaTime * moveSpeed);

			moveDir = transform.TransformDirection (moveDir);

			moveDir *= moveSpeed;

			if (Input.GetButtonDown ("Jump")) {
				moveDir.y = jumpForce;
			}
		}
	

		moveDir.y -= gravity * Time.deltaTime;

		controller.Move (moveDir * Time.deltaTime);

	}
}
