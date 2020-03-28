using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMenuManager 
{
    List<ActionMenu> action_menu_list = new List<ActionMenu>();
    GameObject action_menu_obj;
    public GameObject ActionMenuObj { get { if (action_menu_obj == null) { action_menu_obj = GameObject.Find("ActionMenuList"); } return action_menu_obj; } }
    public void Ini()
    {
        var action_menu_obj = GameObject.Find("ActionMenuList").GetComponentsInChildren<UnityEngine.UI.Dropdown>();
        for(var index = 0; index < action_menu_obj.Length; index++)
        {
            var action_menu = new ActionMenu();
            action_menu.Menu = action_menu_obj[index];
            action_menu_list.Add(action_menu);
            action_menu.Test();
        }
    }
}
