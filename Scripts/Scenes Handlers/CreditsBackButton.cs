using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsBackButton : MonoBehaviour
{
    public void BackButton()
    {

        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
