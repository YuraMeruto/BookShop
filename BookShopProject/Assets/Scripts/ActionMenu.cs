using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenu
{
    public enum Status
    {
        None,
        Clean,//掃除s
        Sleep,//休憩
        ChangeAction,//宣伝

    }
    Dropdown menu;
    Status status;

    public Dropdown Menu { get { return menu; } set { menu = value;menu.onValueChanged.AddListener( delegate { ChangeAction(); });} }

    public void Test()
    {
//        AddAction( Status.ChangeAction);
    }

    public void AddAction(Status _add)
    {
        List<string> list = new List<string>();
        foreach (var data in menu.options)
        {
          var st =  data.text;
            list.Add(st);
        }
        var add_data = _add.ToString();
        list.Add(add_data);
        menu.ClearOptions();
        menu.AddOptions(list);
        Debug.Log("hoge");
    }

    void ChangeAction()
    {
        switch (menu.value)
        {
            case 0:
                status = Status.None;
                break;
            case 1:
                status = Status.Clean;
                break;
            case 2:
                status = Status.Sleep;
                break;
        }
        Debug.Log(status);
    }
}
