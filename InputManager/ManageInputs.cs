using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoglerDamage
{
    /// <summary>
    /// THIS IS THE NAMESPACE
    /// </summary>
    public void Init() { }

    public float Health { get; set; }

    public void Damage(float damageAmount){}
}
