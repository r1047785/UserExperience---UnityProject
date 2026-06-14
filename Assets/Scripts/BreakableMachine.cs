using UnityEngine;

public abstract class BreakableMachine : MonoBehaviour
{
    protected bool isBroken = false;

    public bool IsBroken => isBroken;

    public virtual bool CanRepair(string currentTool)
    {
        return isBroken;
    }

    public virtual void Break()
    {
        isBroken = true;
    }

    public virtual void Repair()
    {
        isBroken = false;
    }
}