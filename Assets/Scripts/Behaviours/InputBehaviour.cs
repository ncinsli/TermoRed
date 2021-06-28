using System;
using Contexts;
using Definitions;
using UnityEngine;

namespace Behaviours
{
    public class InputBehaviour : IBehaviour
    {
        private InputBehaviourContext _context = default;

        public void Update()
        {
            _context.axis = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Jump"),
                Input.GetAxisRaw("Vertical"));

            _context.isJumping = Convert.ToBoolean(_context.axis.y);
        }

        public void FixedUpdate(){}

        public IBehaviour BindContext(IBehaviourContext context)
        {
            _context = context as InputBehaviourContext;
            return this;
        }
    }
}