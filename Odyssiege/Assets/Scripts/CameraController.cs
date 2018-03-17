using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Transform follow;
	private Horse followController;
	private float yOffset;
	private float lookDownAmount = 0f;

	public float leftMargin = 8f;
	public float rightMargin = 2f;

	private float topMargin = 0.5f;
	private float bottomMargin = 0.5f;

	public float topMarginGrounded = 1f;
	public float bottomMarginGrounded = 1f;
	public float topMarginAirborne = 5f;
	public float bottomMarginAirborne = 2f;
	public float verticalMaxMove = 0.1f;

	public float topMarginMax = 8f;
	public float bottomMarginMax = 8f;
	public bool verticalLock = false;

	public Transform mountains;
	public Transform hills;
	public Transform hills2;
	public Transform hills3;
	private float mountainReset = 20f;
	private float hillReset = 20f;
	private float hillReset2 = 20f;
	private float hillReset3 = 20f;

	private float cameraHeight = 0f;
	private float cameraWidth = 0f;

	// Use this for initialization
	void Start () {
		followController = follow.parent.parent.GetComponent<Horse>();
		yOffset = transform.position.y - follow.position.y;
        // init offset values
        if (mountains != null)
            mountainReset = mountains.localScale.x * Mathf.Abs(mountains.GetChild(0).localPosition.x - mountains.GetChild(1).localPosition.x);
        if (hills != null)
            hillReset = hills.localScale.x * Mathf.Abs(hills.GetChild(0).localPosition.x - hills.GetChild(1).localPosition.x);
        if (hills2 != null)
            hillReset2 = hills2.localScale.x * Mathf.Abs(hills2.GetChild(0).localPosition.x - hills2.GetChild(1).localPosition.x);
        if (hills3 != null)
            hillReset3 = hills3.localScale.x * Mathf.Abs(hills3.GetChild(0).localPosition.x - hills3.GetChild(1).localPosition.x);

        var cam = GetComponent<Camera> ();
		cameraHeight = cam.orthographicSize;
		cameraWidth = cameraHeight * cam.aspect;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 pos = transform.position;
		if (follow != null) {
			// use x margins
			if (follow.position.x > pos.x + rightMargin) {
				pos.x = follow.position.x - rightMargin;
			} else if (follow.position.x < pos.x - leftMargin) {
				pos.x = follow.position.x + leftMargin;
			}

			// maximum vertical bounds
			if (!verticalLock) {
				if (follow.position.y + yOffset + lookDownAmount > pos.y + topMarginMax) {
					pos.y = follow.position.y + yOffset + lookDownAmount - topMarginMax + verticalMaxMove;
				} else if (follow.position.y + yOffset + lookDownAmount < pos.y - bottomMarginMax) {
					pos.y = follow.position.y + yOffset + lookDownAmount + bottomMarginMax - verticalMaxMove;
				} else {
					pos = GetSmoothCameraPosition(pos);
				}
			}
		}
		pos = ApplyCameraBounds (pos);
        // adjust background positions based on change in camera position
        MoveMountains(pos - transform.position);
        transform.position = pos;
	}

    private void MoveMountains(Vector3 deltaPos)
    {
        if (mountains != null)
        {
            mountains.position += deltaPos / 1.5f;
            if (mountains.position.x > transform.position.x)
            {
                mountains.position -= new Vector3(mountainReset, 0f, 0f);
            }
            if (mountains.position.x < transform.position.x - mountainReset)
            {
                mountains.position += new Vector3(mountainReset, 0f, 0f);
            }
        }
        if (hills != null)
        {
            hills.position += deltaPos / 2f;
            if (hills.position.x > transform.position.x)
            {
                hills.position -= new Vector3(hillReset, 0f, 0f);
            }
            if (hills.position.x < transform.position.x - hillReset)
            {
                hills.position += new Vector3(hillReset, 0f, 0f);
            }
        }
        if (hills2)
        {
            hills2.position += deltaPos / 3f;
            if (hills2.position.x > transform.position.x)
            {
                hills2.position -= new Vector3(hillReset2, 0f, 0f);
            }
            if (hills2.position.x < transform.position.x - hillReset2)
            {
                hills2.position += new Vector3(hillReset2, 0f, 0f);
            }
        }
        if (hills3)
        {
            hills3.position += deltaPos / 4f;
            if (hills3.position.x > transform.position.x)
            {
                hills3.position -= new Vector3(hillReset3, 0f, 0f);
            }
            if (hills3.position.x < transform.position.x - hillReset3)
            {
                hills3.position += new Vector3(hillReset3, 0f, 0f);
            }
        }
    }

    private Vector3 GetSmoothCameraPosition(Vector3 pos) {
		//if (followController.grounded) {
			// use grounded window y margins
			if (follow.position.y + yOffset + lookDownAmount > pos.y + topMarginGrounded) {
				pos.y = Mathf.Min(follow.position.y + yOffset + lookDownAmount - topMarginGrounded, pos.y + verticalMaxMove);
			} else if (follow.position.y + yOffset + lookDownAmount < pos.y - bottomMarginGrounded) {
				pos.y = Mathf.Max(follow.position.y + yOffset + lookDownAmount + bottomMarginGrounded, pos.y - verticalMaxMove);
			}
		//} else {
		//	// use airborne window y margins
		//	if (follow.position.y + yOffset + lookDownAmount > pos.y + topMarginAirborne) {
		//		pos.y = Mathf.Min(follow.position.y + yOffset + lookDownAmount - topMarginAirborne, pos.y + verticalMaxMove);
		//	} else if (follow.position.y + yOffset + lookDownAmount < pos.y - bottomMarginAirborne) {
		//		pos.y = Mathf.Max(follow.position.y + yOffset + lookDownAmount + bottomMarginAirborne, pos.y - verticalMaxMove);
		//	}
		//}
		return pos;
	}

	private Vector3 ApplyCameraBounds(Vector3 pos) {
		// check for absolute camera bounds
		if (Globals.bounds != null) {
			pos.y = Mathf.Min (Globals.bounds.top - cameraHeight, pos.y);
			pos.y = Mathf.Max (Globals.bounds.bottom + cameraHeight, pos.y);
			pos.x = Mathf.Min (Globals.bounds.right - cameraWidth, pos.x);
			pos.x = Mathf.Max (Globals.bounds.left + cameraWidth, pos.x);

			//if (Globals.bounds.KillBottomBound)
			//	if (Globals.horse != null)
			//		if (Globals.horse.transform.position.y < Globals.bounds.bottom)
			//			Globals.horse.GetComponent<SenseiStatus>().ApplyDamage(100f);
		}
		return pos;
	}

	public void toggleOnGround(bool onGround) {
		// transition top and bottom bounds between Grounded and Airborne margins
		if (onGround) {
			// transition margin toward Grounded
			topMargin = Mathf.Max(topMargin - verticalMaxMove, topMarginGrounded);
			bottomMargin = Mathf.Max(bottomMargin - verticalMaxMove, bottomMarginGrounded);
		} else {
			// transition margin toward Airborne
			// since airborne margins are more relaxed, instantly set the margins
			topMargin = topMarginAirborne;
			bottomMargin = bottomMarginAirborne;
		}
	}

	public void toggleLookDown (bool lookDown) {
		if (lookDown) {
			lookDownAmount = -9f;
		} else {
			lookDownAmount = 0f;
		}
	}
}
