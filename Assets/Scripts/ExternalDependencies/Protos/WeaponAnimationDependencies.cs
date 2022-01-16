using System;
using Definitions;
using UnityEngine;

namespace ExternalDependencies
{
    [CreateAssetMenu]
    public class WeaponAnimationDependencies : ScriptableObject, IBehaviourDependency
    {
        public BehaviourRealisation realisation { get; set; }
        public Animator animator;
    }
}