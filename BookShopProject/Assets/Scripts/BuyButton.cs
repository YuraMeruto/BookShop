using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton
{
    Button button;
    bool is_ini = true;
    public Button Button{ get { return button; } set { button = value; } }
    public void Ini()
    {
        Debug.Log("test");
        button = GameObject.Find("BuyButton").GetComponent<Button>();
        bool ret = ManageMaster.Instance.MoneyManager.CheckBuyPrice();
        button.interactable = ret;
        Debug.Log(ret);
        if (is_ini)
        {
            is_ini = false;
            button.onClick.AddListener(BuyProduct);
        }
    }

    public void UpdateBuyDataTarget()
    {
        if(button == null)
        {
            button = GameObject.Find("BuyButton").GetComponent<Button>();
        }
        if (StaticDatas.Instance.TargetBookshelf.Quantity != 0)
        {
            button.interactable = false;
            return;
        }
        bool ret = ManageMaster.Instance.MoneyManager.CheckBuyPrice();
        button.interactable = ret;
    }

    public void UpdateBuyButtonInteractable(bool is_interactable)
    {
        button.interactable = is_interactable;
    }

    public void BuyProduct()
    {
        if (StaticDatas.Instance.TargetBookshelf.Quantity != 0)
        {
            return;
        }
        StaticDatas.Instance.Money.MoneyValue = StaticDatas.Instance.Money.MoneyValue - ManageMaster.Instance.MoneyManager.Target.Price;
        StaticDatas.Instance.TargetBookshelf.UpdateText(ManageMaster.Instance.MoneyManager.Target.TitleData, ManageMaster.Instance.MoneyManager.Target);
        ManageMaster.Instance.ProductManager.SetActive(false);
        ManageMaster.Instance.ProductManager.ProductListScrollView.SetActive(false);
    }
}
