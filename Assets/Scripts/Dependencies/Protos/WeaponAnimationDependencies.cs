using System;
using Definitions;
using Realisations;
using UnityEngine;

namespace Dependencies
{
    [CreateAssetMenu(menuName="Dependencies/Weapon animation Dependencies")]
    public class WeaponAnimationDependencies : ScriptableObject, IBehaviourDependency
    {
        public BehaviourRealisation realisation { get; set; }
        public Animator animator;
    }
}