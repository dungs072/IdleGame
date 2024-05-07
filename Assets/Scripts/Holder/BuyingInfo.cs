using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class BuyingInfo : MonoBehaviour
{
    public event Action ItemBuyed;
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public MatrixHolder MatrixHolder { get; private set; }
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private string nameItem;
    
    private void Start()
    {
        displayText.text = nameItem+"\n"+"Price: "+Price.ToString()+"$";
    }

    public void SetPrice(int price)
    {
        Price = price;
        if (Price == 0)
        {
            ItemBuyed?.Invoke();
        }

    }

}
