using System;
using Definitions;
using Dependencies;
using UnityEngine;

namespace Behaviours
{
    [System.Serializable]
    public class InputBehaviour : IBehaviour, IUpdateReceiver
    {
        public IBehaviourDependency dependencies => _dependencies;
        private InputDependencies _dependencies = default;
        public void Update()
        {
            _dependencies.axis = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Jump"),
                Input.GetAxisRaw("Vertical"));

            _dependencies.isJumping = Convert.ToBoolean(_dependencies.axis.y);
        }
        public IBehaviour BindDependencies(IBehaviourDependency d)
        {
            _dependencies = d as InputDependencies;

            return this;
        }
    }
}