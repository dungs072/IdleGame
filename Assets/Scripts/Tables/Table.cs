using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class Table : MonoBehaviour
{
    [SerializeField] private List<Seat> seats = new List<Seat>();
    public bool IsFull { get; private set; }
    private void Start()
    {
        foreach(var seat in seats)
        {
            seat.OnNotOccupiedSeat+=NotOccupiedSeat;
        }
    }
    private void NotOccupiedSeat()
    {
        int count = seats.Count;
        foreach(var seat in seats)
        {
            if(!seat.IsOccupied)
            {
                count--;
                IsFull = false;
            }
        }
    }

    public Seat GetAvailableSeat()
    {
        foreach (var seat in seats)
        {
            if (seat.IsOccupied)
            {
                continue;
            }
            else
            {
                return seat;
            }
        }
        return null;
    }
    public void SetSeatOccupied(Seat seat)
    {
        int count = 0;
        foreach (var s in seats)
        {
            if (s.IsOccupied)
            {
                count++;
            }
            if (s == seat)
            {
                seat.IsOccupied = true;
                count++;
            }
        }
        if (count == seats.Count)
        {
            IsFull = true;
        }
    }
}

