using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWaitingLineManager : MonoBehaviour
{
    private List<AIController> customers = new List<AIController>();
    public void AddCustomer(AIController customer)
    {
        customers.Add(customer);    
    }
}
