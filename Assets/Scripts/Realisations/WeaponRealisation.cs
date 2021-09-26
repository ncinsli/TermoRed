using System;
using System.Collections.Generic;
using UnityEngine;
using Definitions;
using Contexts;
using Behaviours;
using ExternalDependencies;

public class WeaponRealisation : BehaviourRealisation
{
    [SerializeField] private ShootBehaviourContext _shootBehaviourContext;
    private ShootBehaviour _shootBehaviour;
    public DirectionCounter directionCounter;
    public ShootDependencies shootDependencies;
    private void Start()
    {
        SetupContainers(shootDependencies);
        
        _shootBehaviourContext = new ShootBehaviourContext(shootDependencies);
        _shootBehaviourContext.directionCounter = directionCounter;
        _shootBehaviourContext.weaponRealisation = this;

        _shootBehaviour = new ShootBehaviour().BindContext(_shootBehaviourContext) as ShootBehaviour;
    }

    private void Update()
    {
        _shootBehaviour.Update();
    }

    public override void SetupContainers(params ScriptableObject[] dependencies)
    {
        var deps = dependencies[0] as ShootDependencies;
        deps.gameObject = gameObject;
    }
}
