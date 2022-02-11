using Definitions;
using Dependencies;
using UnityEngine;

namespace Behaviours
{
    [System.Serializable]
    public class MoveBehaviour : IBehaviour, IFixedUpdateReceiver
    {
        public IBehaviourDependency dependencies => _dependencies;
        private MoveDependencies _dependencies;
        public void FixedUpdate()
        {            
            var force = (_dependencies.direction.x * _dependencies.directionCounter.right) + (_dependencies.direction.z * _dependencies.directionCounter.forward);
            
            if (_dependencies.direction.y > 0f && _dependencies.onGround) force.y = _dependencies.jumpPower;
            else force.y = 0f;
            
            if (_dependencies.body.velocity.magnitude < _dependencies.maxSpeed) 
                _dependencies.body.AddForce(force * _dependencies.maxSpeed * _dependencies.deltaTime * 6f, ForceMode.VelocityChange);
        }

        public IBehaviour BindDependencies(IBehaviourDependency d)
        {
            _dependencies = d as MoveDependencies;

            return this;
        } 
    }
}