using UnityEngine;

public class MachineRepair : MonoBehaviour
{
    [SerializeField] private string requiredTool = "Wrench";

    private bool isBroken = false;

    public bool IsBroken => isBroken;

    public bool CanRepair(string currentTool)
    {
        return isBroken && currentTool == requiredTool;
    }

    public void Break()
    {
        if (isBroken)
            return;

        isBroken = true;

        Debug.Log(gameObject.name + " is kapot!");
    }

    public void Repair()
    {
        if (!isBroken)
            return;

        isBroken = false;

        Debug.Log(gameObject.name + " repaired!");
    }
}