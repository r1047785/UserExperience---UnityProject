using UnityEngine;

public class ToolPickup : MonoBehaviour
{
    [SerializeField] private string toolName;

    private PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = FindFirstObjectByType<PlayerInventory>();
    }

    public string ToolName => toolName;

    public void Pickup()
    {
        if (playerInventory == null)
            return;

        if (PlayerInventory.currentTool != "")
        {
            Debug.Log("Drop eerst je huidige tool!");
            return;
        }

        playerInventory.EquipTool(toolName);

        gameObject.SetActive(false);

        Debug.Log("Tool gekozen: " + toolName);
    }
}