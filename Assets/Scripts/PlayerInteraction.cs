using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private GameObject pickupText;

    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            ToolPickup tool = hit.collider.GetComponent<ToolPickup>();

            if (tool != null)
            {
                pickupText.SetActive(true);
                return;
            }
        }

        pickupText.SetActive(false);
    }
}