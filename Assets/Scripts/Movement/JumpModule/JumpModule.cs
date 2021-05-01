using UnityEngine;
using System.Collections;
[RequireComponent(typeof(EntityManager))]
[RequireComponent(typeof(Rigidbody))]
public class JumpModule : MonoBehaviour{
    [SerializeField] private GroundChecker groundChecker;
    [SerializeField] private float jumpForce = 1;
    private Rigidbody rigidbody;
    private void Awake() => rigidbody = GetComponent<Rigidbody>();
    public void Jump(){
        if (groundChecker.touchingGround)
            rigidbody.velocity += Vector3.up * jumpForce;
    }
}