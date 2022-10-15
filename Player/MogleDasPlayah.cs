using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace MogleDasPlayer
{
    public class MogleMain : MonoBehaviour
    {
        [Serializable]
        public struct Settings
        {
            public PlayerInput playerInput;
            public InputKeybinds inputKeybinds;
        }
        public Settings settings;
    }

    public class MoglePlayerMove : MogleMain
    {
        
    }

    public class MoglePlayerInput : MoglePlayerMove
    {
        private void OnEnable()
        {
           settings.playerInput.actions.FindAction(settings.inputKeybinds.Movement).performed += Movement;
           settings.playerInput.actions.FindAction(settings.inputKeybinds.Jump).performed += Jumping;
           settings.playerInput.actions.FindAction(settings.inputKeybinds.Sprint).performed += Sprint;
           settings.playerInput.actions.FindAction(settings.inputKeybinds.Duck).performed += Duck;
           settings.playerInput.actions.FindAction(settings.inputKeybinds.Interact).performed += Interact;
           settings.playerInput.actions.FindAction(settings.inputKeybinds.Inventory).performed += Inventory;
           settings.playerInput.actions.FindAction(settings.inputKeybinds.Pause).performed += Pause;
        }

        /*Inputs for movement in game */
        public void Movement(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("moving");
            }

            if (context.canceled)
            {

            }
        }

        public void Jumping(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Jumping");
            }

            if (context.canceled)
            {

            }
        }

        public void Sprint(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Sprinting");
            }

            if (context.canceled)
            {

            }
        }

        public void Duck(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Ducking");
            }

            if (context.canceled)
            {

            }
        }

        /*Inputs for interactions in game */
        public void Interact(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Interact");
            }

            if (context.canceled)
            {

            }
        }

        /*Inputs for movement in game */
        public void Inventory(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Toggle inventory");
            }
        }

        /*Game settings buttons*/
        public void Pause(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Toggle pause");
            }
        }
        /* */

        
    }
}
