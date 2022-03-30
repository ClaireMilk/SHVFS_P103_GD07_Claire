using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public GameObject camera;
    public float cameraSpeed;

    public float movementSpeed;
    private Rigidbody rb;
    private Animator anim;
    private Vector3 processInput;

    private bool canJump;
    private bool isJump;
    public float jumpSpeed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        camera.transform.Rotate((-mouseY * cameraSpeed / 10), 0, 0);
        gameObject.transform.Rotate(0, (mouseX * cameraSpeed), 0);

        var horizontalInput = Input.GetAxis("Horizontal1");
        var verticalInput = Input.GetAxis("Vertical");
        if (verticalInput >= 0)
        {
            processInput = transform.forward * verticalInput + transform.right * horizontalInput;
        }
        if (verticalInput < 0)
        {
            processInput = transform.forward * verticalInput / 3 + transform.right * horizontalInput;
        }

        if (horizontalInput != 0 || verticalInput > 0)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }

        if (verticalInput < 0)
        {
            anim.SetBool("Back", true);
        }
        else
        {
            anim.SetBool("Back", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            isJump = true;
            anim.SetBool("Jump", true);
        }
    }

    private void FixedUpdate()
    {
        //rb.AddForce(processInput * MovementSpeed * Time.deltaTime, ForceMode.VelocityChange);
        rb.MovePosition(transform.position + (processInput * movementSpeed * Time.deltaTime));
        //Debug.Log(Time.deltaTime);
        //Debug.Log($"X: {rb.velocity.x} | Y: {rb.velocity.z}");
        if (canJump && isJump)
        {
            rb.AddForce(rb.transform.up * jumpSpeed);
            isJump = false;
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
        anim.SetBool("Jump", false);
    }
}
