using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactDistance = 8f;
    [SerializeField] private TextMeshProUGUI interactionText;

    private Outline currentOutline;

    private void Start()
    {
        HideInteraction();
    }

    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.SphereCast(ray, 0.35f, out RaycastHit hit, interactDistance))
        {
            ToolPickup tool = hit.collider.GetComponentInParent<ToolPickup>();

            if (tool != null)
            {
                ShowInteraction("Press E to pickup", tool.GetComponentInParent<Outline>());

                if (Input.GetKeyDown(KeyCode.E))
                {
                    tool.Pickup();
                    HideInteraction();
                }

                return;
            }

            MachineRepair machine = hit.collider.GetComponentInParent<MachineRepair>();

            if (machine != null)
            {
                ShowInteraction("Press R to repair", machine.GetComponentInParent<Outline>());

                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (machine.CanRepair(PlayerInventory.currentTool))
                    {
                        machine.Repair();
                    }
                    else
                    {
                        Debug.Log("Wrong tool!");
                    }
                }

                return;
            }
        }

        HideInteraction();
    }

    private void ShowInteraction(string message, Outline outline)
    {
        interactionText.text = message;
        interactionText.gameObject.SetActive(true);

        if (outline == currentOutline)
            return;

        ClearOutline();

        currentOutline = outline;

        if (currentOutline != null)
            currentOutline.enabled = true;
    }

    private void HideInteraction()
    {
        interactionText.gameObject.SetActive(false);
        ClearOutline();
    }

    private void ClearOutline()
    {
        if (currentOutline == null)
            return;

        currentOutline.enabled = false;
        currentOutline = null;
    }
}