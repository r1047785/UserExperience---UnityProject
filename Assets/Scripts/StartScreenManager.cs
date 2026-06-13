using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup startScreen;

    private bool gameStarted = false;

    private void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        float duration = 1.5f;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            startScreen.alpha = Mathf.Lerp(1f, 0f, timer / duration);

            yield return null;
        }

        startScreen.alpha = 0f;
        startScreen.gameObject.SetActive(false);
    }
}