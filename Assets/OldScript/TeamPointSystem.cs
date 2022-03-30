using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Class_3
{
    public class TeamPointSystem : Singleton<TeamPointSystem>
    {
        public int teamNum;
        public List<Team> teams = new List<Team>();
        public List<ScorableZoneComponent> zones = new List<ScorableZoneComponent>();
        // need a way to get all the team members when this things is added to the scene
        // need a way for team members to rigister DYNAMICALLY as THEY are added to the scene

        public override void Awake()
        {
            base.Awake();

            var scorerComponents = FindObjectsOfType<ScorerComponent>();

            foreach (var scorerComponent in scorerComponents)
            {
                // without LINQ...
                if (!teams.Any(team => team.ID.Equals(scorerComponent.teamID)))
                {
                    var team = new Team()
                    {
                        ID = scorerComponent.teamID,
                        Members = new List<ScorerComponent> { scorerComponent }
                    };
                    teams.Add(team);
                }
                else
                {
                    var team = teams.FirstOrDefault(team => team.ID.Equals
                    (scorerComponent.teamID));
                    if (team.Members.Contains(scorerComponent)) return;
                    team.Members.Add(scorerComponent);
                }
            }
        }
        private void Update()
        {

        }
    }
}