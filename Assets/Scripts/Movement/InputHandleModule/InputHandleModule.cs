using System.Collections;
using System.Collections.Generic;
using Commands;
using Commands.Specific;
using UnityEngine;

[RequireComponent(typeof(EntityManager))]
[RequireComponent(typeof(MoveModule))]
[RequireComponent(typeof(JumpModule))]
public class InputHandleModule : MonoBehaviour
{
    [SerializeField] private Context _context = default;
    
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [HideInInspector] public bool moving = false;
    private EntityManager entity;

    private void Awake()
    {
        entity = GetComponent<EntityManager>();
    }

    private void FixedUpdate()
    {
        Vector3 axis = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        var command = new MovementCommand(axis.z * entity.forward + axis.x * entity.right);
        command.Execute(_context);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var command = new JumpCommand();
            command.Execute(_context);
        }
    }
}