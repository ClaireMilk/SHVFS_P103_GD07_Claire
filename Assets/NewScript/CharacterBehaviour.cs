using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    protected float xInput;
    protected float yInput;
    protected Vector3 processMovement;
    public GameObject playerBear;

    public float moveSpeed;
    protected Rigidbody rb;
    protected Animator anim;
    public bool hasBall;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        hasBall = false;
    }
    public void FixedUpdate()
    {
        rb.MovePosition(transform.position + (processMovement * moveSpeed * Time.deltaTime));
    }

    public void Movement()
    {
        processMovement = transform.forward * yInput + transform.right * xInput;

        if (yInput > 0 && xInput == 0)
        {
            playerBear.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (yInput < 0 && xInput == 0)
        {
            playerBear.transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if(xInput > 0 && yInput == 0)
        {
            playerBear.transform.localEulerAngles = new Vector3(0, 90, 0);
        }
        if (xInput < 0 && yInput == 0)
        {
            playerBear.transform.localEulerAngles = new Vector3(0, -90, 0);
        }
        if(xInput > 0 && yInput > 0)
        {
            playerBear.transform.localEulerAngles = new Vector3(0, 45, 0);
        }
        if (xInput < 0 && yInput < 0)
        {
            playerBear.transform.localEulerAngles = new Vector3(0, -135, 0);
        }
        if (xInput > 0 && yInput < 0)
        {
            playerBear.transform.localEulerAngles = new Vector3(0, 135, 0);
        }
        if (xInput < 0 && yInput > 0)
        {
            playerBear.transform.localEulerAngles = new Vector3(0, -45, 0);
        }

        if(xInput != 0 || yInput != 0)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Ball>())
        {
            hasBall = true;
        }
    }
}
