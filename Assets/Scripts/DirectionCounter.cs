using UnityEngine;

public class DirectionCounter : MonoBehaviour{
    // public List<ICommand> commands = new List<ICommand<ICommandContext>>();
    public Transform cross;
    public Vector3 forward { get {
        var res = (cross.position - transform.position).normalized;
        res.y = 0f;
        return res;
    }}

    public Vector3 rawForward => (cross.position - transform.position).normalized;    

    public Vector3 back => -forward;
    public Vector3 left { get {
        var res = forward;
        var l = res.x;
        res.x = -res.z;
        res.z = l;
        return res;
    }}

    public Vector3 right => -left;
}
