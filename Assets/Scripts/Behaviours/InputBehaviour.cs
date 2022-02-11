using System;
using Definitions;
using Dependencies;
using UnityEngine;

namespace Behaviours
{
    [System.Serializable]
    public class InputBehaviour : IBehaviour, IUpdateReceiver
    {
        private InputDependencies _dependencies = default;
        private bool inActive;

        public void Update()
        {
            if (inActive) return;

            _dependencies.axis = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Jump"),
                Input.GetAxisRaw("Vertical"));

            _dependencies.isJumping = Convert.ToBoolean(_dependencies.axis.y);
        }
        public IBehaviour BindDependencies(IBehaviourDependency d)
        {
            _dependencies = d as InputDependencies;

            return this;
        }
        
        public IBehaviour Deactivate()
        {
            inActive = true;
            return this;
        }

        public IBehaviour Activate()
        {
            inActive = false;
            return this;
        }
    }
}