using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Class_3
{
    public class ScorerComponent : MonoBehaviour
    {
        public int teamID;
        public int zoneID;

        private void OnDestroy()
        {
            var teams = TeamPointSystem.instantce.teams;
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].ID == teamID)
                {
                    teams[i].Members.Remove(this);
                }
            }

            var allzones = FindObjectsOfType<ScorableZoneComponent>();

            foreach (var zone in allzones)
            {
                if (zone.zoneID == this.zoneID)
                {
                    var triggerTeamID = zone.TriggerTeamID;
                    for (int i = 0; i < triggerTeamID.Count; i++)
                    {
                        if (triggerTeamID[i] == this.teamID)
                        {
                            triggerTeamID.Remove(triggerTeamID[i]);
                            break;
                        }
                    }
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<ScorableZoneComponent>())
            {
                zoneID = other.GetComponent<ScorableZoneComponent>().zoneID;
            }
        }
    }
}
