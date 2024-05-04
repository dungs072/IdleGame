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
        var product = item.GetComponent<ProductInfo>();
        currentHoldingResource = product.Resource;
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

        if(TryGetComponent(out PlayerData playerData))
        {
            playerData.AddExp(1);
        }
    }
    public Resource GetCurrentResourceType()
    {
        return currentHoldingResource;
    }
    public void RemoveItemHolding(GameObject item )
    {
        if(items.Count==0){return;}
        items.Remove(item);
    }
    public void ClearAllItems()
    {
        for(int i =items.Count-1;i>=0;i--)
        {
            var item = items[i];
            items.RemoveAt(i);
            Destroy(item);
        }
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
    public void AddHoldingSize(int amount)
    {
        maxHoldingSize+=amount;
    }
    
}
