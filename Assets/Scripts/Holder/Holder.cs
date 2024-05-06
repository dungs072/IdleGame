using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum Resource
{
    Product,
    Money,
    Garbage
}
public class Holder : MonoBehaviour
{
    public event Action OnTookGarbage;
    public event Action TaskFinished;
    [SerializeField] private Resource resourceType;
    [SerializeField] private bool canTake = true;
    [SerializeField] private float maxItemCanHold = 10f;
    [SerializeField] private float topDistance = 1f;
    [SerializeField] private Transform holderPositionForAI;
    private List<GameObject> items = new List<GameObject>();
    public Transform HolderPositionForAI=>holderPositionForAI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Staff staff) && canTake)// check if staff pass the holder
        {
            if (staff.CurrentTask.Holder.transform != transform)
            {
                return;
            }
        }
        if (other.TryGetComponent(out HoldingHandler holdingHandler))
        {
            if (canTake)
            {
                TakeItem(holdingHandler);
            }
            else
            {
                PutItem(holdingHandler);
            }
        }
    }
    private void PutItem(HoldingHandler holdingHandler)
    {
        if (TryGetComponent(out BuyingInfo buyingInfo))
        {
            if (holdingHandler.TryGetComponent(out Buyer buyer))
            {
                buyer.BuyPlace(buyingInfo, buyingInfo.MatrixHolder);
            }
        }
        else
        {
            if (maxItemCanHold != -1 && items.Count >= maxItemCanHold) { return; }
            if (holdingHandler.GetCurrentResourceType() == Resource.Product)
            {
                int count = holdingHandler.GetItemAmount();
                for (int i = 0; i < count; i++)
                {
                    GameObject item = holdingHandler.GetLastItem();
                    AddItem(item);
                    holdingHandler.RemoveItemHolding(item);

                }
            }
            else if (holdingHandler.GetCurrentResourceType() == Resource.Garbage)
            {
                holdingHandler.ClearAllItems();
            }
        }
    }

    private void TakeItem(HoldingHandler holdingHandler)
    {
        if (items.Count == 0) { return; }
        if (resourceType == Resource.Product)
        {
            TakeProduct(holdingHandler);
        }
        else if (resourceType == Resource.Money)
        {
            TakeMoney(holdingHandler);
        }
        else if (resourceType == Resource.Garbage)
        {
            TakeProduct(holdingHandler);
            OnTookGarbage?.Invoke();

        }
        if (items.Count == 0&&holdingHandler.TryGetComponent(out PlayerData t))
        {
            TaskFinished?.Invoke();
        }
    }
    private void TakeMoney(HoldingHandler holdingHandler)
    {
        //if(!holdingHandler.CompareTag("Player")){return;}
        if (holdingHandler.TryGetComponent(out Absorber absorber))
        {
            absorber.AbsorbMoney(items);
        }
        // HAIZZ
        GetComponent<MatrixHolder>().Reset();
    }



    private void TakeProduct(HoldingHandler holdingHandler)
    {
        for (int i = items.Count - 1; i >= 0; i--)
        {
            if (holdingHandler.IsMaxSize()) { break; }
            holdingHandler.AddItemToHold(items[i]);
            holdingHandler.SetCurrentHoldingResource(resourceType);
            items.RemoveAt(i);
        }
    }

    public void AddItem(GameObject item)
    {
        if (items.Count > 0)
        {
            item.transform.position = GetLastItem().transform.position +
                                    transform.up * topDistance;
        }
        else
        {
            item.transform.position = transform.position +
                                transform.up * topDistance;
        }
        item.transform.SetParent(transform);
        item.transform.rotation = Quaternion.identity;
        items.Add(item);
    }
    public void AddItemWithoutSort(GameObject item)
    {
        item.transform.SetParent(transform);
        items.Add(item);
    }
    public void RemoveItem(GameObject item)
    {
        if (items.Count == 0) { return; }
        items.Remove(item);
    }
    public GameObject GetLastItem()
    {
        if(items.Count==0){return null;}
        return items[items.Count - 1];
    }
    public int GetNumberItems()
    {
        return items.Count;
    }
    public bool IsMaxSize()
    {
        return items.Count == maxItemCanHold;
    }
}

