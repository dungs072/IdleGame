using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingLineManager : MonoBehaviour
{
    [SerializeField] private int maxCustomerCanLine = 10;
    [SerializeField] private float bottomDistance = 2f;
    private int currentCustomerInLine = 0;
    private Vector3 currentPosition;
    private void Start()
    {
        currentPosition = transform.position;
    }
    public Vector3 GetNextWaitingLinePosition()
    {
        if (currentCustomerInLine == maxCustomerCanLine)
        {
            return default;
        }
        currentPosition += transform.forward * -1 * bottomDistance;
        currentCustomerInLine++;

        return currentPosition;
    }
    public bool IsMaxCustomers()
    {
        return currentCustomerInLine == maxCustomerCanLine;
    }
}
