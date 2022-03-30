using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Class_3
{
    [Serializable]
    public class Team
    {
        public int ID;
        public float score;
        public List<ScorerComponent> Members;
    }
}