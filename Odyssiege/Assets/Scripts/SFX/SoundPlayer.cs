using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SoundPlayer : MonoBehaviour {

	private AudioSource audioSource;

	// Use this for initialization
	void Awake () {
		audioSource = GetComponent<AudioSource> ();
	}

	public AudioSource PlaySound(string action, bool loop = false) {
        audioSource.clip = Globals.soundManager.GetSoundClip (action);
        audioSource.RandomizePitch();
        audioSource.Play();
        return audioSource;
	}
	public AudioSource LoopSound(string action) {
		audioSource.loop = true;
        audioSource.clip = Globals.soundManager.GetSoundClip (action);
        audioSource.RandomizePitch();
        audioSource.Play ();
        return audioSource;
    }

    public AudioSource PlaySoundForAnimation(string action)
    {
        return PlaySoundComponentInstantiate(action);
    }

    public AudioSource PlaySoundComponentInstantiate(string action, float duration = 5f, bool loop = false) {
		var aSource = gameObject.AddComponent<AudioSource>();
        if (loop)
            aSource.loop = true;
        aSource.RandomizePitch();
        aSource.clip = Globals.soundManager.GetSoundClip(action);
        aSource.Play();
        Destroy(aSource, duration);
        return aSource;
    }

    public AudioSource PlaySoundInstantiate(string action, float duration = 5f, bool loop = false) {
		var go = new GameObject();
		go.transform.position = transform.position;
		var aSource = go.AddComponent<AudioSource>();
        if (loop)
            aSource.loop = true;
        aSource.RandomizePitch();
        aSource.clip = Globals.soundManager.GetSoundClip(action);
        aSource.Play();
        Destroy(go, duration);
        return aSource;
    }
}
