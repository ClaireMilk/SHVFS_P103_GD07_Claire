using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Text textOne;
    public Text textTwo;

    public void UpdateScore(int scoreOne)
    {
        textOne.text = "" + scoreOne;
    }

    public void UpdateAnotherScore(int scoreTwo)
    {
        textTwo.text = "" + scoreTwo;
    }
}
