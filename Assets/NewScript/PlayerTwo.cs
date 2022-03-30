using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : CharacterBehaviour
{
    public void Update()
    {
        xInput = Input.GetAxis("Horizontal2");
        yInput = Input.GetAxis("Vertical2");

        Movement();
    }
}
