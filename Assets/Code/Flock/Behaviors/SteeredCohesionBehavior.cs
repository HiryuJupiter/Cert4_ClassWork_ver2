using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Steered Cohesion")]
public class SteeredCohesionBehavior : FlockBehavior
{

    Vector2 currentVelocity;
    public float agentSmoothTime = 0.1f;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector2.zero;

        //add all points together and average
        Vector2 cohesionMove = Vector2.zero;
        foreach (Transform item in context)
        {
            cohesionMove += (Vector2)item.position;
        }
        cohesionMove /= context.Count;

        //create offset from agent position
        cohesionMove -= (Vector2)agent.transform.position;
        cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);
        return cohesionMove;
    }
}

/*
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
 */