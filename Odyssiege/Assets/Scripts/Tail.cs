using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using System;

public class Tail : MonoBehaviour {
    public string axis = "TailAngle";
    Player player;
    public int playerId = 0;
    public float minAngle = 20.0f;
    private float desiredAngle = 0.0f;
    public float maxAngle = 80.0f;
    private float maxAngleDelta = 2.0f;

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
        float tailAngle = player.GetAxis(axis);
        desiredAngle = minAngle + (tailAngle * maxAngle);
        RotateTowards(desiredAngle);

        if (Input.GetKeyUp(KeyCode.K))
        {
            Debug.Log("Adding K");
        }
    }

    private void RotateTowards(float desiredAngle)
    {
        var angleDelta = desiredAngle - gameObject.GetComponent<Rigidbody2D>().rotation;
        var realAngleDelta = 0.0f;
        if (Mathf.Abs(angleDelta) < maxAngleDelta)
        {
            realAngleDelta = angleDelta;
        } else
        {
            if (angleDelta > 0.0f)
            {
                realAngleDelta = maxAngleDelta;
            }
            else
            {
                realAngleDelta = maxAngleDelta * -1.0f;
            }

        }

        float actualNewRotation = gameObject.GetComponent<Rigidbody2D>().rotation + realAngleDelta;
        gameObject.GetComponent<Rigidbody2D>().MoveRotation(actualNewRotation);
    }

    private bool ReachedDesiredAngle()
    {
        if (gameObject.GetComponent<Rigidbody2D>().rotation - desiredAngle < 1.0f)
        {
            Debug.Log("Hit desired");
            return true;
        }

        return false;
    }
}
