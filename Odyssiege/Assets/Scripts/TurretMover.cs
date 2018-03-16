using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		var speed = 1000.0f;

		var rigid = gameObject.GetComponent<Rigidbody2D> ();

		var moveForce = new Vector2 ();

		/* This will get removed, only used for testing */
		if (Input.GetKey (KeyCode.W)) {
			moveForce.y += 1;
		}

		if (Input.GetKey (KeyCode.S)) {
			moveForce.y -= 1;
		}

		if (Input.GetKey (KeyCode.D)) {
			moveForce.x += 1;
		}

		if (Input.GetKey (KeyCode.A)) {
			moveForce.x -= 1;
		}

		moveForce.Normalize ();

		rigid.AddForce (moveForce * speed * Time.deltaTime);

		if (Input.GetKey (KeyCode.Q)) {
			transform.Rotate (new Vector3 (0, 0, -45.0f * Time.deltaTime));
		}

		if (Input.GetKey (KeyCode.E)) {
			transform.Rotate (new Vector3 (0, 0, 45.0f * Time.deltaTime));
		}
	}
}
