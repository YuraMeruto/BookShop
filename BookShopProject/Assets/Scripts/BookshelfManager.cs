using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookshelfManager 
{
    List<Bookshelf> bookshelves = new List<Bookshelf>();
    public List<Bookshelf> Bookshelves { get { return bookshelves; } }



    public void Ini()
    {
        var list = GameObject.Find("BookshelfList").GetComponentsInChildren<Button>();
        var index = 0;

        var list_obj = GameObject.FindGameObjectsWithTag("Bookshelf"); 
        foreach (var data in list)
        {
            Bookshelf book = new Bookshelf();
            book.Button = data;
            book.Obj = list_obj[index];
            bookshelves.Add(book);
            index++;
        }
    }

    public void OpenMenu()
    {

    }
}
