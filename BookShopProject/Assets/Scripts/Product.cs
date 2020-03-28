using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Product
{
    int quanity;//品数
    int price;
    Button button;
    ProductManager.Status status;
    int simple_price = 0 ;
    public Button Button { get { return button; } set { button = value; } }
    public int Quantity { get { return quanity; }set { quanity = value; } }
    public int Price { get { return price; } set { price = value; } }
    public int SimplePrice { get { return simple_price; } set { simple_price = value; } }
    string title_data;
    public string TitleData { get { return title_data; } }
    public ProductManager.Status Status { get { return status; } }

    public void ProductSetting(ProductManager.Status _status, Button obj)
    {
        button = obj;
        status = _status;
        button.onClick.AddListener(UpdateProductDetail);

        var text = button.GetComponentInChildren<Text>();
        Debug.Log(text);
        switch (status)
        {
            case ProductManager.Status.Nobel:
                text.text = ConstValues.PRODUCT_NOBEL_TITLE;
                break;
            case ProductManager.Status.None:
                text.text = "テスト";
                title_data = "テスト";
                break;
            case ProductManager.Status.Manga:
                text.text = "漫画";
                break;
        }
        title_data = text.text;
    }

    public void UpdateProductDetail()
    {

        switch(status)
        {
            case ProductManager.Status.None:
                ManageMaster.Instance.ProductManager.ProductData.text = "テスト";
                ManageMaster.Instance.ProductManager.ProductPrice.text = "テスト";
                ManageMaster.Instance.ProductManager.ProductTitle.text = "テスト";
                quanity = 9999;
                price = 0;
                simple_price = price / quanity;
                break;
            case ProductManager.Status.Nobel:
                ManageMaster.Instance.ProductManager.ProductData.text = ConstValues.PRODUCT_NOBEL_DATA;
                ManageMaster.Instance.ProductManager.ProductPrice.text = ConstValues.PRODUCT_NOBEL_PRICE_TEXT;
                ManageMaster.Instance.ProductManager.ProductTitle.text = ConstValues.PRODUCT_NOBEL_TITLE;
                quanity = ConstValues.PRODUCT_NOBEL_QUANITY;
                price = ConstValues.PRODUCT_NOBEL_PRICE;
                simple_price = price / quanity;
                break;
            case ProductManager.Status.Manga:
                ManageMaster.Instance.ProductManager.ProductData.text = ConstValues.PRODUCT_MANGA_DATA;
                ManageMaster.Instance.ProductManager.ProductPrice.text = ConstValues.PRODUCT_MANGA_TEXT;
                ManageMaster.Instance.ProductManager.ProductTitle.text = ConstValues.PRODUCT_MANGA_TITLE;
                quanity = ConstValues.PRODUCT_MANGA_QUANITY;
                price = ConstValues.PRODUCT_MANGA_PRICE;
                simple_price = price / quanity;
                break;
        }
        ManageMaster.Instance.MoneyManager.Target = this;
        StaticDatas.Instance.BuyButton.UpdateBuyDataTarget();
    }

    public void ResetProductDetail(Product _product)
    {
        status = _product.status;
        price = _product.price;
        quanity = _product.quanity;
        title_data = _product.title_data;
    }

}
