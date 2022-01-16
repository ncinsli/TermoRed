using Definitions;
using ExternalDependencies;
using UnityEngine;

namespace Behaviours
{
    public class WeaponAnimationBehaviour : IBehaviour
    {
        private WeaponAnimationDependencies deps { get; set; }
        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
            
        }

        private void OnShoot()
        {
            deps.animator.Play(deps.shootAnimation.name);
        }

        public IBehaviour BindDependencies(IBehaviourDependency context)
        {   
            deps = context as WeaponAnimationDependencies;
            deps.shootInjected = OnShoot;
            return this;
        }
    }

}