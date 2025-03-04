﻿//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
//public class AlignmentBehavior : FlockBehavior
//{
//    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> neighbors, Flock flock)
//    {
//        if (neighbors.Count > 0)
//        {
//            Vector2 move = Vector2.zero;
//            foreach (Transform neighbor in neighbors)
//            {
//                move += (Vector2)neighbor.up;
//            }
//            move /= neighbors.Count;
//            return move;
//        }
//        return agent.transform.up;
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FlockBehavior
{

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //If no neighbors, maintain current alignment
        if (context.Count == 0)
        {
            return agent.transform.up;
        }

        //Add all points together and average
        Vector2 alignmentMove = Vector2.zero;

        foreach (Transform item in context)
        {
            alignmentMove += (Vector2)item.transform.up;
        }
        alignmentMove /= context.Count;

        //Create offset from agent position
        //alignmentMove += agent.transform.up;

        return alignmentMove;
    }

}
