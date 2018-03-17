using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
//using System.IO;
//using System.Text.RegularExpressions;

public class SoundManager : MonoBehaviour {

	public AudioClip music;
	private AudioClip currentlyPlaying = null;
	private AudioSource audioSource;
	private Transform cameraTransform;
	private float crossfadeTimer = 0f;
	private float crossfadeAmount = 0f;
	private bool crossfadeActive = false;
	private AudioSource newAudioSource;

    public AudioSource aSource;

    private static SoundManager instance = null;
	public static SoundManager Instance {
		get { return instance; }
	}
	public Dictionary<string,List<AudioClip>> library = null;

	void Awake() {
		if (instance != null && instance != this) {
			Globals.soundManager = instance;
			instance.PlayMusic(SceneManager.GetActiveScene().name);
			instance.FindCamera();
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
			audioSource = GetComponent<AudioSource>();
			Globals.soundManager = instance;
			instance.PlayMusic(SceneManager.GetActiveScene().name);
			instance.FindCamera();
		}
		DontDestroyOnLoad (this.gameObject);
		instance.library = SoundLibrary.GetLibrary ();
		// get all SFX by filename
//		DirectoryInfo dir = new DirectoryInfo("Assets/Resources/sfx/");
//		DirectoryInfo[] dinfo = dir.GetDirectories();
//		foreach (DirectoryInfo d in dinfo) {
//			FileInfo[] finfo = d.GetFiles ("*.wav");
//			string directoryName = d.Name;
//			foreach (var f in finfo) {
//				if (!Regex.IsMatch(f.Name, @"\.meta")) {
//					// if ends in 1 then create new dictionary entry
//					string soundName = Regex.Replace(f.Name, @"\d\.wav", "");
//					string resourceName = Regex.Replace(f.Name, @"\.wav", "");
//					AudioClip clip = (AudioClip)Resources.Load("sfx/"+directoryName+"/"+resourceName, typeof(AudioClip));
//					if (library.ContainsKey(directoryName+"/"+soundName))
//						library[directoryName+"/"+soundName].Add(clip);
//					else
//						library.Add(directoryName+"/"+soundName, new List<AudioClip>{clip});
//				}
//			}
//		}
	}

	void Update() {
		if (cameraTransform != null)
			transform.position = cameraTransform.position;
		if (crossfadeActive) {
			if (Time.time < crossfadeTimer) {
				float val = crossfadeTimer - Time.time;
				float v1 = (1f - val / crossfadeAmount) * 0.5f;
				newAudioSource.volume = v1;
				float v2 = (val / crossfadeAmount) * 0.5f;
				audioSource.volume = v2;
			} else {
				crossfadeActive = false;
				Component.DestroyImmediate(audioSource);
				audioSource = newAudioSource;
			}
		}
	}

	public AudioClip GetSoundClip(string action) {
		if (!library.ContainsKey (action)) {
			Debug.LogError("Sound clip '" + action + "' was not found!");
			throw new UnityException ("Sound clip '" + action + "' was not found!");
		}
		var soundList = library [action];
		if (soundList == null)
			return null;
		int size = soundList.Count;
		int randInt = Random.Range (0, size);
		return soundList[randInt];
	}

	public void PlayMusic(string level, float crossfade = 1f) {
        AudioClip clip = music;

		//switch (level) {
		//case "Battle":
		//	clip = battleMusic;
		//	break;
		//case "Player Selection":
		//	clip = playerSelectionMusic;
		//	break;
  //      default:
  //          clip = battleMusic;
  //          break;

		//}

		if (currentlyPlaying == null) {
			audioSource.clip = clip;
            audioSource.loop = true;
            currentlyPlaying = clip;
			audioSource.Play ();
		} else if (crossfadeActive) {
			Component.Destroy(audioSource);
			audioSource = newAudioSource;
			newAudioSource = gameObject.AddComponent<AudioSource>();
			newAudioSource.clip = clip;
            newAudioSource.loop = true;
			currentlyPlaying = clip;
			newAudioSource.Play ();
			crossfadeActive = true;
			crossfadeAmount = crossfade;
			crossfadeTimer = Time.time + crossfade;
		} else if (currentlyPlaying.name != clip.name && clip != null) {
			// crossfade
			newAudioSource = gameObject.AddComponent<AudioSource>();
			newAudioSource.clip = clip;
            newAudioSource.loop = true;
            currentlyPlaying = clip;
			newAudioSource.volume = 0f;
			newAudioSource.Play ();
			crossfadeActive = true;
			crossfadeAmount = crossfade;
			crossfadeTimer = Time.time + crossfade;
		}
	}

	private void FindCamera() {
		var go = GameObject.Find ("Main Camera");
		if (go == null)
			go = GameObject.Find ("Camera");
		SoundManager.Instance.cameraTransform = go.transform;
	}
}
