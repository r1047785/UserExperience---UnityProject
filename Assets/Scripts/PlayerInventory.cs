using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static string currentTool = "";

    public GameObject heldWrench;
    public GameObject heldScrewdriver;
    public GameObject heldHammer;
    public GameObject heldPliers;

    public GameObject wrenchPrefab;
    public GameObject screwdriverPrefab;
    public GameObject hammerPrefab;
    public GameObject pliersPrefab;

    public Transform dropPoint;

    public void EquipTool(string toolName)
    {
        heldWrench.SetActive(false);
        heldScrewdriver.SetActive(false);
        heldHammer.SetActive(false);
        heldPliers.SetActive(false);

        if (toolName == "Wrench")
            heldWrench.SetActive(true);
        else if (toolName == "Screwdriver")
            heldScrewdriver.SetActive(true);
        else if (toolName == "Hammer")
            heldHammer.SetActive(true);
        else if (toolName == "Pliers")
            heldPliers.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && currentTool != "")
        {
            DropTool();
        }
    }

    private void DropTool()
    {
        GameObject prefabToDrop = null;

        if (currentTool == "Wrench")
            prefabToDrop = wrenchPrefab;
        else if (currentTool == "Screwdriver")
            prefabToDrop = screwdriverPrefab;
        else if (currentTool == "Hammer")
            prefabToDrop = hammerPrefab;
        else if (currentTool == "Pliers")
            prefabToDrop = pliersPrefab;

        if (prefabToDrop != null)
        {
            Instantiate(prefabToDrop, dropPoint.position, dropPoint.rotation);
        }

        currentTool = "";

        heldWrench.SetActive(false);
        heldScrewdriver.SetActive(false);
        heldHammer.SetActive(false);
        heldPliers.SetActive(false);

        Debug.Log("Tool gedropt");
    }
}