using System;
using Contexts;
using Definitions;
using UnityEngine;

namespace Modules
{
    public class InputBehaviour
    {
        private InputBehaviourContext _context = default;

        public void Update()
        {
            _context.axis = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Jump"),
                Input.GetAxisRaw("Vertical"));
            Debug.Log(_context.axis);
            _context.isJumping = Convert.ToBoolean(_context.axis.y);
        }

        public void BindContext(InputBehaviourContext context) => _context = context;
    }
}