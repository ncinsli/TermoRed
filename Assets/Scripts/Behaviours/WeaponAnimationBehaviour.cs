using Definitions;
using Dependencies;
using UnityEngine;

namespace Behaviours
{
    public enum WeaponAnimationState { IDLE = 0, Shoot = 1, Reload = 2};
    public class WeaponAnimationBehaviour : IBehaviour
    {
        public IBehaviourDependency dependencies => deps;
        private WeaponAnimationDependencies deps { get; set; }

        public WeaponAnimationState currentAnimation;

        public void OnShoot()
        {
            deps.animator.SetInteger("AnimationId", 1);
            currentAnimation = WeaponAnimationState.Shoot;
//            deps.shootEffect?.Play();
        }
        public void OnReload() 
        {
            Debug.Log("Reload!");
            deps.animator.SetInteger("AnimationId", 2);
            currentAnimation = WeaponAnimationState.Reload;
        }

        public void OnIdle()
        {
            deps.animator.SetInteger("AnimationId", 0);
            currentAnimation = WeaponAnimationState.IDLE;
        }

        public IBehaviour BindDependencies(IBehaviourDependency context)
        {   
            deps = context as WeaponAnimationDependencies;

            return this;
        }
    }

}