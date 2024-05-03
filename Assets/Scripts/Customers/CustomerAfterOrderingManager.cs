using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAfterOrderingManager : MonoBehaviour
{
    [SerializeField] private Transform exitPlace;
    private List<Customer> customers = new List<Customer>();
    private void Update()
    {
        for(int i =customers.Count-1; i>=0; i--)
        {
            if(customers[i].GetCurrentStatus()==Status.GoToTable&&customers[i].IsReachDestination())
            {
                customers[i].SetCurrentStatus(Status.OnTable);
                customers[i].HandleOnTable();
            }
            if(customers[i].GetCurrentStatus()==Status.Finish&&customers[i].IsReachDestination())
            {
                var customer = customers[i];
                customers.RemoveAt(i);
                Destroy(customer.gameObject);
            }
        }
    }

    public void AddCustomer(Customer customer)
    {
        customers.Add(customer);
        customer.SetExitPlace(exitPlace);
    }
    public void RemoveCustomer(Customer customer)
    {
        customers.Remove(customer);
    }
}
