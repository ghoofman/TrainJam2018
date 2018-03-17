using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TransitionStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Globals.currentLevel + 1 < 3) {
			var text = gameObject.GetComponent<Text> ();
			text.text = "Level " + (Globals.currentLevel + 1);
			text.DOColor (new Color (255.0f, 255.0f, 255.0f, 1.0f), 0.75f);
		}
	}
	
	// Update is called once per frame
	public void FadeOut () {
		var text = gameObject.GetComponent<Text> ();
		text.DOColor (new Color (0.0f, 0.0f, 0.0f, 0.0f), 0.75f);
	}
}
