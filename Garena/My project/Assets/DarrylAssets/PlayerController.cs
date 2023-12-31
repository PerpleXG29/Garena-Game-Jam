using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public float walkNoiseDistance = 8f;
    public float runNouseDistance = 14f;
    private Transform cameraTransform;

    public InputManager inputManager;
    public PlayerAudioManager AudioManager;
    public LayerMask ZombieMask;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;

      
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        inputManager = InputManager.Instance;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);

        
        move = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0f) * move;

        controller.Move(move * Time.deltaTime * playerSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        float horizontalRotation = cameraTransform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);
    }
}
