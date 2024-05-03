using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status
{
    GoToRestaurant,
    WaitingLine,
    OrderFood,
    GoToTable,
    OnTable,
    Finish
}

[RequireComponent(typeof(AIController))]
public class Customer : MonoBehaviour
{
    [SerializeField] private int tipMoneyTimes = 2;
    [SerializeField] private float topDistance = 0.2f;
    [SerializeField] private float eatingTime = 5f;
    [SerializeField] private Transform holdingPlace;
    [SerializeField] private AIController aIController;
    [SerializeField] private GameObject trashPrefab;
    [SerializeField] private GameObject moneyPrefab;

    private List<GameObject> items = new List<GameObject>();
    private Status currentStatus = Status.GoToRestaurant;
    private Seat currentSeat;
    private Transform exitPlace;

    public void HandleOnTable()
    {
        Vector3 foodPlace = currentSeat.foodPlace.position;
        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.SetParent(currentSeat.foodPlace);
            items[i].transform.position = foodPlace + currentSeat.foodPlace.up * topDistance;
        }

        StartCoroutine(HandleOnTableCoroutine());
    }
    private IEnumerator HandleOnTableCoroutine()
    {
        yield return new WaitForSeconds(.5f);
        Vector3 foodPlace = currentSeat.foodPlace.position;
        Vector3 direction = (foodPlace - transform.position).normalized;
        direction.y = 0f;
        transform.rotation = Quaternion.LookRotation(direction);
        yield return new WaitForSeconds(eatingTime);
        // finish eating
        TipMoney();
        PutTrashOnTable();
        currentStatus = Status.Finish;
        SetDestination(exitPlace.position);

    }
    private void TipMoney()
    {
        for(int i =0;i<items.Count*tipMoneyTimes;i++)
        {
            var moneyInstance = Instantiate(moneyPrefab,currentSeat.MoneyHolder.transform.position,Quaternion.identity);
            currentSeat.MoneyHolder.AddItem(moneyInstance);
        }
    }
    private void PutTrashOnTable()
    {
        int count = items.Count;
        ClearAllItems();
        for(int i =0;i<count;i++)
        {
            var trashInstance = Instantiate(trashPrefab,currentSeat.foodPlace.position,Quaternion.identity);
            var holder = currentSeat.foodPlace.GetComponent<Holder>();
            holder.AddItem(trashInstance);
        }
    }

    private void ClearAllItems()
    {
        for (int i = items.Count - 1; i >= 0; i--)
        {
            var item = items[i];
            items.RemoveAt(i);
            Destroy(item);
        }
    }

    public Seat GetCurrentSeat()
    {
        return currentSeat;
    }
    public Status GetCurrentStatus()
    {
        return currentStatus;
    }
    public void SetCurrentSeat(Seat seat)
    {
        currentSeat = seat;
    }
    public void SetCurrentStatus(Status status)
    {
        currentStatus = status;
    }
    public void SetExitPlace(Transform exitPlace)
    {
        this.exitPlace = exitPlace;
    }
    public void HoldItem(GameObject item)
    {
        items.Add(item);
        item.transform.position = holdingPlace.position;
        item.transform.rotation = Quaternion.identity;
        item.transform.SetParent(holdingPlace);
    }
    public bool IsReachDestination()
    {
        return aIController.IsReachDestination();
    }
    public void SetDestination(Vector3 position)
    {
        aIController.SetDestination(position);
    }
    public Vector3 GetDestination()
    {
        return aIController.GetDestination();
    }
}
