using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    Flock flock;
    Collider2D agentCollider;

    //Property
    public Flock AgentFlock { get{ return flock;}}
    public Collider2D Collider { get { return agentCollider; } }

    void Awake()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    public void Initialize (Flock flock)
    {
        this.flock = flock;
    }

    public void Move (Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}