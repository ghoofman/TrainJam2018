using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class HorseJump : MonoBehaviour {

	public int playerId = 0;
	public Player player;
	public float liftOff = 100.0f;
	private float delayLeft = 0.0f;
	private float delayRight = 0.0f;

	void Awake()
	{
		player = ReInput.players.GetPlayer(playerId);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		delayLeft -= Time.deltaTime;
		delayRight -= Time.deltaTime;

		if (delayLeft <= 0.0f) {
			if (player.GetButtonDown ("LS") || Input.GetKeyDown (KeyCode.N)) {
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (1.0f, liftOff * 5.0f));
				delayLeft = 1.0f;
			}
		}

		if(delayRight <= 0.0f) {
			if (player.GetButtonDown ("RS") || Input.GetKeyDown (KeyCode.M)) {
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-1.0f, liftOff * 5.0f));
				delayRight = 1.0f;
			}
		}
	}
}