using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private List<Seat> seats = new List<Seat>();
    public bool IsFull{get; private set;}
    public Seat GetAvailableSeat()
    {
        foreach(var seat in seats)
        {
            if(seat.IsOccupied)
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
        foreach(var s in seats)
        {
            if(s.IsOccupied)
            {
                count++;
            }
            if(s==seat)
            {
                seat.IsOccupied = true;
                count++;
            }
        }
        if(count==seats.Count)
        {
            IsFull = true;
        }
    }
}
[Serializable]
public class Seat
{
    public Transform foodPlace;
    public Transform chair; 
    public bool IsOccupied;
}
