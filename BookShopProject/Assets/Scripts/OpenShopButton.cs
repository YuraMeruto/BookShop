using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OpenShopButton
{
    GameObject obj;
    public GameObject Obj { get { return obj; } }
    public void Ini()
    {
        obj = GameObject.Find("OpenShopButton");
        obj.GetComponent<Button>().onClick.AddListener(OpenShop);
    }

    public void OpenShop()
    {
        ManageMaster.Instance.CustomerManager.Instance();
        CloseUI();
        StaticDatas.Instance.NowFhase = StaticDatas.Fhase.Sales;
        StaticDatas.Instance.Timer.NextDay();
        obj.SetActive(false);
    }

    void CloseUI()
    {
        ManageMaster.Instance.ProductManager.ProductListScrollView.SetActive(false);
        ManageMaster.Instance.ProductManager.SetActive(false);
        ManageMaster.Instance.ActionMenuManager.ActionMenuObj.SetActive(false);

    }
}
