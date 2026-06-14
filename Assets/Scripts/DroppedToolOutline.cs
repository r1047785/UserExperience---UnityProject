using UnityEngine;

public class DroppedToolOutline : MonoBehaviour
{
    private Outline outline;

    private void Awake()
    {
        outline = GetComponent<Outline>();

        if (outline != null)
        {
            outline.enabled = true;
            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = Color.white;
            outline.OutlineWidth = 2f;
        }
    }

    private void Update()
    {
        if (outline != null && !outline.enabled)
        {
            outline.enabled = true;
        }
    }
}