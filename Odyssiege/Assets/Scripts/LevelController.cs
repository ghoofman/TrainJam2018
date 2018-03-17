using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
	private int levelCount = 2;
	private bool loadingTransition = false;
	private bool loadingLevel = false;
	private bool canTransition = true;

	private void Awake() {
		Globals.levelController = this;
		Globals.currentLevel = 1;
	}

    public void LoadNextLevel()
	{
		loadingLevel = true;
		canTransition = false;

        Globals.currentLevel++;
        if (Globals.currentLevel <= levelCount)
        {
			SceneManager.LoadSceneAsync("Level" + Globals.currentLevel, LoadSceneMode.Additive);
        }
        else
        {
			SceneManager.LoadSceneAsync("Victory", LoadSceneMode.Additive);
        }
	}

	bool isLoaded(string name) {
		for (var i = 0; i < SceneManager.sceneCount; i++) {
			if (SceneManager.GetSceneAt (i).name == name) {
				return true;
			}
		}
		return false;
	}

	public void LoadTransition() {
		canTransition = false;
		SceneManager.LoadSceneAsync ("Transition", LoadSceneMode.Additive);
	}

	public void BeginLoadingSequence() {
		SceneManager.UnloadSceneAsync ("Level" + Globals.currentLevel);
		LoadNextLevel ();
	}

	public void FinishTransition() {
		if (canTransition) {
			SceneManager.UnloadSceneAsync ("Transition");
		}
	}

	public void Reset() {
		Globals.currentLevel = 0;
		SceneManager.LoadSceneAsync("HorseSelector");
	}

}
