using UnityEngine;
using UnityEngine.InputSystem;

public class ManagePlayerInputs : Player
{
    private InputAction _movement;
    private InputAction _sprint;
    private InputAction _jump;
    private InputAction _pause;

    private void OnEnable()
    {
        _movement = playerInput.actions["Movement"];
        _sprint = playerInput.actions["Sprint"];
        _jump = playerInput.actions["Jumping"];
        _pause = playerInput.actions["Pause"];

        _sprint.performed += Sprint;
        _sprint.canceled += Sprint;
        _jump.performed += Jump;
        _pause.performed += Pause;
        _movement.performed += MoveDirection;
        _movement.canceled += MoveDirection;
    }

    private void OnDisable()
    {
        _sprint.performed -= Sprint;
        _sprint.canceled -= Sprint;
        _jump.performed -= Jump;
        _pause.performed -= Pause;
        _movement.performed -= MoveDirection;
        _movement.canceled -= MoveDirection;
    }

    public void MoveDirection(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movement.horizontal = context.ReadValue<Vector2>().x;
            movement.vertical = context.ReadValue<Vector2>().y;
        }

        if (context.canceled)
        {
            movement.horizontal = 0;
            movement.vertical = 0;
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Sprint(true);
        }

        if (context.canceled)
        {
            Sprint(false);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (groundCheck.grounded)
            {
                Jump();
            }
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            settings.globalVariables.PauseGame = !settings.globalVariables.PauseGame;
            mainMenu.SetActive(settings.globalVariables.PauseGame);
        }
    }
}
