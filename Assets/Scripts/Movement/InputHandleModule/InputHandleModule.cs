using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EntityManager))]
[RequireComponent(typeof(MoveModule))]
[RequireComponent(typeof(JumpModule))]
public class InputHandleModule : MonoBehaviour{
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [HideInInspector] public bool moving = false;
    private EntityManager entity;
    private MoveModule moveModule;
    private JumpModule jumpModule;

    private void Awake(){
        moveModule = GetComponent<MoveModule>();
        entity = GetComponent<EntityManager>();
        jumpModule = GetComponent<JumpModule>();
    }
    private void FixedUpdate(){
        Vector3 axis = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveModule.Move(axis.z * entity.forward + axis.x * entity.right);

    }
    private void Update(){
        if (Input.GetKeyDown(KeyCode.Space)) jumpModule.Jump();
    }
}
