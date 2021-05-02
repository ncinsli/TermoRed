using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveModule : MonoBehaviour{
    [SerializeField] private float maxSpeed = 3.67f;
    [SerializeField] private Rigidbody rigidbody;
    public void Move(Vector3 direction){
        if (rigidbody == null) rigidbody = GetComponent<Rigidbody>();
        // direction.y -= Mathf.Pow(9.81f * Time.deltaTime * Time.deltaTime, 2f);
        var force = direction.normalized * maxSpeed * Time.deltaTime;
        if (rigidbody.velocity.magnitude < maxSpeed) rigidbody.AddForce(force * 6f, ForceMode.VelocityChange);
    }
}