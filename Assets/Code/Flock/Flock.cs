﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehavior behavior;

    [Range(10, 500)]
    public int startingCount = 250;
    const float AgentDensity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquaredAvoidanceRadius { get { return squareAvoidanceRadius; } }

    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                Random.insideUnitCircle * startingCount * AgentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
                );
            newAgent.name = "Agent " + i;
            newAgent.Initialize(this);
            agents.Add(newAgent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);

            //FOR DEMO ONLY
            //agent.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);

            Vector2 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }
    }

    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
        foreach (Collider2D c in contextColliders)
        {
            if (c != agent.Collider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }

}


/*
 public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    public FlockBehavior behavior;

    [Range(10, 500)]    public int      startingCount = 250;
    [Range(1f, 100f)]   public float    driveFactor = 10f;
    [Range(1f, 100f)]   public float    maxSpeed = 5f;
    [Range(1f, 10f)]    public float    neighborRadius = 1.5f;

    List<FlockAgent> agents = new List<FlockAgent>();

    //Cache
    float sqrMaxSpeed;
    float sqrNeighborRadius;

    //Const
    const float AgentDensity = 0.08f;

    #region Properties
    public float SquaredAvoidanceRadius { get; private set; }

    Quaternion randomRotation => Quaternion.Euler(Vector3.forward* Random.Range(0, 360f));
    #endregion

    void Start()
    {
        //Cache
        sqrMaxSpeed = maxSpeed * maxSpeed;
        sqrNeighborRadius = neighborRadius * neighborRadius;
        SquaredAvoidanceRadius = sqrNeighborRadius * 0.5f;

        Debug.Log("squaredMaxSpeed: " + sqrMaxSpeed);
        Debug.Log("squaredNeighborRadius: " + sqrNeighborRadius);
        Debug.Log("SquaredAvoidanceRadius: " + SquaredAvoidanceRadius);

        //Spawn agents
        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate( 
                agentPrefab, 
                Random.insideUnitCircle * startingCount * AgentDensity,
                randomRotation, 
                transform  
                );
            newAgent.name = "Agent " + i;
            newAgent.Initialize(this);
            agents.Add(newAgent);
        }
    }

    void Update()
    {
        foreach (FlockAgent agent in agents)
        {
            List<Transform> nearbyAgents = GetNearbyObjects(agent);

            agent.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, nearbyAgents.Count / 6f);

            Vector2 move = behavior.CalculateMove(agent, nearbyAgents, this);
            move *= driveFactor;
            if (move.sqrMagnitude > sqrMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }
    }
    
    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> neighbors = new List<Transform>();

        Collider2D[] neighborColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
        foreach (Collider2D c in neighborColliders)
        {
            if (c != agent.Collider)
            {
                neighbors.Add(c.transform);
            }
        }

        return neighbors;
    }
}
 
 */