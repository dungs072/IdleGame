using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnablePlace;
    [SerializeField] private GameObject resourcePrefab;
    [SerializeField] private float resourcesSpawnTime = 2f;
    [SerializeField] private float maxResourceSpawn = 10f;
    [SerializeField] private float topDistance = 1f;
    private List<GameObject> resources = new List<GameObject>();
    private float currentSpawnTime = 0f;
    private int currentResourceAmount = 0;
    private void Update()
    {
        if (IsMaxResourceHolder()) { return; }
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
        var resourceInstance = Instantiate(resourcePrefab, spawnablePlace.position, Quaternion.identity);
        
        if (resources.Count > 0)
        {
            resourceInstance.transform.position = resources[resources.Count-1].transform.position+
                                                                    spawnablePlace.up*topDistance;
        }
        else
        {
            resourceInstance.transform.position = spawnablePlace.position+
                                                spawnablePlace.up*topDistance;
        }
        resourceInstance.transform.SetParent(spawnablePlace);
        resources.Add(resourceInstance);
    }
    public bool IsMaxResourceHolder()
    {
        return currentResourceAmount == maxResourceSpawn;
    }
}
