using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class WeightAdjust : MonoBehaviour {
	public int playerId = 0;
	public Player player;
	public string Trigger = "RT";

	void Awake()
	{
		player = ReInput.players.GetPlayer(playerId);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float tempXAxis = player.GetAxis(Trigger);
		GetComponent<Rigidbody2D> ().mass = 10.0f + (50.0f * tempXAxis);
	}
}
