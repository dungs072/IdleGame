using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{

    [SerializeField] private Holder holdingPlace;
    [SerializeField] private GameObject resourcePrefab;
    [SerializeField] private float resourcesSpawnTime = 2f;



    private float currentSpawnTime = 0f;

    private void Update()
    {
        if (holdingPlace.IsMaxSize()) { return; }
        if (currentSpawnTime >= resourcesSpawnTime)
        {
            currentSpawnTime = 0f;
            SpawnResources();
        }
        else
        {
            currentSpawnTime += Time.deltaTime;
        }
    }
    private void SpawnResources()
    {
        var resourceInstance = Instantiate(resourcePrefab, holdingPlace.transform.position, Quaternion.identity);
        
        resourceInstance.transform.SetParent(holdingPlace.transform);
        holdingPlace.AddItem(resourceInstance);
    }

}
