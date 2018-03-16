using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using System;

public class Tail : MonoBehaviour {

    Player player;
    public int playerId = 0;
    private bool ShouldMoveToAngle;
    private float desiredAngle = 20.0f;

    // Use this for initialization
    void Start () {
		
	}

    void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp(KeyCode.K))
        {
            Debug.Log("Adding K");
            ShouldMoveToAngle = true;
        }

        if (player.GetButtonDown("Fire"))
        {
            Debug.Log("Adding L");
        }

        if (ShouldMoveToAngle == true)
        {
            if (ReachedDesiredAngle())
            {
                ShouldMoveToAngle = false;
            } else
            {
                float newAngle = desiredAngle;
                gameObject.GetComponent<Rigidbody2D>().MoveRotation(newAngle);
            }
        }
    }

    private bool ReachedDesiredAngle()
    {
        Debug.Log("gameObject.GetComponent<Rigidbody2D>(): ", gameObject.GetComponent<Rigidbody2D>());

        if (gameObject.GetComponent<Rigidbody2D>().rotation == desiredAngle)
        {
            Debug.Log("Hit max");
            return true;
        }

        return false;
    }
}
