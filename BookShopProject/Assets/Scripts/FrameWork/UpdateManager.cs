using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    UpdateList update_list = new UpdateList();
    bool is_update = true;
    public UpdateList UpdateList { get { return update_list; } set { update_list = value; } }

    void Update()
    {
        Debug.Log("更新中");
        if(!is_update)
        {
            return;
        }
        foreach (var update in UpdateList.UpdateBases)
        {
            if(!is_update)
            {
                return;
            }
            update.Update();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ManageMaster.Instance.CustomerManager.Instance();
        }

    }

    public void Add(UpdateBase add, GameObject obj)
    {
        is_update = false;
        var list = UpdateList.UpdateBases;
        var list2 = new List<UpdateBase>();
        foreach(var item in list)
        {
            list2.Add(item);
        }
        add.InstanceId = obj.GetInstanceID();
        list2.Add(add);
        UpdateList.UpdateBases = list2;
        is_update = true;

    }

    public void Destory(GameObject obj)
    {
        var list = UpdateList.UpdateBases;
        var list2 = new List<UpdateBase>(list);

        foreach(var item in list)
        {
            if(obj.GetInstanceID() == item.InstanceId)
            {
                list2.Remove(item);
            }
        }
        UpdateList.UpdateBases = list2;
        MonoBehaviour.Destroy(obj);
    }
}
