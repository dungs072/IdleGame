using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface IBuyable
{
    public void OnItemBuyed();

}
public class BuyableObject : MonoBehaviour, IBuyable
{
    [SerializeField] private BuyingInfo buyingInfo;
    [SerializeField] private List<GameObject> enableObjects;
    [SerializeField] private List<GameObject> disableObjects;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private string title;
    private void Start()
    {
        buyingInfo.ItemBuyed+=OnItemBuyed;
        if(titleText!=null)
        {
            titleText.text=title;
        }
    }
    public void OnItemBuyed()
    {
        ToggleEnableObjects(true);
        ToggleDisableObjects(false);
    }
    public void ToggleEnableObjects(bool state)
    {
        foreach(var obj in enableObjects)
        {
            obj.SetActive(state);
        }
    }
    public void ToggleDisableObjects(bool state)
    {
        foreach(var obj in disableObjects)
        {
            obj.SetActive(state);
        }
    }
}
