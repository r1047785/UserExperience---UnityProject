using UnityEngine;

public class MachineRepair : MonoBehaviour
{
    [SerializeField] private string requiredTool = "Wrench";
    [SerializeField] private GameObject brokenMarker;
    [SerializeField] private AudioSource breakSound;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Transform explosionPoint;

    private bool isBroken = false;

    public bool IsBroken => isBroken;

    private void Start()
    {
        if (brokenMarker != null)
            brokenMarker.SetActive(false);
    }

    public bool CanRepair(string currentTool)
    {
        return isBroken && currentTool == requiredTool;
    }

    public void Break()
    {
        if (isBroken)
            return;

        isBroken = true;

        if (brokenMarker != null)
            brokenMarker.SetActive(true);

        if (breakSound != null)
            breakSound.Play();

        SpawnExplosion();

        Debug.Log(gameObject.name + " is kapot!");
    }

    public void Repair()
    {
        if (!isBroken)
            return;

        isBroken = false;

        if (brokenMarker != null)
            brokenMarker.SetActive(false);

        Debug.Log(gameObject.name + " repaired!");
    }

    private void SpawnExplosion()
    {
        if (explosionPrefab == null || explosionPoint == null)
            return;

        GameObject explosion = Instantiate(
            explosionPrefab,
            explosionPoint.position,
            explosionPoint.rotation
        );

        Destroy(explosion, 5f);
    }
}