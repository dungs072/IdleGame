using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfService : Service
{
    [Header("Percent price increase")]
    [Range(0.1f,1f)]
    [SerializeField] private float percentPriceIncrease = 0.2f; 
    [Header("Speed")]
    [SerializeField] private float speedIncreaseAmount = 1f;
    [SerializeField] private int speedIncreasePrice = 20;
    [Header("Stack")]
    [SerializeField] private int stackSizeIncreaseAmount = 1;
    [SerializeField] private int stackSizeIncreasePrice = 50;
    [Header("Player")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private HoldingHandler holdingHandler;
    private void Start()
    {
        UIManager.Instance.SetSpeedPriceText(speedIncreasePrice);
        UIManager.Instance.SetStackPriceText(stackSizeIncreasePrice);
    }
    public override void ToggleService(bool state)
    {
        if (state)
        {
            UIManager.Instance.ToggleSelfService(true);
        }
        else
        {
            UIManager.Instance.ToggleSelfService(false);
        }
    }
    #region Button
    public void OnIncreaseSpeed()
    {
        if (playerData.CurrentMoney < speedIncreasePrice) { return; }
        playerData.AddMoney(-speedIncreasePrice);
        playerController.AddSpeed(speedIncreaseAmount);
        speedIncreasePrice+=(int)(speedIncreasePrice*percentPriceIncrease);
        UIManager.Instance.SetSpeedPriceText(speedIncreasePrice);
    }
    public void OnIncreaseStackSize()
    {
        if (playerData.CurrentMoney < stackSizeIncreasePrice) { return; }
        playerData.AddMoney(-stackSizeIncreasePrice);
        holdingHandler.AddHoldingSize(stackSizeIncreaseAmount);
        stackSizeIncreasePrice+=(int)(stackSizeIncreasePrice*percentPriceIncrease);
        UIManager.Instance.SetStackPriceText(stackSizeIncreasePrice);
    }
    #endregion
}
