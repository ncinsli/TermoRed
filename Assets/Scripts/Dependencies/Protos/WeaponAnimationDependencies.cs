using System;
using Definitions;
using Realisations;
using UnityEngine;

namespace Dependencies
{
    [CreateAssetMenu]
    public class WeaponAnimationDependencies : ScriptableObject, IBehaviourDependency
    {
        public BehaviourRealisation realisation { get; set; }
        public Animator animator;
    }
}