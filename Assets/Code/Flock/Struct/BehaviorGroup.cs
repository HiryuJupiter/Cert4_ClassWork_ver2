using UnityEngine;
using System.Collections;

[System.Serializable]
public struct BehaviorGroup
{
    public FlockBehavior behavior;
    public float weights;
}