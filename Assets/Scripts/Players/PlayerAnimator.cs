using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private readonly int CarryingLocomotionHash = Animator.StringToHash("CarryingLocomotion");
    private readonly int LocomotionHash = Animator.StringToHash("Locomotion");
    [SerializeField] private Animator animator;
    private void Start()
    {
        GetComponent<HoldingHandler>().ItemAdded+=OnItemAdded;
        GetComponent<HoldingHandler>().ItemRemovedAll+=OnItemRemovedAll;
    }
    private void OnDestroy()
    {
        GetComponent<HoldingHandler>().ItemAdded-=OnItemAdded;
        GetComponent<HoldingHandler>().ItemRemovedAll-=OnItemRemovedAll;
    }
    public void SetLocomotionValue(float desireValue)
    {
        float value = Mathf.Lerp(animator.GetFloat(LocomotionHash), desireValue, Time.deltaTime * 5);
        animator.SetFloat(LocomotionHash, value);
    }
    public void SetCarryingAnimation(bool isCarrying)
    {
        if (isCarrying)
        {
            animator.CrossFadeInFixedTime(CarryingLocomotionHash, 0.1f);
        }
        else
        {
            animator.CrossFadeInFixedTime(LocomotionHash, 0.1f);
        }
    }
    private void OnItemAdded()
    {
        SetCarryingAnimation(true);
    }
    private void OnItemRemovedAll()
    {
        SetCarryingAnimation(false);
    }
}
