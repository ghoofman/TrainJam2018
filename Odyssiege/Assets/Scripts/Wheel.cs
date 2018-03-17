using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {
    private const float directionalSensitivity = 0.25f;
    public int playerId = 0;
    public Player player;
    public string xAxis = "LeftStickX";
    public string yAxis = "LeftStickY";

    private Vector2 lastDirection;

    void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float tempXAxis = player.GetAxis(xAxis);
        float tempYAxis = player.GetAxis(yAxis);

        Vector2 axis = new Vector2(tempXAxis, tempYAxis);
        
        if (axis.magnitude > 0.5f)
        {
            Vector2 normalized = axis.normalized;
            float newRotation = Vector2.SignedAngle(Vector2.right, normalized);
            GetComponent<Rigidbody2D>().MoveRotation(newRotation);
        }
    }
}
