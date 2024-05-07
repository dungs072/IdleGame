using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAppearance : MonoBehaviour
{
    [SerializeField] private List<GameObject> appearances;
    
    private void Start()
    {
        ToggleAllAppearances(false);
        int randomIndex = Random.Range(0, appearances.Count);
        appearances[randomIndex].SetActive(true);
    }
    private void ToggleAllAppearances(bool state)
    {
        foreach (var appearance in appearances)
        {
            appearance.SetActive(state);
        }
    }
}
