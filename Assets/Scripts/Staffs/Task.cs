using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Task : MonoBehaviour
{
    [SerializeField] private Transform neededPlaceToFinishTask;
    [SerializeField] private Transform holder;
    public Transform NeededPlaceToFinishTaks=>neededPlaceToFinishTask;
    public Transform Holder=>holder;
}

