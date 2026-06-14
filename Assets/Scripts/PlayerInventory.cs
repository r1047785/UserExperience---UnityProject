using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static string currentTool = "";

    [SerializeField] private GameObject heldWrench;
    [SerializeField] private GameObject heldScrewdriver;
    [SerializeField] private GameObject heldHammer;
    [SerializeField] private GameObject heldPliers;

    [SerializeField] private GameObject wrenchPrefab;
    [SerializeField] private GameObject screwdriverPrefab;
    [SerializeField] private GameObject hammerPrefab;
    [SerializeField] private GameObject pliersPrefab;

    [SerializeField] private Transform dropPoint;
    [SerializeField] private TextMeshProUGUI currentToolText;
    [SerializeField] private ToolUI toolUI;

    private void Start()
    {
        UpdateToolUI();
    }

    public void EquipTool(string toolName)
    {
        currentTool = toolName;

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

        UpdateToolUI();
    }

    private void Update()
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
            Instantiate(prefabToDrop, dropPoint.position, dropPoint.rotation);

        currentTool = "";

        heldWrench.SetActive(false);
        heldScrewdriver.SetActive(false);
        heldHammer.SetActive(false);
        heldPliers.SetActive(false);

        UpdateToolUI();
    }

    private void UpdateToolUI()
    {
        if (currentToolText != null)
        {
            currentToolText.text = currentTool == ""
                ? "Tool: None"
                : "Tool: " + currentTool;
        }

        if (toolUI == null)
            return;

        if (currentTool == "")
            toolUI.ClearTool();
        else
            toolUI.SetTool(currentTool);
    }
}