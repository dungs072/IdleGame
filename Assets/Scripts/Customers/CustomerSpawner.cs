using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private Customer customerPrefab;
    [SerializeField] private WaitingLineManager waitingLineManager;
    [SerializeField] private CustomerWaitingLineManager customerManager;
    [SerializeField] private float nextCustomerSpawnTime = 5f;
    private float currentNextTime = 0f; 
    private void Update()
    {
        if(waitingLineManager.IsMaxCustomers()){return;}
        if(currentNextTime>=nextCustomerSpawnTime)
        {
            currentNextTime = 0f;
            SpawnCustomer();
        }
        else
        {
            currentNextTime+=Time.deltaTime;
        }
    }
    private void SpawnCustomer()
    {
        var desPosition = waitingLineManager.GetNextWaitingLinePosition();
        var customerInstance = Instantiate(customerPrefab,transform.position,Quaternion.identity);
        customerInstance.SetDestination(desPosition);
        customerManager.AddCustomer(customerInstance);
        
    }
}
