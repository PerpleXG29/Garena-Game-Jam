using UnityEngine;

public class FlashlightManager : MonoBehaviour
{
    public Light flashlight;
    public bool TurnedOn = false;
    public int Battery = 120;

    private float batteryDecreaseTimer = 0f;
    private float batteryDecreaseInterval = 1f;

    private void Start()
    {
        flashlight.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) || Input.GetMouseButtonDown(0))
        {
            ToggleFlashlight();
        }

        if (TurnedOn)
        {
            UpdateBattery();
        }

        UpdateLightIntensity();
    }

    private void ToggleFlashlight()
    {
        flashlight.enabled = !flashlight.enabled;
        TurnedOn = flashlight.enabled;
    }

    private void UpdateBattery()
    {
        batteryDecreaseTimer += Time.deltaTime;

        if (batteryDecreaseTimer >= batteryDecreaseInterval)
        {
            DecreaseBattery();
            batteryDecreaseTimer = 0f;
        }
    }

    private void DecreaseBattery()
    {
        Battery --;

        if (Battery <= 0)
        {
            Battery = 0;
            flashlight.intensity = 0;
        }
    }

    private void UpdateLightIntensity()
    {
        float maxIntensity = 12f;
        float intensity = Battery / 10f;
        flashlight.intensity = Mathf.Clamp(intensity, 0f, maxIntensity);
    }

    public void RechargeBattery(int amount)
    {
        Battery = Mathf.Clamp(Battery + amount, 0, 120);
       
    }
}
