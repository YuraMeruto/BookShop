using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateList
{
    List<UpdateBase> update_list = new List<UpdateBase>();
    public List<UpdateBase> UpdateBases { get { return update_list; } set { update_list = value; } }
}
