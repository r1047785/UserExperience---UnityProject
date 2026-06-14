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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && currentTool != "")
        {
            DropTool();
        }
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

    private void DropTool()
    {
        GameObject prefabToDrop = GetCurrentToolPrefab();

        if (prefabToDrop != null)
        {
            GameObject droppedTool = Instantiate(prefabToDrop, dropPoint.position, dropPoint.rotation);
            SetupDroppedTool(droppedTool);
        }

        currentTool = "";

        heldWrench.SetActive(false);
        heldScrewdriver.SetActive(false);
        heldHammer.SetActive(false);
        heldPliers.SetActive(false);

        UpdateToolUI();
    }

    private GameObject GetCurrentToolPrefab()
    {
        if (currentTool == "Wrench")
            return wrenchPrefab;

        if (currentTool == "Screwdriver")
            return screwdriverPrefab;

        if (currentTool == "Hammer")
            return hammerPrefab;

        if (currentTool == "Pliers")
            return pliersPrefab;

        return null;
    }

    private void SetupDroppedTool(GameObject droppedTool)
    {
        Outline outline = droppedTool.GetComponent<Outline>();

        if (outline != null)
        {
            outline.enabled = true;
            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = Color.white;
            outline.OutlineWidth = 2f;
        }

        if (droppedTool.GetComponent<DroppedToolOutline>() == null)
        {
            droppedTool.AddComponent<DroppedToolOutline>();
        }
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