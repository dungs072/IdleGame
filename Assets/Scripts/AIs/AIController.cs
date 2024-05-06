using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private Vector3 destination;
    public void SetDestination(Vector3 position)
    {
        destination = position;
        agent.SetDestination(position);
    }
    public bool IsReachDestination()
    {
        return (destination-transform.position).sqrMagnitude<=1f;
    }
    public Vector3 GetDestination()
    {
        return destination;
    }
    public void Stop(bool state)
    {
        agent.isStopped = state;
    }
}
