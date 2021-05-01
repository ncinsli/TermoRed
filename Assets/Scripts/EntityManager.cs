using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class EntityManager : MonoBehaviour{
    // public List<ICommand> commands = new List<ICommand<ICommandContext>>();
    public Transform cross;
    public Vector3 forward { get {
        var res = (cross.position - transform.position).normalized;
        res.y = 0f;
        return res;
    }}
    public Vector3 back => -forward;
    public Vector3 left { get{
        var res = forward;
        var l = res.x;
        res.x = -res.z;
        res.z = l;
        return res;
    }}

    public Vector3 right => -left;
}
