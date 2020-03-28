using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bookshelf
{
    Button button;
    int quantity;
    public int Quantity { get { return quantity; } set { quantity = value; if (quantity == 0) { buy_product = null; } } }
    public Button Button { get { return button; } set { button = value; text = button.GetComponentInChildren<Text>(); button.onClick.AddListener(delegate { CheckAction(); }); } }
    public Product Produt { get { return buy_product; } }
    Text text;
    Product buy_product;
    GameObject obj;
    public GameObject Obj { get { return obj; } set { obj = value; } }
    public void CheckAction()
    {
        StaticDatas.Instance.TargetBookshelf = this;
        switch(StaticDatas.Instance.NowFhase)
        {
            case StaticDatas.Fhase.Meeting:
                ManageMaster.Instance.ProductManager.ProductListSetactive(true);
                ManageMaster.Instance.ProductManager.ProductDetail.SetActive(true);
                break;
            case StaticDatas.Fhase.Sales:
                ManageMaster.Instance.ProductManager.ProductDetail.SetActive(true);
                StaticDatas.Instance.BuyButton.Button.gameObject.SetActive(false);
                ManageMaster.Instance.ProductManager.ProductListScrollView.SetActive(false);
                ManageMaster.Instance.ProductManager.ProductQuanity.text = buy_product.Quantity.ToString();
                Produt.UpdateProductDetail();
                break;
        }
    }
    public void UpdateText(string data, Product product)
    {
        Debug.Log(product.Status);
        text.text = data;
        if (product != null)
        {
            buy_product = new Product();
            buy_product.ResetProductDetail(product);
            quantity = product.Quantity;
            StaticDatas.Instance.BuyButton.UpdateBuyButtonInteractable(false);
           
            return;
        }
        buy_product = null;
    }

}
