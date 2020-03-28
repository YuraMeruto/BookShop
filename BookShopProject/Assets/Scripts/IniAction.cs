using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniAction
{
    public void Ini()
    {
        Player();
        Timer();
        UIValue();
    }

    void Player()
    {
        var player = new PlayerControl();
        var obj = new GameObject("Player");
        player.Object = obj;
        ManageMaster.Instance.UpdateManager.Add(player, player.Object);
    }

    void Timer()
    {
        StaticDatas.Instance.Timer.IsUpdate = true;
    }

    void MenuAction()
    {
        ManageMaster.Instance.ActionMenuManager.Ini();
    }

    void Money()
    {
        StaticDatas.Instance.Money.Ini();
    }

    void UIValue()
    {
        MenuAction();
        Money();
        Bookshelf();
        ManageMaster.Instance.ProductManager.Instance();
        ManageMaster.Instance.ProductManager.ProductListSetactive(false);
        StaticDatas.Instance.OpenShopButton.Ini();
    }

    void Bookshelf()
    {
        ManageMaster.Instance.BookshelfManager.Ini();
    }
}
