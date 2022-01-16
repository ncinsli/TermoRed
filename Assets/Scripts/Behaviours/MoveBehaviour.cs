using Definitions;
using ExternalDependencies;
using UnityEngine;

namespace Behaviours
{
    public class MoveBehaviour : IBehaviour
    {
        private MoveDependencies _dependencies;
        public void FixedUpdate()
        {
            var force = (_dependencies.direction.x * _dependencies.directionCounter.right) + (_dependencies.direction.z * _dependencies.directionCounter.forward);
            
            if (_dependencies.direction.y > 0f && _dependencies.onGround) force.y = _dependencies.jumpPower;
            else force.y = 0f;
            
            if (_dependencies.body.velocity.magnitude < _dependencies.maxSpeed) 
                _dependencies.body.AddForce(force * _dependencies.maxSpeed * _dependencies.deltaTime * 6f, ForceMode.VelocityChange);
        }

        public void Update(){}

        public IBehaviour BindDependencies(IBehaviourDependency d)
        {
            _dependencies = d as MoveDependencies;
            Debug.Log($"Successfully binded dependency of Move Behaviour");
            return this;
        } 
    }
}