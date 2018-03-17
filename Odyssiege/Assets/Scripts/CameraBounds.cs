using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraBounds : MonoBehaviour {

	[Tooltip("This will kill the horse if he is lower than the bottom bound")]
	public bool KillBottomBound = false;

	public float left;
	public float right;
	public float top;
	public float bottom;

	void Awake() {
		Globals.bounds = this;
		var rect = GetComponent<RectTransform> ().rect;
		left = rect.min.x + transform.position.x;
		bottom = rect.min.y + transform.position.y;
		right = rect.max.x + transform.position.x;
		top = rect.max.y + transform.position.y;
	}
}
