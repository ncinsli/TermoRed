using System;
using System.Collections.Generic;
using UnityEngine;
using Definitions;
using Behaviours;
using Dependencies;
using States;

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

        [SerializeField] private WeaponStateProvider _weaponStateProvider;
                
        private void Awake()
        {
            if (!_weaponStateProvider) 
                _weaponStateProvider = GetComponent<WeaponStateProvider>();
            
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
            shootDependencies.stateProvider = _weaponStateProvider;
            shootDependencies.animationBehaviour = _weaponAnimationBehaviour;

            shootDependencies.realisation = this;

            var animationDependencies = dependencies[1] as WeaponAnimationDependencies;
            animationDependencies.animator = _animator;
            animationDependencies.realisation = this;
        }
    }
}