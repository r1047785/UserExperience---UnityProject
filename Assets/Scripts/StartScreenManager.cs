using UnityEngine;
using System.Collections;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup startScreen;
    [SerializeField] private FirstPersonController playerController;
    [SerializeField] private AudioSource introAudio;
    [SerializeField] private MachineManager machineManager;
    [SerializeField] private TimerManager timerManager;

    private bool gameStarted = false;

    private void Start()
    {
        if (playerController != null)
        {
            playerController.canMove = false;
            playerController.canLook = false;
        }
    }

    private void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
            StartCoroutine(StartIntroSequence());
        }
    }

    private IEnumerator StartIntroSequence()
    {
        yield return StartCoroutine(FadeOut());

        if (playerController != null)
        {
            playerController.canLook = true;
            playerController.canMove = false;
        }

        if (introAudio != null)
        {
            introAudio.Play();
            yield return new WaitForSeconds(introAudio.clip.length);
        }

        if (playerController != null)
        {
            playerController.canMove = true;
        }

        if (machineManager != null)
        {
            machineManager.StartMachineSystem();
        }

        if (timerManager != null)
        {
            timerManager.StartTimer();
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