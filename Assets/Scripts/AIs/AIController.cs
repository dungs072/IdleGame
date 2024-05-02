using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    public void SetDestination(Vector3 position)
    {
        agent.SetDestination(position);
    } 
}
