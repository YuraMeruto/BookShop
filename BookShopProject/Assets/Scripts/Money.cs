using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money
{
    Text text;
    int money_value = 99999;
    public int MoneyValue { get { return money_value; } set { money_value = value; text.text = money_value.ToString() + "￥"; } }
    public Text Text { get { return text; } set { text = value; } }

    public void Ini()
    {
        text = GameObject.Find("Money").GetComponent<Text>();
        text.text = money_value.ToString() + "￥";
    }
}
