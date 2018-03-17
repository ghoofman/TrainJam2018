using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private int levelCount = 2;

	private void Awake() {
		Globals.levelController = this;
	}

    public void LoadNextLevel()
    {
        Globals.currentLevel++;
        if (Globals.currentLevel <= levelCount)
        {
            SceneManager.LoadScene("Level" + Globals.currentLevel);
        }
        else
        {
            SceneManager.LoadScene("Victory");
        }
    }

	public void Reset() {
		Globals.currentLevel = 0;
		SceneManager.LoadScene("HorseSelector");
	}

}
