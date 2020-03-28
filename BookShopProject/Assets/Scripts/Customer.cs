using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Customer : UpdateBase
{
    public enum Rare
    {
        Normal,
        Rare,
        SRare,
    }

    NavMeshAgent agent;

    Rare rare = Rare.Normal;
    Vector3 target_pos;
    enum Status
    {
      None,  Buy,Finish,Destroy,
    }
    Status status = Status.None;
    int instance_id;
    List<int> buy_produtlist = new List<int>();

    public List<int> BuyProductList { get { return buy_produtlist; } }

    public void Ini(Rare _rare,GameObject obj)
    {
        rare = _rare;
        agent = obj.GetComponent<NavMeshAgent>();
        var ran = Random.Range(0,ManageMaster.Instance.BookshelfManager.Bookshelves.Count );
        target_pos = ManageMaster.Instance.BookshelfManager.Bookshelves[ran].Obj.transform.position;
        if (ManageMaster.Instance.BookshelfManager.Bookshelves[ran].Produt == null)
        {
            status = Status.Destroy;
            target_pos = StaticDatas.Instance.CustomerInstancePos;
        }
        instance_id = ManageMaster.Instance.BookshelfManager.Bookshelves[ran].Obj.GetInstanceID();
    }

    public override void Update()
    {
       agent.destination = target_pos;
        var distance = Vector3.Distance(agent.gameObject.transform.position,target_pos);
        if(distance < 1.5f)
        {
            Debug.Log("NextTarget");
            Buy();
            NextTarget();
        }
    }

    void Buy()
    {
        if(status == Status.Buy || status == Status.Finish || status == Status.Destroy)
        {
            return;
        }
        Bookshelf target_bookshelf = null;
        foreach(var bookshelf in ManageMaster.Instance.BookshelfManager.Bookshelves)
        {
            if(bookshelf.Obj.GetInstanceID() == instance_id)
            {

                target_bookshelf = bookshelf;
                if (target_bookshelf.Produt == null)
                {
                    status = Status.Buy;
                    return;
                }
                break;
            }
        }
        target_bookshelf.Quantity--;
        if (target_bookshelf.Button.gameObject.GetInstanceID() == StaticDatas.Instance.TargetBookshelf.Button.gameObject.GetInstanceID())
        {
            ManageMaster.Instance.ProductManager.ProductQuanity.text = target_bookshelf.Quantity.ToString();
        }
        if(target_bookshelf.Produt == null)
        {
            status = Status.Buy;
            return;
        }
        buy_produtlist.Add(target_bookshelf.Produt.SimplePrice);
        status = Status.Buy;
    }

    void NextTarget()
    {
        Debug.Log(status);
        switch (status)
        {
            case Status.Buy:
                target_pos = StaticDatas.Instance.CashRegister.Obj.transform.position;
                status = Status.Finish;
                break;
            case Status.Finish:
                target_pos = StaticDatas.Instance.CustomerInstancePos;
                StaticDatas.Instance.CashRegister.Sell(this);
                status = Status.Destroy;
                break;
            case Status.Destroy:
                ManageMaster.Instance.CustomerManager.Destory(this,agent.gameObject);
                break;
        }
    }
}
