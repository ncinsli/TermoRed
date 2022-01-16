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

        public void OnShoot() => deps.animator.SetInteger("AnimationId", 1);

        public void OnReload() => deps.animator.SetInteger("AnimationId", 2);

        public void OnIdle() => deps.animator.SetInteger("AnimationId", 0);

        public IBehaviour BindDependencies(IBehaviourDependency context)
        {   
            deps = context as WeaponAnimationDependencies;
            Debug.Log(deps.animator);
            return this;
        }
    }

}