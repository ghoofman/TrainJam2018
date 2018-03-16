using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Destructible2D;

public class LaserDestruct : MonoBehaviour {

	public float Thickness = 1.0f;
	public float Hardness = 1.0f;
	public Texture2D StampTex;
	private float laserShowTime = 0.0f;
	private int destruct = 0;
	public int destructPerFrame = 4;
	public float laserDistLength = 10.0f;
	public float laserTime = 0.25f;

	// Use this for initialization
	void Start () {
		var lineRenderer = gameObject.GetComponent<LineRenderer> ();
		lineRenderer.material.color = Color.yellow;
		lineRenderer.startWidth = 0.1f;
		lineRenderer.endWidth = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {

		laserShowTime -= Time.deltaTime;


		var pos = transform.position;
		var dir = new Vector3 (laserDistLength, 0, 0);
		dir = transform.rotation * dir;
		var endPoint = pos + dir;

		if (Input.GetKeyUp (KeyCode.L)) {
			laserShowTime = laserTime;
		}

		var lineRenderer = gameObject.GetComponent<LineRenderer> ();
		if (laserShowTime > 0.0f) {
			destruct++;
			if (destruct > destructPerFrame) {
				destruct = 0;
				var mainCamera = Camera.main;
				Debug.Log ("LASER! PEW PEW");

				Debug.Log ("XY: " + pos.x + ", " + pos.y);
				Debug.Log ("XY: " + endPoint.x + ", " + endPoint.y);

				// var startPos         = D2dHelper.ScreenToWorldPosition(pos, 0, mainCamera);
				// var endPos           = D2dHelper.ScreenToWorldPosition(endPoint, 0, mainCamera);

				D2dDestructible.SliceAll (pos, endPoint, Thickness, StampTex, Hardness);
			}

			lineRenderer.enabled = true;
			lineRenderer.SetPositions (
				new Vector3[] {
					pos,
					endPoint
				}
			);

		} else {
			lineRenderer.enabled = false;
		}
	}
}
