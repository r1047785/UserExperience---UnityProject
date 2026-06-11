using UnityEngine;

public class ToolPickup : MonoBehaviour
{
    [SerializeField] private string toolName;

    public void Pickup()
    {
        if (PlayerInventory.currentTool != "")
        {
            Debug.Log("Drop eerst je huidige tool!");
            return;
        }

        PlayerInventory.currentTool = toolName;

        PlayerInventory inventory = FindFirstObjectByType<PlayerInventory>();
        inventory.EquipTool(toolName);

        gameObject.SetActive(false);

        Debug.Log("Tool gekozen: " + toolName);
    }
}