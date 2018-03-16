using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Tail : MonoBehaviour {
	float mass = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.K))
        {
            Debug.Log("Adding K");
            gameObject.GetComponent<Rigidbody2D>().AddTorque(100.0f);
		}
		if (Input.GetKeyUp(KeyCode.M))
		{
			mass += 1.0f;
			gameObject.GetComponent<Rigidbody2D> ().mass = mass;
		}
		if (Input.GetKeyUp(KeyCode.N))
		{
			mass -= 1.0f;
			gameObject.GetComponent<Rigidbody2D> ().mass = mass;
		}
		
	}
}
