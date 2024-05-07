using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerData : MonoBehaviour
{
    public event Action ChangedExp;
    public int CurrentMoney { get { return currentMoney; } }
    public int CurrentExp { get { return currentExp; } }
    private int currentExp;
    private int currentMoney;
    private void Start()
    {
        SetCurrentExp(0);
        SetCurrentMoney(0);
    }
    public void AddExp(int amount)
    {
        currentExp+=amount;
        UIManager.Instance.SetExpText(currentExp);
        ChangedExp?.Invoke();
    }
    public void AddMoney(int amount)
    {
        currentMoney+=amount;
        UIManager.Instance.SetMoneyText(currentMoney);
    }
    public void SetCurrentExp(int exp)
    {
        currentExp = exp;
        UIManager.Instance.SetExpText(currentExp);
        ChangedExp?.Invoke();
    }
    public void SetCurrentMoney(int money)
    {
        currentMoney = money;
        UIManager.Instance.SetMoneyText(currentMoney);
    }

    
}
