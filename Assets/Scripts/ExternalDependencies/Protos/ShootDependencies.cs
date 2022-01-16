using System;
using Behaviours;
using Definitions;
using JetBrains.Annotations;
using Modules;
using UnityEngine;
using UnityEngine.VFX;

namespace ExternalDependencies
{
    [CreateAssetMenu]
    public class ShootDependencies : ScriptableObject, IBehaviourDependency
    {
        public KeyCode shootKey;
        public KeyCode reloadKey;
        public GameObject bulletPrefab;
        public Transform bulletSpawnpoint;
        public WeaponAnimationBehaviour animationBehaviour;

        [CanBeNull] public GameObject sleevePrefab;
        public VisualEffect smokeEffect;
        public GameObject gameObject { get; set; }
        public int sleeveFrequency = 1;
        public Transform sleeveSpawnpoint;
        
        public BehaviourRealisation realisation { get; set; }
        public DirectionCounter directionCounter;
    }
}