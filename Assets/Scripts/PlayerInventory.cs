using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static string currentTool = "";

    public GameObject heldWrench;
    public GameObject heldScrewdriver;
    public GameObject heldHammer;
    public GameObject heldPliers;

    public void EquipTool(string toolName)
    {
        heldWrench.SetActive(false);
        heldScrewdriver.SetActive(false);
        heldHammer.SetActive(false);
        heldPliers.SetActive(false);

        if (toolName == "Wrench")
            heldWrench.SetActive(true);

        if (toolName == "Screwdriver")
            heldScrewdriver.SetActive(true);

        if (toolName == "Hammer")
            heldHammer.SetActive(true);

        if (toolName == "Pliers")
            heldPliers.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            currentTool = "";

            heldWrench.SetActive(false);
            heldScrewdriver.SetActive(false);
            heldHammer.SetActive(false);
            heldPliers.SetActive(false);

            Debug.Log("Tool gedropt");
        }
    }
}