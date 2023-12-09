using UnityEngine;

public class FlashlightManager : MonoBehaviour
{
    int TurnOnHash = Animator.StringToHash("LightOn");
    int TurnOffHash = Animator.StringToHash("LightOff");

    public Light flashlight;
    public bool TurnedOn = false;
    public int Battery;
    public int maxBattery;
    public float maxIntensity;

    private float batteryDecreaseTimer = 0f;
    private float batteryDecreaseInterval = 1f;

    [SerializeField] Animator _animator;
    bool isOn;
    private void Start()
    {
        flashlight.enabled = false;
        Battery = maxBattery;
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

    public void ToggleFlashlight()
    {
        flashlight.enabled = !flashlight.enabled;
        TurnedOn = flashlight.enabled;
        if (!isOn)
        {
            _animator.SetTrigger(TurnOnHash);
            isOn = !isOn;
        }
        else
        {
            _animator.SetTrigger(TurnOffHash);
            isOn = !isOn;
        }
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
        Battery--;

        if (Battery <= 0)
        {
            Battery = 0;
            flashlight.intensity = 0;

            _animator.SetTrigger(TurnOffHash);
            isOn = false;
        }
    }

    private void UpdateLightIntensity()
    {
        float decreaseRate = maxIntensity / maxBattery;
        float intensity = Battery * decreaseRate;
        flashlight.intensity = Mathf.Clamp(intensity, 0f, maxIntensity);
    }

    public void RechargeBattery(int amount)
    {
        Battery = Mathf.Clamp(Battery + amount, 0, maxBattery);
    }
}
