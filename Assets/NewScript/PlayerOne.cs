using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : CharacterBehaviour
{
    public void Update()
    {
        xInput = Input.GetAxis("Horizontal1");
        yInput = Input.GetAxis("Vertical1");

        Movement();
    }
}
