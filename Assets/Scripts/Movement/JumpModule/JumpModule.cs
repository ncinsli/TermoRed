using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EntityManager))]
[RequireComponent(typeof(Rigidbody))]
public class JumpModule : MonoBehaviour
{
    [SerializeField] private GroundChecker groundChecker;
    [SerializeField] private float jumpForce = 1;
    private Rigidbody rigidbody;
    private void Awake() => rigidbody = GetComponent<Rigidbody>();

    public void Jump()
    {
        Debug.Log("Jump");
        if (groundChecker.touchingGround)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Cringe");
        }
    }
}