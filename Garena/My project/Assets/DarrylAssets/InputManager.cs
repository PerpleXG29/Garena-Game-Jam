using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private static InputManager _instance;

    public static InputManager Instance
    {
        get { return _instance; }
    }
    
    private void Awake() 
    {
        _instance = this;
        playerMovement = new PlayerMovement();
    }

    private void OnEnable()
    {
        playerMovement.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerMovement.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerMovement.Player.Look.ReadValue<Vector2>();
    }
}
