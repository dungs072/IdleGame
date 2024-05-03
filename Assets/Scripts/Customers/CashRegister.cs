using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CashRegister : MonoBehaviour
{
    [SerializeField] private SellingPlace sellingPlace;
    [SerializeField] private Holder productHolder;
    [SerializeField] private MatrixHolder moneyHolder;
    [SerializeField] private CustomerWaitingLineManager customerManager;
    [SerializeField] private CustomerAfterOrderingManager customerAfterOrderingManager;
    private void Update()
    {
        if (!customerManager.HasCustomer()) { return; }
        if (!sellingPlace.HasSeller()) { return; }
        var table = TableManager.Instance.GetAvailableTable();
        if(table==null){return;}
        Customer customer = customerManager.GetTheFirstCustomers();
        if (customer.IsReachDestination())
        {
            if (productHolder.GetNumberItems() == 0) { return; }
            customerManager.MoveWaitingLine();
            TakeItem(customer);
        }
    }

    private void TakeItem(Customer customer)
    {
        var item = productHolder.GetLastItem();
        var itemInfo = item.GetComponent<ProductInfo>();
        SpawnMoney(itemInfo.Price,itemInfo.MoneyPrefab);
        customer.HoldItem(productHolder.GetLastItem());
        productHolder.RemoveItem(productHolder.GetLastItem());
        customerManager.RemoveCustomer(customer);
        var table = TableManager.Instance.GetAvailableTable();
        if (table == null) { return; }
        Seat seat = table.GetAvailableSeat();
        if (seat == null) { return; }
        table.SetSeatOccupied(seat);
        customer.SetDestination(seat.chair.position);
        customer.SetCurrentSeat(seat);
        customer.SetCurrentStatus(Status.GoToTable);
        customerAfterOrderingManager.AddCustomer(customer);

    }
    private void SpawnMoney(int count, GameObject prefab)
    {
        moneyHolder.SpawnItems(count,prefab);
    }
}
