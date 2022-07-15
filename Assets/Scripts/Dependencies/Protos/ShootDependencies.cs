using System;
using Behaviours;
using Definitions;
using JetBrains.Annotations;
using Dependencies;
using UnityEngine;
using Realisations;
using States;
using UnityEngine.VFX;

namespace Dependencies
{
    [CreateAssetMenu(menuName="Dependencies/Shoot Dependencies")]
    public class ShootDependencies : ScriptableObject, IBehaviourDependency
    {
        public WeaponStateProvider stateProvider;
        public KeyCode shootKey;
        public KeyCode reloadKey;
        public GameObject bulletPrefab;
        public Transform bulletSpawnpoint;
        public WeaponAnimationBehaviour animationBehaviour;

        [CanBeNull] public GameObject sleevePrefab;
        public GameObject decal;
        public VisualEffect smokeEffect;
        public GameObject gameObject { get; set; }
        public int sleeveFrequency = 1;
        public int bulletFrequency = 20;
        public Transform sleeveSpawnpoint;
        
        public BehaviourRealisation realisation { get; set; }
        public DirectionCounter directionCounter;
    }
}