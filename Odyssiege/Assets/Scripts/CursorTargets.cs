using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorTargets : MonoBehaviour {

    private Player player;

    public Image[] targets;
    public Image[] cursors;
    private bool[] playerChosen = new bool[] { false, false, false, false };
    private bool[] targetChosen = new bool[] { false, false, false, false };
    private float margin = 25f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var showOutline = new bool[] { false, false, false, false };
        for (int i = 0; i < 4; i++)
        {
            if (playerChosen[i])
                continue;
            if (RefreshPlayer(i))
            {
                var move = player.GetAxis2D("LeftStickX", "LeftStickY");
                cursors[i].transform.Translate(new Vector3(move.x, move.y, 0f) * Time.deltaTime * 200f);
                for (int j = 0; j < 4; j++)
                {
                    if (targetChosen[j])
                        continue;
                    // check distance
                    if ((cursors[i].transform.position - targets[j].transform.position).sqrMagnitude < margin)
                    {
                        showOutline[j] = true;
                        if (player.GetButtonDown("A"))
                        {
                            playerChosen[i] = true;
                            targetChosen[j] = true;
                            Debug.Log("Player " + i + " chose " + j);
                        }
                    }
                }
            }
        }
    }

    private bool RefreshPlayer(int owner)
    {
        if (!ReInput.isReady) return false;
        player = ReInput.players.GetPlayer(owner);
        return true;
    }
}
