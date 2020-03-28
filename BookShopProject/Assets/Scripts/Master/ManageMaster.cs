using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMaster
{
    static ManageMaster instance = null;

    UpdateManager update_manager;
    ActionMenuManager action_menu_manager = new ActionMenuManager();
    BookshelfManager book_shelf_manager = new BookshelfManager();
    ProductManager product_manager = new ProductManager();
    MoneyManager money_manager = new MoneyManager();
    CustomerManager customer_manager = new CustomerManager();

    public static ManageMaster Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new ManageMaster();
            }
            return instance;
        }
    }

    public UpdateManager UpdateManager { get {
            if(update_manager == null)
            {
                var obj = new GameObject("UpdateManager");
               update_manager = obj.AddComponent<UpdateManager>();
            }
            return update_manager; } }

    public ActionMenuManager ActionMenuManager { get { return action_menu_manager; } }
    public BookshelfManager BookshelfManager { get { return book_shelf_manager; } }
    public ProductManager ProductManager { get {return  product_manager;} }
    public MoneyManager MoneyManager { get { return money_manager; } }
    public CustomerManager CustomerManager { get { return customer_manager; } }

    public void Ini()
    {
        var ini = new IniAction();
        ini.Ini();
    }
}
