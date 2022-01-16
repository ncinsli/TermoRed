using System;
using Definitions;
using UnityEngine;

namespace ExternalDependencies
{
    [CreateAssetMenu]
    public class WeaponAnimationDependencies : ScriptableObject, IBehaviourDependency
    {
        public BehaviourRealisation realisation { get; set; }
        public Action shootInjected;
        public Animator animator;
        public AnimationClip shootAnimation;
    }
}