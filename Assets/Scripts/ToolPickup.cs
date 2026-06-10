using UnityEngine;

public class ToolPickup : MonoBehaviour
{
    public string toolName;

    private bool playerNearby = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (PlayerInventory.currentTool != "")
            {
                Debug.Log("Drop eerst je huidige tool!");
                return;
            }

            PlayerInventory.currentTool = toolName;

            PlayerInventory inventory =
                FindFirstObjectByType<PlayerInventory>();

            inventory.EquipTool(toolName);

            gameObject.SetActive(false);

            Debug.Log("Tool gekozen: " + toolName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}