using System;
using System.Collections.Generic;
using UnityEngine;
using Definitions;
using Contexts;
using Behaviours;
using Settings;

public class WeaponRealisation : BehaviourRealisation
{
    [SerializeField] private ShootBehaviourContext _shootBehaviourContext;
    private ShootBehaviour _shootBehaviour;
    public DirectionCounter directionCounter;
    public ShootBehaviourSettings shootBehaviourSettings;
    private void Start()
    {
        _shootBehaviourContext = new ShootBehaviourContext(gameObject, shootBehaviourSettings);
        _shootBehaviourContext.directionCounter = directionCounter;
        _shootBehaviourContext.weaponRealisation = this;
        _shootBehaviour = new ShootBehaviour().BindContext(_shootBehaviourContext) as ShootBehaviour;
    }

    private void Update()
    {
        _shootBehaviour.Update();
    }
    
    public void Destroy() => Destroy(gameObject);
}
