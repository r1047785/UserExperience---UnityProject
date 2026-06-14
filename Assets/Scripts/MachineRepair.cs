using UnityEngine;

public class MachineRepair : BreakableMachine
{
    [SerializeField] private string requiredTool = "Wrench";
    [SerializeField] private GameObject brokenMarker;
    [SerializeField] private AudioSource breakSound;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Transform explosionPoint;
    [SerializeField] private ParticleSystem smokeLoop;
    [SerializeField] private FactoryLights factoryLights;
    [SerializeField] private AlarmManager alarmManager;

    public string RequiredTool => requiredTool;

    private void Start()
    {
        if (brokenMarker != null)
            brokenMarker.SetActive(false);

        if (smokeLoop != null)
            smokeLoop.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    public override bool CanRepair(string currentTool)
    {
        return isBroken && currentTool == requiredTool;
    }

    public override void Break()
    {
        if (isBroken)
            return;

        base.Break();

        if (brokenMarker != null)
            brokenMarker.SetActive(true);

        if (breakSound != null)
            breakSound.Play();

        SpawnExplosion();

        if (smokeLoop != null)
            smokeLoop.Play(true);

        if (factoryLights != null)
            factoryLights.MachineBroken();

        if (alarmManager != null)
            alarmManager.MachineBroken();

        Debug.Log(gameObject.name + " is kapot!");
    }

    public override void Repair()
    {
        if (!isBroken)
            return;

        base.Repair();

        if (brokenMarker != null)
            brokenMarker.SetActive(false);

        if (smokeLoop != null)
            smokeLoop.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        if (factoryLights != null)
            factoryLights.MachineRepaired();

        if (alarmManager != null)
            alarmManager.MachineRepaired();

        if (ScoreManager.Instance != null)
            ScoreManager.Instance.AddScore(10);

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