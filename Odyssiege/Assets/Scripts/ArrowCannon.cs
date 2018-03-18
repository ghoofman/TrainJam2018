using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class ArrowCannon : MonoBehaviour {

	[Tooltip("The source GameObject you want to spawn")]
	public GameObject ArrowPrefab;

    public int playerId;
    public Player player;

	public GameObject currentArrow = null;

	// Use this for initialization
	void Start () {
		currentArrow = Instantiate (ArrowPrefab, transform.position, Quaternion.identity);
		currentArrow.transform.SetParent (transform);
		currentArrow.transform.rotation = Quaternion.Euler (0, 0, 45.0f);
        currentArrow.GetComponent<BombArrow>().player = player;
	}
	
	// Update is called once per frame
	void Update () {
		var bombArrow = currentArrow.GetComponent<BombArrow> ();

		if(!bombArrow.isAlive) {
			bombArrow.isAlive = true;
			bombArrow.collided = false;
			bombArrow.started = false;
			bombArrow.oneJump = false;
			// currentArrow = Instantiate (ArrowPrefab, transform.position, Quaternion.identity);
			currentArrow.transform.SetParent (transform);
			currentArrow.transform.position = transform.position; // + new Vector3(0.1f, 0.1f, 0);
			currentArrow.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 45);
		}
	}
}
