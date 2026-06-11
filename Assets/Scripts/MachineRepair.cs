using UnityEngine;

public class MachineRepair : MonoBehaviour
{
    [SerializeField] private string requiredTool = "Wrench";
    [SerializeField] private GameObject brokenMarker;

    private bool isBroken = false;

    public bool IsBroken => isBroken;

    private void Start()
    {
        if (brokenMarker != null)
            brokenMarker.SetActive(false);
    }

    public bool CanRepair(string currentTool)
    {
        return isBroken && currentTool == requiredTool;
    }

    public void Break()
    {
        if (isBroken)
            return;

        isBroken = true;

        if (brokenMarker != null)
            brokenMarker.SetActive(true);

        Debug.Log(gameObject.name + " is kapot!");
    }

    public void Repair()
    {
        if (!isBroken)
            return;

        isBroken = false;

        if (brokenMarker != null)
            brokenMarker.SetActive(false);

        Debug.Log(gameObject.name + " repaired!");
    }
}