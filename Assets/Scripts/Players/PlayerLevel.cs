using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private int expoEXPToLevel = 10;
    [SerializeField] private PlayerData playerData;
    private int currentLevel;
    private int expPerLevel;
    private void Start()
    {
        currentLevel = 1;
        expPerLevel = expoEXPToLevel;
        playerData.ChangedExp+=OnChangedExp;
    }
    public void OnChangedExp()
    {
        if(playerData.CurrentExp>=expPerLevel)
        {
            currentLevel++;
            UIManager.Instance.SetLevelText(currentLevel);
            expPerLevel += currentLevel*expoEXPToLevel;
        }   
    }
}
