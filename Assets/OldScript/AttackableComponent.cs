using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackableComponent : MonoBehaviour
{
    public AttackGUIDComponent AttackGUIDComponent;
    //this is an auto-property

    public Guid GUID => AttackGUIDComponent.ID;

}
