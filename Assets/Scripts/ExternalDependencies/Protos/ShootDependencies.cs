using System;
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
        public Action onShoot;
        public KeyCode shootKey;
        public GameObject bulletPrefab;
        public Transform bulletSpawnpoint;
        
        [CanBeNull] public GameObject sleevePrefab;
        public VisualEffect smokeEffect;
        public GameObject gameObject { get; set; }
        public int sleeveFrequency = 1;
        public Transform sleeveSpawnpoint;
        
        public BehaviourRealisation realisation { get; set; }
        public DirectionCounter directionCounter;
    }
}