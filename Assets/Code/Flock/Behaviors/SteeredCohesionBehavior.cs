using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Flock/Behavior/Steered Cohesion")]
public class SteeredCohesionBehavior : FlockBehavior
{
    Vector2 currentVelocity;
    public float agentSmoothTime = 0.5f;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector2 move = Vector2.zero;

        if (context.Count > 0)
        {
            //Find middle point among neighbors
            foreach (Transform neighbor in context)
            {
                move += (Vector2)neighbor.position;
            }
            move /= context.Count;
            move -= (Vector2)agent.transform.position;

            //Only a portion of the move direction, between where the agent is currently moving towards (transform.up),
            //and where the middle point is, so that agents that are further away will get pushed in further.
            move = Vector2.SmoothDamp(agent.transform.up, move, ref currentVelocity, agentSmoothTime, Mathf.Infinity, Time.deltaTime);
        }
        //Debug.Log("SteeredCohesionBehavior: " + move);

        return move;
    }
}