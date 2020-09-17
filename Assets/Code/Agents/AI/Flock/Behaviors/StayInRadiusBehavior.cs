using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Flock/Behavior/Stay In Radius")]
public class StayInRadiusBehavior : FlockBehavior
{
    public Vector2 center;
    public float maxDistance = 15f;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> neighbors, Flock flock)
    {
        Vector2 dirToCenter = center - (Vector2)agent.transform.position;
        float t = dirToCenter.magnitude / maxDistance;
        
        if (t  > 0.9f)
        {
            return dirToCenter * t * t;
        }

        return Vector2.zero;
    }
}