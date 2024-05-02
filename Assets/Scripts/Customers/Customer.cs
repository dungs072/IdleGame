using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIController))]
public class Customer : MonoBehaviour
{
    [SerializeField] private Transform holdingPlace;
    [SerializeField] private AIController aIController;

    private List<GameObject> items = new List<GameObject>();
    public void HoldItem(GameObject item)
    {   
        items.Add(item);
        item.transform.position = holdingPlace.position;
        item.transform.rotation = Quaternion.identity;
        item.transform.SetParent(holdingPlace);
    }
    public bool IsReachDestination()
    {
        return aIController.IsReachDestination();
    }
    public void SetDestination(Vector3 position)
    {
        aIController.SetDestination(position);
    }
    public Vector3 GetDestination()
    {
        return aIController.GetDestination();   
    }
}
