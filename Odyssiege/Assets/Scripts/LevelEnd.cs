using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject == Globals.horse.gameObject) {
			// level has been completed
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
			Globals.levelController.LoadTransition();
		}
	}
}
