using UnityEngine;

public class MachineRepair : MonoBehaviour
{
    [SerializeField] private string requiredTool = "Wrench";

    private bool isBroken = true;

    public bool CanRepair(string currentTool)
    {
        return isBroken && currentTool == requiredTool;
    }

    public void Repair()
    {
        if (!isBroken)
            return;

        isBroken = false;

        Debug.Log(gameObject.name + " repaired!");
    }
}