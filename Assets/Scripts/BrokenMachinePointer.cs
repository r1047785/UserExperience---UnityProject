using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BrokenMachinePointer : MonoBehaviour
{
    [SerializeField] private MachineRepair[] machines;
    [SerializeField] private Transform playerCamera;

    private Image pointerImage;
    private RectTransform pointerRectTransform;

    private void Awake()
    {
        pointerImage = GetComponent<Image>();
        pointerRectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        pointerImage.enabled = false;
    }

    private void Update()
    {
        MachineRepair brokenMachine = GetBrokenMachine();

        if (brokenMachine == null)
        {
            pointerImage.enabled = false;
            return;
        }

        pointerImage.enabled = true;

        Vector3 directionToMachine = brokenMachine.transform.position - playerCamera.position;
        directionToMachine.y = 0f;

        Vector3 cameraForward = playerCamera.forward;
        cameraForward.y = 0f;

        if (directionToMachine.sqrMagnitude < 0.01f)
            return;

        float angle = Vector3.SignedAngle(cameraForward, directionToMachine, Vector3.up);

        pointerRectTransform.rotation = Quaternion.Euler(0f, 0f, -angle);
    }

    private MachineRepair GetBrokenMachine()
    {
        foreach (MachineRepair machine in machines)
        {
            if (machine != null && machine.IsBroken)
                return machine;
        }

        return null;
    }
}