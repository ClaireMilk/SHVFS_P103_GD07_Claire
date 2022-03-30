using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointSystem : Singleton<PlayerPointSystem>
{
    public int playerNum;
    public List<Players> players = new List<Players>();
    public List<ScoreZone> zones = new List<ScoreZone>();

    public void ScorePoints()
    {

    }
}
