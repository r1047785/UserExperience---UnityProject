using UnityEngine;

public class MachineManager : MonoBehaviour
{
    [Header("Machines")]
    [SerializeField] private MachineRepair[] machines;

    [Header("Break Timing")]
    [SerializeField] private float minBreakTime = 10f;
    [SerializeField] private float maxBreakTime = 20f;

    private float breakTimer;
    private bool machineSystemStarted = false;

    public bool MachineSystemStarted => machineSystemStarted;

    private void Start()
    {
        SetNextBreakTime();
    }

    private void Update()
    {
        if (!machineSystemStarted)
            return;

        if (HasBrokenMachine())
            return;

        breakTimer -= Time.deltaTime;

        if (breakTimer <= 0f)
        {
            BreakRandomMachine();
            SetNextBreakTime();
        }
    }

    public void StartMachineSystem()
    {
        machineSystemStarted = true;
        SetNextBreakTime();
    }

    public void StopMachineSystem()
    {
        machineSystemStarted = false;
    }

    private bool HasBrokenMachine()
    {
        foreach (MachineRepair machine in machines)
        {
            if (machine != null && machine.IsBroken)
                return true;
        }

        return false;
    }

    private void BreakRandomMachine()
    {
        MachineRepair machine = GetRandomWorkingMachine();

        if (machine == null)
            return;

        machine.Break();
    }

    private MachineRepair GetRandomWorkingMachine()
    {
        int workingMachineCount = 0;

        foreach (MachineRepair machine in machines)
        {
            if (machine != null && !machine.IsBroken)
                workingMachineCount++;
        }

        if (workingMachineCount == 0)
            return null;

        int randomIndex = Random.Range(0, workingMachineCount);
        int currentIndex = 0;

        foreach (MachineRepair machine in machines)
        {
            if (machine == null || machine.IsBroken)
                continue;

            if (currentIndex == randomIndex)
                return machine;

            currentIndex++;
        }

        return null;
    }

    private void SetNextBreakTime()
    {
        breakTimer = Random.Range(minBreakTime, maxBreakTime);
    }
}