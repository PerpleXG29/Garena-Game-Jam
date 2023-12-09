using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BatteryRecharge : MonoBehaviour
{
    public FlashlightManager flashlightManager;
    public Slider rechargeSlider;
    public float rechargeTime = 5f;

<<<<<<< Updated upstream
    public TextMeshProUGUI RechargeText;
    private bool CanPress = true;
    private void Start()
    {
        RechargeText.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RechargeText.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.R) && other.CompareTag("Player") && CanPress)
=======
    bool isTrigger = false;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.R) && other.CompareTag("Player") && !isTrigger)
>>>>>>> Stashed changes
        {
            RechargeText.enabled = false;
            CanPress = false;
            StartCoroutine(RechargeBatteryCoroutine());
<<<<<<< Updated upstream
            
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RechargeText.enabled = true;
=======
            isTrigger = true;
>>>>>>> Stashed changes
        }
    }

    private IEnumerator RechargeBatteryCoroutine()
    {
        if (flashlightManager.TurnedOn) {
            flashlightManager.ToggleFlashlight();
        }
        rechargeSlider.gameObject.SetActive(true);

        float timer = 0f;

        while (timer < rechargeTime)
        {
            timer += Time.deltaTime;
            float progress = timer / rechargeTime;
            rechargeSlider.value = progress * 100f;

            yield return null;
            
            

        }
        RechargeText.enabled = true;
        CanPress = true;

        flashlightManager.Battery = flashlightManager.maxBattery;
        rechargeSlider.value = 0f;
        rechargeSlider.gameObject.SetActive(false);
<<<<<<< Updated upstream
       
       
=======
        flashlightManager.ToggleFlashlight();
        isTrigger = false;
>>>>>>> Stashed changes
    }
}
