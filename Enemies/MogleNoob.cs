using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MogleNoob : MonoBehaviour, IMoglerDamage
{
    public float Health { get; set; }

    public void Init() 
    {
        Health = 100f;
    }

    public void Damage(float damageAmount)
    {
        Health -= damageAmount;
    }
}
