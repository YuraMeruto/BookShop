using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : UpdateBase
{

    public override void Update()
    {
        Debug.Log("PlayerControl");
        if (Input.GetMouseButtonDown(0))
        {
            MouseClick();
        }
    }

    void MouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.collider.gameObject);
        }
    }
}
