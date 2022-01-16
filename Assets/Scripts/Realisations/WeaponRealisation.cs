using System;
using System.Collections.Generic;
using UnityEngine;
using Definitions;
using Behaviours;
using ExternalDependencies;

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
    private void Start()
    {
        SetupContainers(_shootDependencies, _weaponAnimationDependencies);
        
        _shootBehaviour = new ShootBehaviour().BindDependencies(_shootDependencies) as ShootBehaviour;
        _weaponAnimationBehaviour = new WeaponAnimationBehaviour().BindDependencies(_weaponAnimationDependencies) as WeaponAnimationBehaviour;
    }

    private void Update()
    {
        _shootBehaviour?.Update();
        _weaponAnimationBehaviour?.Update();
    }

    private void FixedUpdate()
    {
        _weaponAnimationBehaviour?.FixedUpdate();
        _shootBehaviour?.FixedUpdate();
    }

    public override void SetupContainers(params ScriptableObject[] dependencies)
    {
        var shootDependencies = dependencies[0] as ShootDependencies;
        shootDependencies.gameObject = gameObject;
        
        shootDependencies.directionCounter = directionCounter;
        shootDependencies.bulletSpawnpoint = bulletSpawnpoint;
        shootDependencies.sleeveSpawnpoint = sleeveSpawnpoint;

        shootDependencies.realisation = this;

        var animationDependencies = dependencies[1] as WeaponAnimationDependencies;
        animationDependencies.animator = _animator;
        animationDependencies.shootAnimation = _shootAnimation;
        _shootDependencies.onShoot = () => animationDependencies.shootInjected();
    }
    private void OnDestroy() => _shootDependencies.onShoot = null;
}
