using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Horse : MonoBehaviour {

    public bool multiplayerEnabled = false;

    private void Awake()
    {
        Globals.horse = transform.GetChild(0).GetChild(0);
        ToggleMultiplayer();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Globals.horse.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 0f));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Globals.horse.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f, 0f));
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            ToggleMultiplayer();
        }

        if (Input.GetKeyUp(KeyCode.R) || ReInput.players.GetPlayer(0).GetButtonUp("Start") || ReInput.players.GetPlayer(1).GetButtonUp("Start") || ReInput.players.GetPlayer(2).GetButtonUp("Start") || ReInput.players.GetPlayer(3).GetButtonUp("Start"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void ToggleMultiplayer()
    {
        multiplayerEnabled = !multiplayerEnabled;
        Debug.Log("multiplayer enabled: " + multiplayerEnabled);
        if (multiplayerEnabled)
        {
            if (Globals.playerMap != null && Globals.playerMap.Length > 1)
            {
                ProperAssignment();
            }
            else
            {
                RandomAssignment();
            }
        }
        else
        {
            SinglePlayerAssignment();
        }

    }

    private void ProperAssignment()
    {
        var tails = GetComponentsInChildren<Tail>();
        foreach (Tail tail in tails)
        {
            if (tail.gameObject.name == "Tail")
            {
                tail.playerId = Globals.playerMap[0];
                tail.player = ReInput.players.GetPlayer(tail.playerId);
            } else if (tail.gameObject.name == "Head")
            {
                tail.playerId = Globals.playerMap[3];
                tail.player = ReInput.players.GetPlayer(tail.playerId);
            }
        }

        var wheels = GetComponentsInChildren<Wheel>();
        foreach (Wheel wheel in wheels)
        {
            if (wheel.gameObject.name == "Wheel-Wood-Big")
            {
                wheel.playerId = Globals.playerMap[1];
                wheel.player = ReInput.players.GetPlayer(wheel.playerId);
            } else if (wheel.gameObject.name == "Wheel-Wood-Small")
            {
                wheel.playerId = Globals.playerMap[2];
                wheel.player = ReInput.players.GetPlayer(wheel.playerId);
            }
        }

        var laser = GetComponentInChildren<LaserDestruct>();
        if (laser != null)
        {
            laser.playerId = Globals.playerMap[2];
            laser.player = ReInput.players.GetPlayer(laser.playerId);
        }

        var arrowCannon = GetComponentInChildren<ArrowCannon>();
        if (arrowCannon != null)
        {
            arrowCannon.playerId = Globals.playerMap[0];
            arrowCannon.player = ReInput.players.GetPlayer(arrowCannon.playerId);
        }
    }

    private void RandomAssignment()
    {
        Debug.Log("multiplayer enabled2: " + multiplayerEnabled);

        int playerId = 0;
        var tails = GetComponentsInChildren<Tail>();
        foreach (Tail tail in tails)
        {
            tail.playerId = playerId;
            tail.player = ReInput.players.GetPlayer(playerId);
            ++playerId;
        }


        var wheels = GetComponentsInChildren<Wheel>();
        foreach (Wheel wheel in wheels)
        {
            wheel.playerId = playerId;
            wheel.player = ReInput.players.GetPlayer(playerId);
            ++playerId;
        }
    }

    void SinglePlayerAssignment()
    {
        Debug.Log("enabling single player");
        var tails = GetComponentsInChildren<Tail>();
        foreach (Tail tail in tails)
        {
            tail.playerId = 0;
            tail.player = ReInput.players.GetPlayer(0);
        }


        var wheels = GetComponentsInChildren<Wheel>();
        foreach (Wheel wheel in wheels)
        {
            wheel.playerId = 0;
            wheel.player = ReInput.players.GetPlayer(0);
        }
    }
}
