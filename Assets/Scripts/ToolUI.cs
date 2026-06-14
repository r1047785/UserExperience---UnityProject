using UnityEngine;
using UnityEngine.UI;

public class ToolUI : MonoBehaviour
{
    [SerializeField] private Image toolIcon;

    [SerializeField] private Sprite wrenchSprite;
    [SerializeField] private Sprite hammerSprite;
    [SerializeField] private Sprite pliersSprite;
    [SerializeField] private Sprite screwdriverSprite;

    private void Start()
    {
        ClearTool();
    }

    public void SetTool(string toolName)
    {
        if (toolName == "Wrench")
            toolIcon.sprite = wrenchSprite;
        else if (toolName == "Hammer")
            toolIcon.sprite = hammerSprite;
        else if (toolName == "Pliers")
            toolIcon.sprite = pliersSprite;
        else if (toolName == "Screwdriver")
            toolIcon.sprite = screwdriverSprite;

        toolIcon.enabled = true;
    }

    public void ClearTool()
    {
        toolIcon.enabled = false;
    }
}