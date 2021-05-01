using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EntityManager))]
public class MoveCommand : MonoBehaviour, ICommand{
    [SerializeField] private float speed = 1f;
    private Rigidbody rigidbody;
    public GroundChecker ground;
    private void Awake(){
        rigidbody = GetComponent<Rigidbody>();
    }
    public void Execute<T>(T context){
        rigidbody.position += context.direction.normalized * Time.deltaTime * speed;     
    }
}