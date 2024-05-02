using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellingPlace : MonoBehaviour
{
    private List<Seller> sellers = new List<Seller>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Seller seller))
        {
            seller.SetCurrentSellingPlace(this);
            sellers.Add(seller);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Seller seller))
        {
            seller.SetCurrentSellingPlace(null);
            sellers.Remove(seller);
        }
    }
    public bool HasSeller()
    {
        return sellers.Count>0;
    }
}
