using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixHolder : MonoBehaviour
{
    [SerializeField] private Holder holder;
    [SerializeField] private Transform initialPlace;
    [SerializeField] private int maxRow = 5;
    [SerializeField] private int maxCol = 5;
    [SerializeField] private float topDistance = 0.6f;
    [SerializeField] private float sideDistance = 0.6f;
    private int currentRow = 0;
    private int currentCol = 0;
    private int currentTop = 0;
    public void AddItem(GameObject item)
    {
        Vector3 position = initialPlace.position + new Vector3(currentRow, 0, currentCol) * sideDistance;
        position.y += topDistance * currentTop;
        item.transform.position = position;
        item.transform.rotation = Quaternion.identity;
        currentCol++;
        if (currentCol == maxCol)
        {
            currentRow++;
            currentCol = 0;
            if (currentRow == maxRow)
            {
                currentRow = 0;
                currentCol = 0;
                currentTop++;
            }
        }
        holder.AddItemWithoutSort(item);
    }
    public void Reset()
    {
        currentRow = 0;
        currentCol = 0;
        currentTop = 0;
    }

    public void SpawnItems(int count, GameObject prefab)
    {
        for (int i = 0; i < count; i++)
        {
            var instance = Instantiate(prefab, transform.position, Quaternion.identity);
            AddItem(instance);
        }
    }
}
