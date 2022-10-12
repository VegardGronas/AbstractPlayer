using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ManagePlayerInputs
{
    private void Start()
    {
        Init();
    }

    public override void Die()
    {
        base.Die();
    }

    private void FixedUpdate()
    {
        PhysicsMove();
    }
}
