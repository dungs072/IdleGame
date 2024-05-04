using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyer : MonoBehaviour
{
    [SerializeField] private GameObject moneyPrefab;
    public void BuyPlace(BuyingInfo buyingInfo, MatrixHolder matrixHolder)
    {
        if(!TryGetComponent(out PlayerData playerData)){return;}
        int maxItem = playerData.CurrentMoney<buyingInfo.Price?playerData.CurrentMoney:buyingInfo.Price;
        for(int i =0;i<maxItem;i++)
        {
            var moneyInstance = Instantiate(moneyPrefab,matrixHolder.transform.position,Quaternion.identity);
            matrixHolder.AddItem(moneyInstance);
        }
        playerData.AddMoney(-maxItem);
        buyingInfo.SetPrice(buyingInfo.Price-maxItem);
    }
}
