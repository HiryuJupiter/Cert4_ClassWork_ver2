﻿using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehavior : ScriptableObject
{
    public abstract Vector2 CalculateMove(FlockAgent agent, List<Transform> neighbors, Flock flock);
}
