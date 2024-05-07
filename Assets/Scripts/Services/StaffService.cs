using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffService : Service
{
    [Header("Percent price increase")]
    [Range(0.1f, 1f)]
    [SerializeField] private float percentPriceIncrease = 0.2f;
    [Header("Speed")]
    [SerializeField] private float speedIncreaseAmount = 1f;
    [SerializeField] private int speedIncreasePrice = 20;
    [Header("Stack")]
    [SerializeField] private int stackSizeIncreasePrice = 50;
    [Header("Hiring waiter")]
    [SerializeField] private int hiringStaffWaiterPrice = 50;
    [Header("Hiring cashier")]
    [SerializeField] private int hiringStaffCashierPrice = 50;
    [Header("Player")]
    [SerializeField] private PlayerData playerData;
    [Header("Staff")]
    [SerializeField] private StaffManager staffManager;
    private void Start()
    {
        UIManager.Instance.SetStaffSpeedPriceText(speedIncreasePrice);
        UIManager.Instance.SetStaffStackPriceText(stackSizeIncreasePrice);
        UIManager.Instance.SetStaffWaiterHiringPriceText(stackSizeIncreasePrice);
    }
    public override void ToggleService(bool state)
    {
        if (state)
        {
            UIManager.Instance.ToggleStaffService(true);
        }
        else
        {
            UIManager.Instance.ToggleStaffService(false);
        }
    }
    #region Button
    public void OnStaffIncreaseSpeed()
    {
        if (playerData.CurrentMoney < speedIncreasePrice) { return; }
        playerData.AddMoney(-speedIncreasePrice);
        staffManager.AddSpeedToStaff(speedIncreaseAmount);
        speedIncreasePrice += (int)(speedIncreasePrice * percentPriceIncrease);
        UIManager.Instance.SetStaffSpeedPriceText(speedIncreasePrice);
    }
    public void OnStaffIncreaseStackSize()
    {
        if (playerData.CurrentMoney < stackSizeIncreasePrice) { return; }
        playerData.AddMoney(-stackSizeIncreasePrice);
        staffManager.IncreaseStackSize(1);
        stackSizeIncreasePrice += (int)(stackSizeIncreasePrice * percentPriceIncrease);
        UIManager.Instance.SetStaffStackPriceText(stackSizeIncreasePrice);
    }
    public void OnStaffWaiterBought()
    {
        if (playerData.CurrentMoney < hiringStaffWaiterPrice) { return; }
        playerData.AddMoney(-hiringStaffWaiterPrice);

        staffManager.SpawnStaff(TaskType.Waiter);

        hiringStaffWaiterPrice += (int)(hiringStaffWaiterPrice * percentPriceIncrease);
        UIManager.Instance.SetStaffWaiterHiringPriceText(hiringStaffWaiterPrice);
    }
    public void OnStaffCashierBought()
    {
        if (playerData.CurrentMoney < hiringStaffCashierPrice) { return; }
        playerData.AddMoney(-hiringStaffCashierPrice);
        staffManager.SpawnStaff(TaskType.CashRegister);
        hiringStaffCashierPrice += (int)(hiringStaffCashierPrice * percentPriceIncrease);
        UIManager.Instance.SetStaffWaiterHiringPriceText(hiringStaffCashierPrice);
    }
    #endregion
}
