using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private int levelCount = 2;

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

}
