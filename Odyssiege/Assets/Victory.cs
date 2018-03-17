using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Victory : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!ReInput.isReady)
			return;
		
		foreach (var player in ReInput.players.AllPlayers) {
			if (player.GetAnyButtonDown ()) {
				GetComponent<LevelController> ().Reset ();
			}
		}
	}
}
