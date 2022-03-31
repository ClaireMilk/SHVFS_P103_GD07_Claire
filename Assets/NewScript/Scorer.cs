using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scorer : MonoBehaviour
{
    public int playerID;

    public void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.GetComponent<PlayerOne>())
        {
            if (other.GetComponent<ScoreZone>() && this.gameObject.GetComponent<PlayerOne>().hasBall)
            {
                if (other.GetComponent<ScoreZone>().zoneID == playerID)
                {
                    ScoreManager.Instance.teams[playerID-1].score += 1;

                    if (gameObject.GetComponentInChildren<Ball>() == null) return;

                    var ball = gameObject.GetComponentInChildren<Ball>();

                    Destroy(ball.gameObject);

                    this.gameObject.GetComponent<PlayerOne>().hasBall = false;
                }
            }
            UIManager.Instance.UpdateScore(ScoreManager.Instance.teams[playerID - 1].score);
        }
        else if (this.gameObject.GetComponent<PlayerTwo>())
        {
            if (other.GetComponent<ScoreZone>() && this.gameObject.GetComponent<PlayerTwo>().hasBall)
            {
                if (other.GetComponent<ScoreZone>().zoneID == playerID)
                {
                    ScoreManager.Instance.teams[playerID - 1].score += 1;
                    //ScoreManager.Instance.ScorePoints();

                    if (gameObject.GetComponentInChildren<Ball>() == null) return;

                    var ball = gameObject.GetComponentInChildren<Ball>();

                    Destroy(ball.gameObject);

                    this.gameObject.GetComponent<PlayerTwo>().hasBall = false;
                }
            }
            UIManager.Instance.UpdateAnotherScore(ScoreManager.Instance.teams[playerID - 1].score);
        }
    }

    public void RestartGame()
    {
        if(ScoreManager.Instance.teams[playerID - 1].score >= 10)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
