using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SunnySteps-1");
        Time.timeScale = 1f;
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}