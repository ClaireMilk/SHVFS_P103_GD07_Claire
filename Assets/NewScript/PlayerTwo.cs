using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : CharacterBehaviour
{
    public override void Update()
    {
        base.Update();

        xInput = Input.GetAxis("Horizontal2");
        yInput = Input.GetAxis("Vertical2");

        Movement();
    }
}
