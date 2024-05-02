using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingLineManager : MonoBehaviour
{
    [SerializeField] private CustomerWaitingLineManager customerManager;
    [SerializeField] private int maxCustomerCanLine = 10;
    [SerializeField] private float bottomDistance = 2f;
    public Vector3 GetNextWaitingLinePosition()
    {
        if (customerManager.GetCurrentCustomerWaitingInLine() == maxCustomerCanLine)
        {
            return default;
        }
        if(!customerManager.HasCustomer())
        {
            return transform.position+ transform.forward * -1 * bottomDistance;
        }
        else
        {
            var customer = customerManager.GetTheLastCustomer();
            return customer.GetDestination()+transform.forward*-1*bottomDistance;
        }

    }
    public bool IsMaxCustomers()
    {
        return customerManager.GetCurrentCustomerWaitingInLine() == maxCustomerCanLine;
    }
}
