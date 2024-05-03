using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Absorber : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    public void AbsorbMoney(List<GameObject> items)
    {
        if(items.Count==0){return;}
        StartCoroutine(AbsorbMoneyAround(items));
    }   
    private IEnumerator AbsorbMoneyAround(List<GameObject> items)
    {
        while(items.Count>0)
        {

            for(int i = items.Count-1; i >= 0;i--)
            {
                Vector3 targetPosition = transform.position;
                Vector3 direction = (targetPosition-items[i].transform.position).normalized;
                items[i].transform.rotation = Quaternion.LookRotation(direction);
                items[i].transform.position+= items[i].transform.forward * speed * Time.deltaTime;
                if(IsNearTarget(items[i].transform.position,targetPosition))
                {
                    GetComponent<PlayerData>().AddMoney(1);
                    var item = items[i];
                    items.RemoveAt(i);
                    Destroy(item);
                }
            }

            yield return null;
        }
    }
    private bool IsNearTarget(Vector3 position, Vector3 targetPosition)
    {
        return (targetPosition-position).sqrMagnitude <= 1f;
    }
}
