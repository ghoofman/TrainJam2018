using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Destructible2D;

public class SelfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {

		var destructible = gameObject.GetComponentInParent<D2dDestructible>();

		if (destructible != null)
		{
			// Register split event
			//destructible.OnEndSplit.AddListener(OnEndSplit);

			// Split via fracture
			D2dQuadFracturer.Fracture(destructible, 1, 0.5f);

			// Unregister split event
//			destructible.OnEndSplit.RemoveListener(OnEndSplit);
//
//			// Spawn explosion prefab?
//			if (ExplosionPrefab != null)
//			{
//				var worldRotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)); // Random rotation around Z axis
//
//				Instantiate(ExplosionPrefab, explosionPosition, worldRotation);
//			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
