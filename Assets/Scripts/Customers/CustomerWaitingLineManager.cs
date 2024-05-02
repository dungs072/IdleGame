using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWaitingLineManager : MonoBehaviour
{
    private List<Customer> customers = new List<Customer>();
    public void AddCustomer(Customer customer)
    {
        customers.Add(customer);
    }
    public Customer GetTheFirstCustomers()
    {
        if(customers.Count==0){return null;}
        return customers[0].GetComponent<Customer>();
    }
    public Customer GetTheLastCustomer()
    {
        if(customers.Count==0){return null;}
        return customers[customers.Count-1].GetComponent<Customer>();
    }
    public int GetCurrentCustomerWaitingInLine()
    {
        return customers.Count;
    }
    public bool HasCustomer()
    {
        return customers.Count>0;
    }
    public void RemoveCustomer(Customer customer)
    {
        customers.Remove(customer);
    }
    // should move before delete the first customer from list;
    public void MoveWaitingLine()
    {
        if(customers.Count==1){return;}
        List<Vector3> destinations = new List<Vector3>();
        for(int i = 0;i<customers.Count;i++)
        {
            destinations.Add(customers[i].GetDestination());
        }
        for(int i = 1;i<customers.Count;i++)
        {
            customers[i].SetDestination(destinations[i-1]);
        }
    }

}
