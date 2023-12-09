using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BatteryRecharge : MonoBehaviour
{
    public FlashlightManager flashlightManager;
    public Slider rechargeSlider;
    public float rechargeTime = 5f;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.R) && other.CompareTag("Player"))
        {
            StartCoroutine(RechargeBatteryCoroutine());
        }
    }

    private IEnumerator RechargeBatteryCoroutine()
    {
        flashlightManager.ToggleFlashlight();
        rechargeSlider.gameObject.SetActive(true);

        float timer = 0f;

        while (timer < rechargeTime)
        {
            timer += Time.deltaTime;
            float progress = timer / rechargeTime;
            rechargeSlider.value = progress * 100f;

            yield return null;
        }

        flashlightManager.Battery = flashlightManager.maxBattery;
        rechargeSlider.value = 0f;
        rechargeSlider.gameObject.SetActive(false);
        flashlightManager.ToggleFlashlight();
       
    }
}
