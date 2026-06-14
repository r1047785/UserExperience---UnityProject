using System.Collections;
using UnityEngine;

public class AlarmManager : MonoBehaviour
{
    [SerializeField] private AudioSource alarmAudio;

    private int brokenMachineCount = 0;
    private Coroutine startAlarmCoroutine;

    public void MachineBroken()
    {
        brokenMachineCount++;

        if (brokenMachineCount == 1)
        {
            startAlarmCoroutine = StartCoroutine(StartAlarmDelayed());
        }
    }

    public void MachineRepaired()
    {
        brokenMachineCount--;

        if (brokenMachineCount < 0)
            brokenMachineCount = 0;

        if (brokenMachineCount == 0)
        {
            if (startAlarmCoroutine != null)
            {
                StopCoroutine(startAlarmCoroutine);
                startAlarmCoroutine = null;
            }

            if (alarmAudio != null && alarmAudio.isPlaying)
            {
                alarmAudio.Stop();
            }
        }
    }

    private IEnumerator StartAlarmDelayed()
    {
        yield return new WaitForSeconds(1f);

        if (brokenMachineCount > 0 && alarmAudio != null && !alarmAudio.isPlaying)
        {
            alarmAudio.Play();
        }
    }
}