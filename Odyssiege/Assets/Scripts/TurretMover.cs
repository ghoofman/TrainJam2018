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
		/* This will get removed, only used for testing */
		if (Input.GetKey (KeyCode.W)) {
			rigid.AddForce (new Vector2 (0, speed * Time.deltaTime));
			//transform.Translate (new Vector3 (0, 1.0f * Time.deltaTime, 0));
		}

		if (Input.GetKey (KeyCode.S)) {
			rigid.AddForce (new Vector2 (0, -speed * Time.deltaTime));
			//transform.Translate (new Vector3 (0, -1.0f * Time.deltaTime, 0));
		}

		if (Input.GetKey (KeyCode.D)) {
			rigid.AddForce (new Vector2 (speed * Time.deltaTime, 0));
			//transform.Translate (new Vector3 (1.0f * Time.deltaTime, 0, 0));
		}

		if (Input.GetKey (KeyCode.A)) {
			rigid.AddForce (new Vector2 (-speed * Time.deltaTime, 0));
			//transform.Translate (new Vector3 (-1.0f * Time.deltaTime, 0, 0));
		}

		if (Input.GetKey (KeyCode.Q)) {
			transform.Rotate (new Vector3 (0, 0, -45.0f * Time.deltaTime));
		}

		if (Input.GetKey (KeyCode.E)) {
			transform.Rotate (new Vector3 (0, 0, 45.0f * Time.deltaTime));
		}
	}
}
