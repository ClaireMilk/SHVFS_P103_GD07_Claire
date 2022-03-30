using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plane")
        {
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Bear")
        {
            this.gameObject.transform.parent = other.gameObject.transform;
        }
    }

}
