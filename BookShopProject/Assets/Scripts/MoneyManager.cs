using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager
{
    Product target = new Product();
    public Product Target { get { return target; } set { target = value; } }
    public bool CheckBuyPrice()
    {
        Debug.Log(target.TitleData);
        Debug.Log("お金"+StaticDatas.Instance.Money.MoneyValue.ToString() + "値段" + target.Price);
        var money = StaticDatas.Instance.Money.MoneyValue;
        if (money - target.Price >= 0)
        {
            return true;
        }
        return false;
    }
}
