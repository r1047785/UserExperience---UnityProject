using UnityEngine;

public class FactoryLights : MonoBehaviour
{
    private Light[] lightsToControl;

    private int brokenMachines = 0;
    private float baseIntensity = 1f;

    private void Start()
    {
        lightsToControl = FindObjectsByType<Light>(FindObjectsSortMode.None);

        if (lightsToControl.Length > 0)
        {
            baseIntensity = lightsToControl[0].intensity;
        }
    }

private void Update()
{
    if (brokenMachines > 0)
    {
        bool lightsOn = (Time.time % 4.5f) > 0.5f;

        foreach (Light light in lightsToControl)
        {
            light.intensity = lightsOn ? baseIntensity : 0f;
        }
    }
}

    public void MachineBroken()
    {
        brokenMachines++;
        UpdateLights();
    }

    public void MachineRepaired()
    {
        brokenMachines--;

        if (brokenMachines < 0)
            brokenMachines = 0;

        UpdateLights();
    }

    private void UpdateLights()
    {
    Color targetColor = brokenMachines > 0
    ? new Color(0.8f, 0.2f, 0.2f)
    : Color.white;

        foreach (Light light in lightsToControl)
        {
            light.color = targetColor;

            if (brokenMachines == 0)
            {
                light.intensity = baseIntensity;
            }
        }
    }
}