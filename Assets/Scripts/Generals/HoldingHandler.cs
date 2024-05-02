using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingHandler : MonoBehaviour
{
    [SerializeField] private int maxHoldingSize = 2;
    [SerializeField] private float topDistance = 0.2f;
    [SerializeField] private Transform holdingPlace;
    private List<GameObject> items = new List<GameObject>();
    private Resource currentHoldingResource;
    public void AddItemToHold(GameObject item)
    {
        if (items.Count > 0)
        {
            item.transform.position = GetLastItem().transform.position +
                                    transform.up * topDistance;
        }
        else
        {
            item.transform.position = holdingPlace.position +
                                holdingPlace.up * topDistance;
        }
        
        item.transform.SetParent(holdingPlace);
        item.transform.rotation = Quaternion.identity;
        items.Add(item);
    }
    public void RemoveItemHolding(GameObject item )
    {
        if(items.Count==0){return;}
        items.Remove(item);
    }
    public GameObject GetLastItem()
    {
        return items[items.Count - 1];
    }
    public bool IsMaxSize()
    {
        return items.Count == maxHoldingSize;
    }
    public int GetItemAmount()
    {
        return items.Count;
    }
    public void SetCurrentHoldingResource(Resource resource)
    {
        currentHoldingResource = resource;
    }
}
