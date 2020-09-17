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
                //else
                //{
                //    Debug.Log("flock.SquaredAvoidanceRadius: " + flock.SquaredAvoidanceRadius + ", Vector2.SqrMagnitude(neighbor.position - agent.transform.position): " + Vector2.SqrMagnitude(neighbor.position - agent.transform.position));
                //}
            }

            if (avoidCount > 0)
            {
                move /= avoidCount;
            }
            Debug.DrawRay(agent.transform.position, move, Color.yellow);
        }
        //Debug.Log("AvoidanceBehavior: " + move);
        return move;
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
//public class AvoidanceBehavior : FlockBehavior
//{
//    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
//    {
//        //If no neighbors, return no adjustment
//        if (context.Count == 0)
//        {
//            return Vector2.zero;
//        }

//        //Add all points together and average
//        Vector2 avoidanceMove = Vector2.zero;
//        int nAvoid = 0;

//        foreach (Transform item in context)
//        {
//            if (Vector2.SqrMagnitude(item.position - agent.transform.position) < flock.SquaredAvoidanceRadius)
//            {
//                avoidanceMove += (Vector2)(agent.transform.position - item.position); //We're moving away from the neighbors
//                nAvoid++;
//            }
//        }

//        if (nAvoid > 0)
//        {
//            avoidanceMove /= nAvoid;
//            return avoidanceMove;
//        }

//        return avoidanceMove;
//    }
//    #region Fields
//    #endregion

//    #region MonoBehaviour    

//    #endregion

//    #region Methods
//    #endregion
//}
