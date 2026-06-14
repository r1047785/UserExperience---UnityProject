using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactDistance = 8f;
    [SerializeField] private float sphereCastRadius = 0.35f;
    [SerializeField] private TextMeshProUGUI interactionText;

    private Outline currentOutline;
    private Camera playerCamera;

    private void Start()
    {
        playerCamera = Camera.main;
        HideInteraction();
    }

    private void Update()
    {
        if (playerCamera == null)
            return;

        CheckInteraction();
    }

    private void CheckInteraction()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (!Physics.SphereCast(ray, sphereCastRadius, out RaycastHit hit, interactDistance))
        {
            HideInteraction();
            return;
        }

        ToolPickup tool = hit.collider.GetComponentInParent<ToolPickup>();

        if (tool != null)
        {
            HandleToolInteraction(tool);
            return;
        }

        MachineRepair machine = hit.collider.GetComponentInParent<MachineRepair>();

        if (machine != null)
        {
            HandleMachineInteraction(machine);
            return;
        }

        HideInteraction();
    }

    private void HandleToolInteraction(ToolPickup tool)
    {
        ShowInteraction("Press E to pickup", tool.GetComponentInParent<Outline>());

        if (Input.GetKeyDown(KeyCode.E))
        {
            tool.Pickup();
            HideInteraction();
        }
    }

    private void HandleMachineInteraction(MachineRepair machine)
    {
        string message = "Press R to repair\nRequired: " + machine.RequiredTool;

        ShowInteraction(message, machine.GetComponentInParent<Outline>());

        if (!Input.GetKeyDown(KeyCode.R))
            return;

        if (machine.CanRepair(PlayerInventory.currentTool))
        {
            machine.Repair();
        }
        else
        {
            Debug.Log("Wrong tool! Required: " + machine.RequiredTool);
        }
    }

    private void ShowInteraction(string message, Outline outline)
    {
        if (interactionText != null)
        {
            interactionText.text = message;
            interactionText.gameObject.SetActive(true);
        }

        if (outline == currentOutline)
            return;

        ClearOutline();

        currentOutline = outline;

        if (currentOutline != null)
            currentOutline.enabled = true;
    }

    private void HideInteraction()
    {
        if (interactionText != null)
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