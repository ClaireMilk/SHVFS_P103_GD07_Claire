using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : CharacterBehaviour
{
    public override void Update()
    {
        base.Update();

        xInput = Input.GetAxis("Horizontal1");
        yInput = Input.GetAxis("Vertical1");

        Movement();
    }
}
