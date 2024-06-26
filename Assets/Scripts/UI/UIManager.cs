using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [Header("Player Info")]
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text expText;
    [SerializeField] private TMP_Text levelText;
    [Header("Services")]
    [SerializeField] private GameObject selfServicePage;
    [SerializeField] private TMP_Text speedPriceText;
    [SerializeField] private TMP_Text stackPriceText;
    //staff
    [SerializeField] private GameObject staffServicePage;
    [SerializeField] private TMP_Text staffSpeedPriceText;
    [SerializeField] private TMP_Text staffStackPriceText;
    [SerializeField] private TMP_Text staffWaiterHiringText;
    [SerializeField] private TMP_Text staffCashierHiringText;
    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }
    }

    #region InGame
    public void SetMoneyText(int number)
    {
        moneyText.text = number.ToString() + "$";
    }
    public void SetExpText(int number)
    {
        expText.text = number.ToString();
    }
    public void SetLevelText(int number)
    {
        levelText.text = "Level " + number.ToString() + ": ";
    }

    // services
    public void ToggleSelfService(bool state)
    {
        selfServicePage.SetActive(state);
    }

    public void SetSpeedPriceText(int number)
    {
        speedPriceText.text = "Price: " + number.ToString() + "$";
    }
    public void SetStackPriceText(int number)
    {
        stackPriceText.text = "Price: " + number.ToString() + "$";
    }
    // staff
    public void ToggleStaffService(bool state)
    {
        staffServicePage.SetActive(state);
    }

    public void SetStaffSpeedPriceText(int number)
    {
        staffSpeedPriceText.text = "Price: " + number.ToString() + "$";
    }
    public void SetStaffStackPriceText(int number)
    {
        staffStackPriceText.text = "Price: " + number.ToString() + "$";
    }
    public void SetStaffWaiterHiringPriceText(int number)
    {
        staffWaiterHiringText.text = "Price: " + number.ToString() + "$";
    }
    public void SetStaffCashierHiringPriceText(int number)
    {
        staffCashierHiringText.text = "Price: " + number.ToString() + "$";
    }

    #endregion

}
