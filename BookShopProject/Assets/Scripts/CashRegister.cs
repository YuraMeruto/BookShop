using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashRegister
{
    GameObject obj;
    public GameObject Obj { get { return obj; } set { obj = value; } }

    public void Sell(Customer customer)
    {
        if(customer.BuyProductList.Count == 0)
        {
            return;
        }
        var sum_price = 0;
        foreach(var product in customer.BuyProductList)
        {
            sum_price += product;
        }
        StaticDatas.Instance.Money.MoneyValue += sum_price;
    }
}
