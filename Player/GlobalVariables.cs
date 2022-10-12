using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Globalvariables", menuName = "Variables/Global", order = 1)]
public class GlobalVariables : ScriptableObject
{
    public GameObject mainMenu;
    public bool dead;
    public bool PauseGame;

}
