using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject gameOverText;

    private float timeRemaining = 300f;
    private bool gameOver = false;

    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            return;
        }

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            GameOver();
        }

        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = $"Time: {minutes:00}:{seconds:00}";
    }

    private void GameOver()
    {
        gameOver = true;

        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}