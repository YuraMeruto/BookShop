using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductManager
{
    List<Product> product_list = new List<Product>();
    public List<Product> ProductList { get { return product_list; } }
    GameObject content;
    GameObject product_detail;
    Text product_price;
    Text product_data;
    Text product_title;
    Text product_quanity;
    public Text ProductQuanity { get { return product_quanity; } set { product_quanity = value; } }
    GameObject product_list_scroll_view;
    public GameObject ProductListScrollView { get { return product_list_scroll_view; } set { product_list_scroll_view = value; } }
    public Text ProductPrice { get { return product_price; } set { product_price = value; } }
    public Text ProductTitle { get { return product_title; } set { product_title = value; } }
    public Text ProductData { get { return product_data; } set { product_data = value; } }
    public GameObject ProductDetail { get {if( product_detail == null) ProductDetailSetting(); return product_detail; } set { product_detail = value; } }
    public enum Status
    {
        None,
        Manga,
        Nobel,
    }


    void ProductDetailSetting()
    {
        product_detail = GameObject.Find("ProductDetail");
        var children = product_detail.GetComponentsInChildren<Text>();
        foreach (var child in children)
        {
            if (child.gameObject.name == "ProductData")
            {
                product_data = child;
            }
            else if (child.gameObject.name == "ProductPrice")
            {
                product_price = child;
            }

            else if (child.gameObject.name == "ProductTitle")
            {
                product_title = child;
            }

            else if (child.gameObject.name == "ProductQuanity")
            {
                product_quanity = child;
            }
        }
    }

    public void Instance()
    {
        if (product_list_scroll_view == null)
        {
            product_list_scroll_view = GameObject.Find("ProductListScrollView");
        }
        if (product_detail == null)
        {
            product_detail = GameObject.Find("ProductDetail");
            var children = product_detail.GetComponentsInChildren<Text>();
            foreach(var child in children)
            {
                if(child.gameObject.name == "ProductData")
                {
                    product_data = child;
                }
                else if (child.gameObject.name == "ProductPrice")
                {
                    product_price = child;
                }

                else if (child.gameObject.name == "ProductTitle")
                {
                    product_title = child;
                }

                else if (child.gameObject.name == "ProductQuanity")
                {
                    product_quanity = child;
                }
            }
            content = GameObject.Find("ProductList");
            ProductInstance();
        }
    }

    void ProductInstance()
    {
        var ran = Random.Range(3,5);
        var obj = Resources.Load<GameObject>("Product");

        for (var index = 0; ran > index; index++)
        {
            var instance = MonoBehaviour.Instantiate(obj);
            instance.transform.parent = content.transform;
            var ran_type = Random.Range(0,5);
            Status status = Status.None;
            switch (ran_type)
            {
                case 0:
                case 5:
                    status = Status.Nobel;
                    break;
                case 1:
                case 3:
                case 4:
                    status = Status.Manga;
                    break;
                case 2:
                    status = Status.None;
                    break;
            }
            ProductSetting(instance.GetComponent<Button>(),status);
        }
    }

    public void SetActive(bool is_active)
    {
        product_detail.SetActive(is_active);
    }

    public void ProductListSetactive(bool is_active)
    {
        if (product_list_scroll_view == null)
        {
            product_list_scroll_view = GameObject.Find("ProductListScrollView");
        }
        product_list_scroll_view.SetActive(is_active);
    }

    void ProductSetting(Button obj,Status status)
    {
        var product = new Product();
        product.ProductSetting(status,obj);
    }
}
