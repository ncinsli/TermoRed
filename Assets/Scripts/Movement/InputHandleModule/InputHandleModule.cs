using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EntityManager))]
[RequireComponent(typeof(MoveModule))]
[RequireComponent(typeof(JumpModule))]
public class InputHandleModule : MonoBehaviour{
    [SerializeField] private List<KeyCode> keyCodes = new List<KeyCode>();
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
    private void Update(){
        moving = true;
        if (Input.GetKey(keyCodes[0])) moveModule.Move(entity.left);
        if (Input.GetKey(keyCodes[1])) moveModule.Move(entity.right);
        if (Input.GetKey(keyCodes[2])) moveModule.Move(entity.forward);
        if (Input.GetKey(keyCodes[3])) moveModule.Move(entity.back);
        else moving = false;

        if (Input.GetKeyDown(jumpKey)) jumpModule.Jump();
    }
}
