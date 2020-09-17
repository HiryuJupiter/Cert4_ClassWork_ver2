using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> neighbors, Flock flock)
    {
        Vector2 move = Vector2.zero;
        if (neighbors.Count > 0)
        {
            foreach (Transform neighbor in neighbors)
            {
                move += (Vector2)neighbor.up;
            }
            move /= neighbors.Count;
        }
        return move;
    }
}