using System;
using Definitions;
using Realisations;
using UnityEngine;
using UnityEngine.VFX;

namespace Dependencies
{
    [CreateAssetMenu(menuName="Dependencies/Weapon animation Dependencies")]
    public class WeaponAnimationDependencies : ScriptableObject, IBehaviourDependency
    {
        public BehaviourRealisation realisation { get; set; }
        public VisualEffect shootEffect;
        public VisualEffect smokeEffect;
        public Animator animator;
    }
}