using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Destructible2D;

public class BombArrow : MonoBehaviour {
	public D2dVector2Event OnImpact;
	private bool started = false;
	private bool collided = false;
	private Vector2 contactPoint;

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
				rigid.AddForce (new Vector2 (650, 400));
				rigid.AddTorque (-50.0f);
				rigid.simulated = true;
			} else {
				if (OnImpact != null) {
					if (collided) {
						OnImpact.Invoke (contactPoint);
					} else {
						OnImpact.Invoke (transform.position);
					}
				}
				Destroy (gameObject);
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
		}
	}
}
