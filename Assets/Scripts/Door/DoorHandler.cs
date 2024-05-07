using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;

    [SerializeField] private Transform closeDoor1;
    [SerializeField] private Transform closeDoor2;
    [SerializeField] private Transform openDoor1;
    [SerializeField] private Transform openDoor2;

    [SerializeField] private BuyingInfo buyingInfo;
    private List<DoorOpener> doorOpeners = new List<DoorOpener>();

    public bool CanWork { get; private set; } = true;
    private void Start()
    {
        if(buyingInfo!=null)
        {
            CanWork = false;
            buyingInfo.ItemBuyed+=()=>
            {
                CanWork = true;
            };
        }
    }

    private void Update()
    {
        if (!CanWork) { return; }
        if (doorOpeners.Count > 0)
        {
            door1.transform.position = Vector3.Lerp(door1.transform.position,
                        openDoor1.transform.position, Time.deltaTime * speed);
            door2.transform.position = Vector3.Lerp(door2.transform.position,
                        openDoor2.transform.position, Time.deltaTime * speed);
        }
        else
        {
            door1.transform.position = Vector3.Lerp(door1.transform.position,
                        closeDoor1.transform.position, Time.deltaTime * speed);
            door2.transform.position = Vector3.Lerp(door2.transform.position,
                        closeDoor2.transform.position, Time.deltaTime * speed);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DoorOpener doorOpener))
        {
            doorOpeners.Add(doorOpener);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out DoorOpener doorOpener))
        {
            doorOpeners.Remove(doorOpener);
        }

    }

}
