using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class TransitionFade : MonoBehaviour {

	bool ending = false;
	public bool CanRunAnimation = false;

	// Use this for initialization
	void Start () {
		ending = false;
		CanRunAnimation = false;

		var spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		spriteRenderer.DOColor (new Color (0, 0, 0, 1.0f), 0.75f).OnComplete(() => {
			Globals.levelController.BeginLoadingSequence();
			CanRunAnimation = true;
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BeginEnd() {
		if (ending)
			return;
		
		ending = true;
		var spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();

		if (Globals.horse) {
			Globals.horse.parent.parent.GetComponent<Horse> ().enabled = true;
			Globals.horse.parent.GetComponent<Rigidbody2D> ().velocity = new Vector2 (10, 0);
		}

		spriteRenderer.DOColor (new Color (0, 0, 0, 0.0f), 0.75f).OnComplete(() => {
			Globals.levelController.FinishTransition();
		});
		gameObject.GetComponentInChildren<TransitionStart> ().FadeOut();
	}
}
