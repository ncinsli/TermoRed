using Definitions;
using Dependencies;
using UnityEngine;

namespace Behaviours
{
    public class WeaponAnimationBehaviour : IBehaviour
    {
        private WeaponAnimationDependencies deps { get; set; }
        private bool inActive;
        public void OnShoot() => deps.animator.SetInteger("AnimationId", 1);

        public void OnReload() => deps.animator.SetInteger("AnimationId", 2);

        public void OnIdle() => deps.animator.SetInteger("AnimationId", 0);

        public IBehaviour BindDependencies(IBehaviourDependency context)
        {   
            deps = context as WeaponAnimationDependencies;

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