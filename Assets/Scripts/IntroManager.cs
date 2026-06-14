using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private AudioSource introAudio;

    public static bool introFinished = false;

    private void Start()
    {
        introFinished = false;
    }

    public void StartIntro()
    {
        StartCoroutine(IntroRoutine());
    }

    private IEnumerator IntroRoutine()
    {
        if (introAudio != null)
            introAudio.Play();

        yield return new WaitForSeconds(introAudio.clip.length);

        introFinished = true;
    }
}