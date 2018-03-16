using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.S)) {
			gameObject.GetComponent<Rigidbody2D> ().simulated = true;
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (1000.0f, 0.0f));
		}
	}
}
