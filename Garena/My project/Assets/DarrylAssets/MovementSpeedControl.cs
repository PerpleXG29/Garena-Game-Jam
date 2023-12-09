using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MovementSpeedControl : MonoBehaviour
{
    public float maxStamina;
    public float sprintSpeed;
    public float regenerationRate;
   

    private float currentStamina;
    public bool isSprinting = false;
    private float initialSpeed;

    public Slider staminaSlider;
    public PlayerController playerController;
  

    public float slowSpeed;
    public bool isSlow = false;

    private void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaUI();
        initialSpeed = playerController.playerSpeed;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            isSprinting = true;
            currentStamina -= Time.deltaTime * 10;
            UpdateStaminaUI();
            SetPlayerSpeed(sprintSpeed);
        }

        else if (Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift))
        {
            isSlow = true;
            SetPlayerSpeed(slowSpeed);
        }

        else
        {
            isSprinting = false;
            if (!Input.GetKey(KeyCode.LeftShift) && currentStamina < maxStamina)
            {
                currentStamina += Time.deltaTime * regenerationRate;
                UpdateStaminaUI();
            }
            isSlow = false;
            SetPlayerSpeed(initialSpeed);
        }


    }

    public void SetPlayerSpeed(float speed)
    {
        playerController.playerSpeed = speed;
    }

    private void UpdateStaminaUI()
    {
        staminaSlider.value = currentStamina;
    }
}
