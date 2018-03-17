using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMove : MonoBehaviour {

	public GameObject ObjectToTransition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!ObjectToTransition) {
			return;
		}
		if (ObjectToTransition.GetComponent<TransitionFade> ().CanRunAnimation) {
			var pos = transform.position;
			pos.x += 10.0f * Time.deltaTime;
			transform.position = pos;

			if (transform.position.x > 16 && ObjectToTransition) {
				ObjectToTransition.GetComponent<TransitionFade> ().BeginEnd ();
			}
		}
	}
}
