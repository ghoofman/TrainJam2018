using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Destructible2D;
using Rewired;

public class BombArrow : MonoBehaviour {
	public D2dVector2Event OnImpact;
	public bool started = false;
	public bool collided = false;
	public bool oneJump = false;
	private Vector2 contactPoint;
	private Player player;

	public float ForceToAdd = 500.0f;
	private Rigidbody2D collidedWith;
	public float ExplosionForce = 500.0f;
	public Vector3 startingDir;

	public bool isAlive = false;

	// Use this for initialization
	void Start () {
		var rigid = gameObject.GetComponent<Rigidbody2D> ();
		rigid.simulated = false;
		startingDir = gameObject.transform.rotation * (new Vector3 (1, 0, 0));
		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		var rigid = gameObject.GetComponent<Rigidbody2D> ();

		if (started && !collided) {
			var normalVector = rigid.velocity.normalized;
			var dir3 = new Vector3 (normalVector.x, 0, normalVector.y);
			var angle = Vector3.Angle (new Vector3(1,0,0), dir3);

			if (dir3.z < 0) {
				transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
			} else {
				transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
			}


			Debug.Log ("Angle: " + angle);
			Debug.Log ("Dir: " + dir3.x + ", " + dir3.y + ", " + dir3.z);
		}
		for (int i = 0; i < 4; i++) {
			if (RefreshPlayer (i)) {
				if (player.GetButtonDown("A")) {
				// if (Input.GetKeyDown (KeyCode.Mouse0)) {
					if (!started) {
						started = true;
						var forceDir = (gameObject.transform.rotation * (new Vector3 (1, 0, 0)));
						rigid.velocity = new Vector2 (forceDir.x, forceDir.y);
						rigid.AddForce (forceDir * ForceToAdd);
						rigid.simulated = true;
						transform.SetParent (null);
						// rigid.AddTorque (-gameObject.transform.rotation.eulerAngles.z);
					} else {
						if (OnImpact != null) {
							if (collided) {
								OnImpact.Invoke (contactPoint);
								collidedWith.AddForceAtPosition (new Vector2 (ExplosionForce, 0), contactPoint);
								isAlive = false;
							} else {
								if (!oneJump) {
									oneJump = true;
									rigid.AddForce (new Vector3 (0, 1, 0) * ForceToAdd);
								} else {
									OnImpact.Invoke (transform.position);
									rigid.simulated = false;
									isAlive = false;
								}
							}
						}
						// Destroy (gameObject);
					}
				}
			}
		}
//		var rigid = gameObject.GetComponent<Rigidbody2D> ();
//		rigid.AddForce (new Vector2(10, 5));
	}

	protected virtual void OnCollisionEnter2D(Collision2D collision)
	{

		var contacts = collision.contacts;
		if (contacts.Length > 0) {
			collided = true;
			var rigid = gameObject.GetComponent<Rigidbody2D> ();
			rigid.simulated = false;
			Debug.Log ("Collided");

			contactPoint = contacts[0].point;
			collidedWith = contacts [0].rigidbody;
			// gameObject.transform.SetParent(collidedWith.transform);
		}
	}

	private bool RefreshPlayer(int owner)
	{
		if (!ReInput.isReady) return false;
		player = ReInput.players.GetPlayer(owner);
		return true;
	}
}
