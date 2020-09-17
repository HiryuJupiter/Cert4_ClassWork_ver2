using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Composite pattern??? weighted compsotiion?

[CreateAssetMenu(menuName = "Flock/Behavior/composite")]
public class CompositeBehavior : FlockBehavior
{
    public BehaviorGroup[] behaviors;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector2 move = Vector2.zero;

        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector2 partialMove = behaviors[i].behavior.CalculateMove(agent, context, flock) * behaviors[i].weights;

            if (partialMove != Vector2.zero)
            {
                //Cap the move distance to the weights
                //A cheaper way to compare distance than using Magnitude, which invovles sqrt(x * y).
                if (partialMove.sqrMagnitude > behaviors[i].weights * behaviors[i].weights)
                {
                    partialMove.Normalize();
                    partialMove *= behaviors[i].weights;
                }

                move += partialMove;
            }
        }
        return move;
    }
}