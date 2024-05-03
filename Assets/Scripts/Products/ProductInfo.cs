using UnityEngine;

public class ProductInfo : MonoBehaviour
{
    [field:SerializeField] public Resource Resource{get;private set;} 
    [field:SerializeField] public int Price{get;private set;}
    [field:SerializeField] public GameObject MoneyPrefab{get;private set;}
}
