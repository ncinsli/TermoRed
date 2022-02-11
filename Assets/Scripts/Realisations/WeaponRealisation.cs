using System;
using System.Collections.Generic;
using UnityEngine;
using Definitions;
using Behaviours;
using Dependencies;

namespace Realisations
{
    public class WeaponRealisation : BehaviourRealisation
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationClip _shootAnimation;
        
        private ShootBehaviour _shootBehaviour;
        private WeaponAnimationBehaviour _weaponAnimationBehaviour;
        
        public DirectionCounter directionCounter;
        [SerializeField] private ShootDependencies _shootDependencies;
        [SerializeField] private WeaponAnimationDependencies _weaponAnimationDependencies;
        
        public Transform sleeveSpawnpoint;
        public Transform bulletSpawnpoint;
                
        private void Awake()
        {
            _shootBehaviour = new ShootBehaviour();
            _weaponAnimationBehaviour = new WeaponAnimationBehaviour().BindDependencies(_weaponAnimationDependencies) as WeaponAnimationBehaviour;

            SetupContainers(_shootDependencies, _weaponAnimationDependencies);
            _shootBehaviour.BindDependencies(_shootDependencies);
            behaviours = new List<IBehaviour>{_shootBehaviour};

            onUpdate = behaviour => behaviour.Update();
            onFixedUpdate = behaviour => behaviour.FixedUpdate();
        }

        public override void SetupContainers(params ScriptableObject[] dependencies)
        {
            var shootDependencies = dependencies[0] as ShootDependencies;
            shootDependencies.gameObject = gameObject;
            
            shootDependencies.directionCounter = directionCounter;
            shootDependencies.bulletSpawnpoint = bulletSpawnpoint;
            shootDependencies.sleeveSpawnpoint = sleeveSpawnpoint;
            shootDependencies.animationBehaviour = _weaponAnimationBehaviour;

            shootDependencies.realisation = this;

            var animationDependencies = dependencies[1] as WeaponAnimationDependencies;
            animationDependencies.animator = _animator;
            animationDependencies.realisation = this;
        }
    }
}