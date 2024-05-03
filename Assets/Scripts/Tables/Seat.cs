using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Seat : MonoBehaviour
{
    public event Action OnNotOccupiedSeat;
    public Transform foodPlace;
    public Transform chair;
    public Holder holder;
    public MatrixHolder MoneyHolder;
    public bool IsOccupied;

    private void Start()
    {
        holder.OnTookGarbage+=TookGarbage;
    }
    private void TookGarbage()
    {
        IsOccupied = false;
        OnNotOccupiedSeat?.Invoke();
    }
}
