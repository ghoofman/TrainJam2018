using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Destructible2D;

public class CannonSpawner : MonoBehaviour {
	
	[Tooltip("The source GameObject you want to spawn")]
	public GameObject Prefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			var mainCamera = Camera.main;
			var startPos         = D2dHelper.ScreenToWorldPosition(Input.mousePosition, 0, mainCamera);
			Spawn (startPos);
		}
	}

	public void Spawn(Vector3 pos)
	{
		if (Prefab != null && isActiveAndEnabled == true)
		{
			var go = Instantiate(Prefab, pos, Quaternion.identity);
			var rigid = go.GetComponent<Rigidbody2D> ();
			rigid.AddForce (new Vector2 (1000, 0));
		}
	}
}
