using UnityEngine;

public class MachineManager : MonoBehaviour
{
    [SerializeField] private MachineRepair[] machines;
    [SerializeField] private float minBreakTime = 10f;
    [SerializeField] private float maxBreakTime = 20f;

    private float timer;

    private void Start()
    {
        SetNextBreakTime();
    }

    private void Update()
    {
        if (HasBrokenMachine())
            return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            BreakRandomMachine();
            SetNextBreakTime();
        }
    }

    private bool HasBrokenMachine()
    {
        foreach (MachineRepair machine in machines)
        {
            if (machine.IsBroken)
                return true;
        }

        return false;
    }

    private void BreakRandomMachine()
    {
        if (machines.Length == 0)
            return;

        int randomIndex = Random.Range(0, machines.Length);

        machines[randomIndex].Break();
    }

    private void SetNextBreakTime()
    {
        timer = Random.Range(minBreakTime, maxBreakTime);
    }
}