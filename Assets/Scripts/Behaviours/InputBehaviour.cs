using System;
using Definitions;
using ExternalDependencies;
using UnityEngine;

namespace Behaviours
{
    public class InputBehaviour : IBehaviour
    {
        private InputDependencies _dependencies = default;

        public void Update()
        {
            _dependencies.axis = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Jump"),
                Input.GetAxisRaw("Vertical"));

            _dependencies.isJumping = Convert.ToBoolean(_dependencies.axis.y);
        }

        public void FixedUpdate(){}

        public IBehaviour BindDependencies(IBehaviourDependency d)
        {
            _dependencies = d as InputDependencies;
            Debug.Log($"Successfully binded dependency of Input Behaviour");
            return this;
        }
    }
}