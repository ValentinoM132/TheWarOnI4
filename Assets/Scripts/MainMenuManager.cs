using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

