using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ScoreZone>() && ((this.gameObject.GetComponent<PlayerOne>()&& this.gameObject.GetComponent<PlayerOne>().hasBall)||
            (this.gameObject.GetComponent<PlayerTwo>() && this.gameObject.GetComponent<PlayerTwo>().hasBall)))
        {
            PlayerPointSystem.Instance.ScorePoints();
        }
    }
}
