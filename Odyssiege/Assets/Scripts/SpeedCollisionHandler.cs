using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Destructible2D;

public class SpeedCollisionHandler : MonoBehaviour {

	[Tooltip("Amount of speed required to explode")]
	public float SpeedRequiredToExplode = 5.0f;

	[Tooltip("The minimum amount of seconds between each impact")]
	public float ImpactDelay;

	public D2dVector2Event OnImpact;

	[Tooltip("The layers that must hit this collider for damage to get inflicted")]
	public LayerMask ImpactMask = -1;

	[Tooltip("Destroy the game object on collision")]
	public bool DestroyOnCollide = false;

	private float cooldownTime = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldownTime > 0.0f)
		{
			cooldownTime -= Time.deltaTime;
			return;
		}
	}

	protected virtual void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.relativeVelocity.magnitude < SpeedRequiredToExplode || cooldownTime > 0.0f) {
			return;
		}
		Debug.Log("Rel Vel: " + collision.relativeVelocity.magnitude + " > " + SpeedRequiredToExplode);

		Debug.Log(name + " hit " + collision.collider.name + " for " + collision.relativeVelocity.magnitude);


		cooldownTime = ImpactDelay;

		var collisionMask = 1 << collision.collider.gameObject.layer;

		if ((collisionMask & ImpactMask) != 0)
		{
			var contacts = collision.contacts;

			for (var i = contacts.Length - 1; i >= 0; i--)
			{
				var contact = contacts[i];
				var impact  = collision.relativeVelocity.magnitude;

				if (OnImpact != null) {
					Debug.Log("Impact " + OnImpact.GetPersistentEventCount());
					OnImpact.Invoke (contact.point);
				}

				if (DestroyOnCollide) {
					Destroy (gameObject);
					return;
				}

			}
		}
	}
}
