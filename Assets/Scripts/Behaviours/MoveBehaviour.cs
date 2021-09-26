using Contexts;
using Definitions;
using UnityEngine;

namespace Behaviours
{
    public class MoveBehaviour : IBehaviour
    {
        private MoveBehaviourContext _context;
        public void FixedUpdate()
        {
            var force = (_context.direction.x * _context.directionCounter.right) + (_context.direction.z * _context.directionCounter.forward);
            
            if (_context.direction.y > 0f && _context.onGround) force.y = _context.jumpPower;
            else force.y = 0f;
            
            if (_context.body.velocity.magnitude < _context.maxSpeed) 
                _context.body.AddForce(force * _context.maxSpeed * _context.deltaTime * 6f, ForceMode.VelocityChange);
        }

        public void Update(){}

        public IBehaviour BindContext(IBehaviourContext context)
        {
            _context = context as MoveBehaviourContext;
            Debug.Log($"Successfully binded context of Move Behaviour");
            return this;
        } 
    }
}