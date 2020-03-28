using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager
{
    List<Customer> customer_list = new List<Customer>();
    public void Instance()
    {
        var obj = Resources.Load<GameObject>("Customer");
        for (var index = 0; index < 2; index++)
        {
            var ran = Random.Range(0,3);
            var instance = MonoBehaviour.Instantiate(obj);
            Customer customer = new Customer();
            customer.Ini( Customer.Rare.Normal,instance);
            customer_list.Add(customer);
            ManageMaster.Instance.UpdateManager.Add(customer,instance);
            var pos = StaticDatas.Instance.CustomerInstancePos;
            pos.x += 2;
            instance.transform.position = pos;
            instance.transform.parent = StaticDatas.Instance.CunstomerParent.transform;
        }
    }

    public void Destory(Customer customer,GameObject obj)
    {
        var index = 0;
        foreach(var data in customer_list)
        {
            if(data.InstanceId == customer.InstanceId)
            {
                break;
            }
            index++;
        }
        customer_list.RemoveAt(index);
        if(customer_list.Count == 0)
        {
           var day_of_week = StaticDatas.Instance.Timer.NextDay();
            if(day_of_week == Timer.DayOfWeek.Sat)
            {
                MeetingSetting();
            }
            else
            {
                Instance();
            }
        }
        ManageMaster.Instance.UpdateManager.Destory(obj);
    }

    void MeetingSetting()
    {
        StaticDatas.Instance.NowFhase = StaticDatas.Fhase.Meeting;
        StaticDatas.Instance.OpenShopButton.Obj.SetActive(true);
    }
}
