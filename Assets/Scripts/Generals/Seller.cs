using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    
    private SellingPlace currentSellingPlace;
    public void SetCurrentSellingPlace(SellingPlace place)
    {
        currentSellingPlace = place;
    }
    public SellingPlace GetSellingPlace()
    {
        return currentSellingPlace; 
    }
}
