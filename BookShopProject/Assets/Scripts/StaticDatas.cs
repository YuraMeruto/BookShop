using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticDatas
{
    static StaticDatas instance = null;
    public static StaticDatas Instance
    {
        get { if (instance == null) { instance = new StaticDatas(); } return instance; }
    }
    float world_speed = 1.0f;
    Money money;
    CashRegister cash_register;
    BuyButton buy_button;
    Bookshelf target_book_shelf;
    Vector3 customer_instance_pos = Vector3.zero;
    public enum Fhase
    {
        None,
        Sales,
        Meeting,
    }

    Timer timer;

    public Timer Timer { get { if (timer == null) { timer = new Timer(); timer.Ini(); } return timer; } set { timer = value; } }
    Fhase fhase = Fhase.Meeting;
    OpenShopButton open_shop_button;
    public OpenShopButton OpenShopButton { get { if (open_shop_button == null) { open_shop_button = new OpenShopButton();} return open_shop_button; } }
    GameObject customer_parent;
    public Bookshelf TargetBookshelf { get { return target_book_shelf; } set { target_book_shelf = value; } }
    public Fhase NowFhase { get { return fhase; } set { fhase = value; } }
    public Money Money { get { if (money == null) money = new Money(); return money; } }
    public BuyButton BuyButton
    {
        get
        {
            if (buy_button == null)
            {
                buy_button = new BuyButton();
                buy_button.Ini();
            }
            return buy_button;
        }
    }

    public CashRegister CashRegister { get { if (cash_register == null) { var obj = GameObject.Find("CashRegister"); cash_register = new CashRegister(); cash_register.Obj = obj; } return cash_register; } }
    public GameObject CunstomerParent { get { if (customer_parent == null) { customer_parent = GameObject.Find("CustomerParent"); } return customer_parent; } set { } }
    public float WorldSpeed { get { return world_speed; } set { world_speed = value; } }
    public Vector3 CustomerInstancePos { get { if (customer_instance_pos == Vector3.zero) { customer_instance_pos = GameObject.Find("CustomerInstancePos").transform.position; } return customer_instance_pos; } }
}
