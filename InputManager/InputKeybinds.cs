using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Keybinds", menuName = "Input/Keybinds", order = 1)]
public class InputKeybinds : ScriptableObject
{
    public string Movement;
    public string Jump;
    public string Sprint;
    public string Duck;
    public string Interact;
    public string Inventory;
    public string Pause;
}
