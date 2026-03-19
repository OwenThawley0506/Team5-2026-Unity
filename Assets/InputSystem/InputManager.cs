using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// for any additional inputs needed to add, bassicly just copy and paste. simple as
[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    public Vector2 moveDirection;
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
    public void SubmitPressed(InputAction.CallbackContext context)
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
      public Vector2 GetMoveDirection() 
    {
        return moveDirection;
    }

    public bool GetInteractPressed() 
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }

    public bool GetSubmitPressed() 
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }

    public void RegisterSubmitPressed() 
    {
        submitPressed = false;
    }


}
