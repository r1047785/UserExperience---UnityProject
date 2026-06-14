using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private float startTime = 300f;

    private float timeRemaining;
    private bool timerRunning = false;
    private bool gameOver = false;

    public bool IsGameOver => gameOver;
    public float TimeRemaining => timeRemaining;

    private void Start()
    {
        Time.timeScale = 1f;

        timeRemaining = startTime;

        if (gameOverText != null)
            gameOverText.SetActive(false);

        UpdateTimerUI();
    }

    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                RestartScene();
            }

            return;
        }

        if (!timerRunning)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            UpdateTimerUI();
            GameOver();
            return;
        }

        UpdateTimerUI();
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    private void GameOver()
    {
        gameOver = true;
        timerRunning = false;

        if (gameOverText != null)
            gameOverText.SetActive(true);

        Time.timeScale = 0f;
    }

    private void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateTimerUI()
    {
        if (timerText == null)
            return;

        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);

        timerText.text = $"Time: {minutes:00}:{seconds:00}";
    }
}