using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    public Flock AgentFlock { get; private set; }
    public Collider2D Collider { get; private set; }

    void Awake()
    {
        Collider = GetComponent<Collider2D>();
    }

    public void Initialize (Flock flock)
    {
        AgentFlock = flock;
    }

    public void Move (Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}