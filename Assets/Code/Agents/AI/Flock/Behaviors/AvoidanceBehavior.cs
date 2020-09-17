using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]

public class AvoidanceBehavior : FlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> neighbors, Flock flock)
    {
        Vector2 move = Vector2.zero;
        if (neighbors.Count > 0)
        {
            int avoidCount = 0;
            foreach (Transform neighbor in neighbors)
            {
                if (Vector2.SqrMagnitude(neighbor.position - agent.transform.position) < flock.SquaredAvoidanceRadius)
                {
                    avoidCount++;
                    move += (Vector2)(agent.transform.position - neighbor.position);
                }
            }

            if (avoidCount > 0)
            {
                move /= avoidCount;
            }
        }

        return move;
    }
}