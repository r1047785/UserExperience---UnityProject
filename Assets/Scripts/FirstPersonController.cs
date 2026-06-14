using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Bewegingssnelheid")]
    public float loopSnelheid = 5f;
    public float renSnelheid = 9f;
    public float springKracht = 5f;

    [Header("Camera / Muisgevoeligheid")]
    public float muisGevoeligheid = 200f;
    public Transform cameraTransform;

    [Header("Game State")]
    public bool canMove = false;
    public bool canLook = false;

    private CharacterController controller;
    private float vertikaleSnelheid = 0f;
    private float cameraRotatieX = 0f;
    private const float zwaartekracht = -19.62f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (canLook)
        {
            BewerkCamera();
        }

        if (canMove)
        {
            BewerkBeweging();
        }

        OntsnapMuis();
    }

    void BewerkCamera()
    {
        if (cameraTransform == null) return;

        float muisX = Input.GetAxis("Mouse X") * muisGevoeligheid * Time.deltaTime;
        float muisY = Input.GetAxis("Mouse Y") * muisGevoeligheid * Time.deltaTime;

        cameraRotatieX -= muisY;
        cameraRotatieX = Mathf.Clamp(cameraRotatieX, -80f, 80f);
        cameraTransform.localRotation = Quaternion.Euler(cameraRotatieX, 0f, 0f);

        transform.Rotate(Vector3.up * muisX);
    }

    void BewerkBeweging()
    {
        float horizontaal = Input.GetAxis("Horizontal");
        float vertikaal = Input.GetAxis("Vertical");

        Vector3 richting = transform.right * horizontaal + transform.forward * vertikaal;

        float huidigSnelheid = Input.GetKey(KeyCode.LeftShift) ? renSnelheid : loopSnelheid;

        if (controller.isGrounded)
        {
            vertikaleSnelheid = -2f;

            if (Input.GetButtonDown("Jump"))
            {
                vertikaleSnelheid = springKracht;
            }
        }
        else
        {
            vertikaleSnelheid += zwaartekracht * Time.deltaTime;
        }

        Vector3 beweging = richting * huidigSnelheid;
        beweging.y = vertikaleSnelheid;

        controller.Move(beweging * Time.deltaTime);
    }

    void OntsnapMuis()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}