using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private Vector2 moveDirection;
    public bool jumpPressed = false;
    public bool interactPressed = false;
    public bool submitPressed = false;

    private static InputManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
            {
            Debug.LogError("Found more than one InputManager in this scene");
            Destroy(gameObject);
            return;
            }
        instance = this;
    }

    public static InputManager getInstance()
    {
        return instance;
    }
    public void MovePressed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
    }

    /*public void JumpPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpPressed = true;
        }
        else if (context.canceled)
        {
            jumpPressed = false;
        }
    }*/

    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
        }
        else if (context.canceled)
        {
            interactPressed = false;
        }
    }
    public void submitButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitPressed = true;
        }
        else if (context.canceled)
        {
            submitPressed = false;
        }
    }
}
