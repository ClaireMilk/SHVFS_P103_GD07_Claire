using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private float timer = 0;
    public float originTime;
    public GameObject ball;
    GameObject allBalls;
    public Transform spawnPosition;

    public float ballUpForce;

    void Update()
    {
        float ballRightForce = Random.Range(-200f, 200f);
        float ballForwardForce = Random.Range(-200f, 200f);

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            allBalls = Instantiate(ball, spawnPosition.position, transform.rotation);
            allBalls.GetComponent<Rigidbody>().AddForce(transform.up * ballUpForce + transform.right * ballRightForce + transform.forward * ballForwardForce);
            timer = originTime;
        }
    }
}
