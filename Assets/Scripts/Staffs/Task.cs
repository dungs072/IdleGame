using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum TaskType
{
    Waiter,
    CashRegister,
    Bringer
}
public class Task : MonoBehaviour
{

    [SerializeField] private Transform neededPlaceToFinishTask;
    [SerializeField] private Holder holder;
    [SerializeField] private bool needToMoveNextPlace = true;
    [SerializeField] private TaskType taskType;
    public Transform NeededPlaceToFinishTask => neededPlaceToFinishTask;
    public Holder Holder => holder;
    public TaskType TaskType => taskType;
    public StaffInfo StaffInfo{get;set;} = null;


    public bool NeedToMoveNextPlace
    {
        get
        {
            return needToMoveNextPlace;
        }
        set
        {
            needToMoveNextPlace = value;
        }
    }
}

