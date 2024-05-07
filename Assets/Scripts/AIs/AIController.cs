using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIController : MonoBehaviour
{
    private readonly int CarryingLocomotionHash = Animator.StringToHash("CarryingLocomotion");
    private readonly int LocomotionHash = Animator.StringToHash("Locomotion");
    private readonly int SittingIdleHash = Animator.StringToHash("SittingIdle");
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    private Vector3 destination;
    private int currentLocomotionHash;
    private void Start()
    {
        currentLocomotionHash = LocomotionHash;
    }
    public void SetDestination(Vector3 position)
    {
        destination = position;
        agent.SetDestination(position);
    }
    public bool IsReachDestination()
    {
        return (destination - transform.position).sqrMagnitude <= 1f;
    }
    public Vector3 GetDestination()
    {
        return destination;
    }
    public void Stop(bool state)
    {
        SetLocomotionValue(state ? 0 : 1);
        agent.isStopped = state;
    }

    // animations
    public void SetLocomotionValue(float value)
    {
        animator.SetFloat(LocomotionHash, value);
    }
    public float GetLocomotionValue()
    {
        return animator.GetFloat(LocomotionHash);
    }
    public void SetCarryingAnimation(bool isCarrying)
    {
        if (isCarrying)
        {
            animator.CrossFadeInFixedTime(CarryingLocomotionHash, 0.1f);
            currentLocomotionHash = CarryingLocomotionHash;
        }
        else
        {
            animator.CrossFadeInFixedTime(LocomotionHash, 0.1f);
            currentLocomotionHash = LocomotionHash;
        }
    }
    public void AddSpeed(float amount)
    {
        agent.speed += amount;
    }

    public void SetSitAnimation(bool canSit)
    {
        if(canSit)
        {
            animator.CrossFadeInFixedTime(SittingIdleHash,0.1f);
        }
        else
        {
            animator.CrossFadeInFixedTime(currentLocomotionHash,0.1f);
        }
    }
}
