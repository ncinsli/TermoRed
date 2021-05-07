using Contexts;
using Definitions;
using UnityEngine;

namespace Modules
{
    public class MoveBehaviour
    {
        private MoveBehaviourContext _context;
        public void FixedUpdate()
        {
            var force = _context.direction.normalized * _context.maxSpeed * _context.deltaTime;
            if (_context.direction.y > 0f && _context.onGround) force.y = _context.jumpPower;
            else force.y = 0f;
            if (_context.body.velocity.magnitude < _context.maxSpeed) 
                _context.body.AddForce(force * 6f, ForceMode.VelocityChange);
        }

        public void BindContext(MoveBehaviourContext context) => _context = context;
    }
}