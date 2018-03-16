using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using System;

public class Tail : MonoBehaviour {

    Player player;
    public int playerId = 0;
    private const float minAngle = 20.0f;
    private float desiredAngle = 0.0f;
    private const float maxAngle = 80.0f;

    // Use this for initialization
    void Start () {
		
	}

    void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
        gameObject.GetComponent<Rigidbody2D>().MoveRotation(minAngle);
    }

    // Update is called once per frame
    void Update () {
        float tailAngle = player.GetAxis("TailAngle");
        desiredAngle = minAngle + (tailAngle * maxAngle);
        gameObject.GetComponent<Rigidbody2D>().MoveRotation(desiredAngle);

        Debug.Log("TailAngle");

        if (Input.GetKeyUp(KeyCode.K))
        {
            Debug.Log("Adding K");
        }
    }

    private bool ReachedDesiredAngle()
    {
        if (gameObject.GetComponent<Rigidbody2D>().rotation - desiredAngle < 1.0f)
        {
            Debug.Log("Hit max");
            return true;
        }

        Debug.Log("gameObject.GetComponent<Rigidbody2D>().rotation" + gameObject.GetComponent<Rigidbody2D>().rotation);
        return false;
    }
}
