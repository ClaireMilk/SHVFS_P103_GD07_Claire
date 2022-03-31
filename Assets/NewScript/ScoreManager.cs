using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class ScoreManager : Singleton<ScoreManager>
{
    public int playerNum;
    public List<Team> teams = new List<Team>();

    public void Awake()
    {
        foreach (var scoreComponent in FindObjectsOfType<Scorer>())
            if (!teams.Any(teams => teams.playerID.Equals(scoreComponent.playerID)))
            {
                var team = new Team()
                {
                    playerID = scoreComponent.playerID,
                    player = scoreComponent,
                };
                teams.Add(team);

            }
        foreach(var zoneComponent in FindObjectsOfType<ScoreZone>())
        {
            var team = teams.FirstOrDefault(team => team.playerID.Equals(zoneComponent.zoneID));
            if (team!=null)
            {
                team.zone = zoneComponent;
            }
        }
    }
    [Serializable]
    public class Team
    {
        public ScoreZone zone;
        public int playerID;
        public Scorer player;
        public int score;
    }
}
