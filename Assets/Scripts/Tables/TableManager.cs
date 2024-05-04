using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    [SerializeField] private List<Table> tables;

    public static TableManager Instance { get; private set; }
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

    public Table GetAvailableTable()
    {
        foreach (Table table in tables)
        {
            if(!table.gameObject.activeSelf)
            {
                continue;
            }
            if (!table.IsFull)
            {
                return table;
            }
        }
        return null;
    }
}
