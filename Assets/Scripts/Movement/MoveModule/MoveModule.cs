using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveModule : MonoBehaviour{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Rigidbody rigidbody;
    public void Move(Vector3 direction){
        if (rigidbody == null) rigidbody = GetComponent<Rigidbody>();
        rigidbody.position += direction.normalized * Time.deltaTime * speed;
    }
}