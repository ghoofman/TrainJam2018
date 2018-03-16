using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		/* This will get removed, only used for testing */
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (new Vector3 (0, 1.0f * Time.deltaTime, 0));
		}

		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (new Vector3 (0, -1.0f * Time.deltaTime, 0));
		}

		if (Input.GetKey (KeyCode.Q)) {
			transform.Rotate (new Vector3 (0, 0, -20.0f * Time.deltaTime));
		}

		if (Input.GetKey (KeyCode.E)) {
			transform.Rotate (new Vector3 (0, 0, 20.0f * Time.deltaTime));
		}
	}
}
