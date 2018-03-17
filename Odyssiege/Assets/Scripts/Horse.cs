using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Horse : MonoBehaviour {

    public bool multiplayerEnabled = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.M))
        {
            ToggleMultiplayer();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    private void ToggleMultiplayer()
    {
        multiplayerEnabled = !multiplayerEnabled;
        Debug.Log("multiplayer enabled: " + multiplayerEnabled);
        if (multiplayerEnabled)
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
        else
        {
            var tails = GetComponents<Tail>();
            foreach (Tail tail in tails)
            {
                tail.playerId = 0;
                tail.player = ReInput.players.GetPlayer(0);
            }


            var wheels = GetComponents<Wheel>();
            foreach (Wheel wheel in wheels)
            {
                wheel.playerId = 0;
                wheel.player = ReInput.players.GetPlayer(0);
            }
        }
    }
}
