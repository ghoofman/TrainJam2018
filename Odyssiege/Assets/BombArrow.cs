using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Destructible2D;

public class BombArrow : MonoBehaviour {
	public D2dVector2Event OnImpact;
	private bool started = false;
	private bool collided = false;
	private Vector2 contactPoint;

	public float ForceToAdd = 500.0f;
	private Rigidbody2D collidedWith;
	public float ExplosionForce = 500.0f;

	// Use this for initialization
	void Start () {
		var rigid = gameObject.GetComponent<Rigidbody2D> ();
		rigid.simulated = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			if (!started) {
				started = true;
				var rigid = gameObject.GetComponent<Rigidbody2D> ();
				var forceDir = gameObject.transform.rotation * (new Vector3 (1, 0, 0));
				rigid.AddForce (forceDir * ForceToAdd);
				rigid.simulated = true;
				rigid.AddTorque (-gameObject.transform.rotation.eulerAngles.z);
			} else {
				if (OnImpact != null) {
					if (collided) {
						OnImpact.Invoke (contactPoint);
						collidedWith.AddForceAtPosition (new Vector2 (ExplosionForce, 0), contactPoint);
						Destroy (gameObject);
					} else {
						OnImpact.Invoke (transform.position);
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

			contactPoint = contacts[0].point;
			collidedWith = contacts [0].rigidbody;
			gameObject.transform.SetParent(collidedWith.transform);
		}
	}
}
