using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class UpdateBase
{
    protected GameObject game_object;
    protected int instance_id;
    public GameObject Object { get { return game_object; } set { game_object = value; } }
    public int InstanceId { get { return instance_id; } set { instance_id = value; } }
    public abstract void Update();

}
