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
    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        if(Instance==null)
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
        moneyText.text = number.ToString();
    }
    public void SetExpText(int number)
    {
        expText.text = number.ToString();
    }
    public void SetLevelText(int number)    
    {
        levelText.text = "Level "+ number.ToString()+": ";
    }
    #endregion

}
