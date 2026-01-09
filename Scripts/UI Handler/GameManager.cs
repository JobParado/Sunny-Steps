using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject victoryUI;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource gameOverMusic;
    [SerializeField] private AudioSource victoryMusic;

    private void Awake()
    {
        if (gameOverUI != null) gameOverUI.SetActive(false);
        if (victoryUI != null) victoryUI.SetActive(false);
    }

    public void TriggerGameOver(float delay)
    {
        if (backgroundMusic != null) backgroundMusic.Stop();
        StartCoroutine(GameOverRoutine(delay));
    }

    private IEnumerator GameOverRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (gameOverUI != null) gameOverUI.SetActive(true);

        if (gameOverMusic != null) gameOverMusic.Play();

        Time.timeScale = 0f;
    }

    public void TriggerVictory()
    {
        if (backgroundMusic != null) backgroundMusic.Stop();

        if (victoryUI != null) victoryUI.SetActive(true);

        if (victoryMusic != null && !victoryMusic.isPlaying)
            victoryMusic.Play();

        Time.timeScale = 0f;
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}