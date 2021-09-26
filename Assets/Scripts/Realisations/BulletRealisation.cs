using System;
using System.Collections.Generic;
using Behaviours;
using Contexts;
using Definitions;
using ExternalDependencies;
using UnityEngine;

namespace Realisations
{
    public class BulletRealisation : BehaviourRealisation
    {
        [SerializeField] private BulletBehaviourContext _bulletBehaviourContext;
        [SerializeField] private BulletDependencies _bulletDependencies;
        private BulletBehaviour _bulletBehaviour;
        public WeaponRealisation weaponShooted { get; set; }
        private void Start()
        {
            SetupContainers( _bulletDependencies);
            
            _bulletBehaviourContext = new BulletBehaviourContext(_bulletDependencies);
            _bulletBehaviourContext.directionCounter = weaponShooted.directionCounter;
            _bulletBehaviour = new BulletBehaviour().BindContext(_bulletBehaviourContext) as BulletBehaviour;
        }

        private void OnCollisionEnter(Collision collision) =>
            _bulletBehaviourContext.onCollision?.Invoke(collision);

        public override void SetupContainers(params ScriptableObject[] dependencies)
        {
            // In our case we need to setup only one container
            var deps = dependencies[0] as BulletDependencies;
            deps.realisation = this;
            deps.gameObject = gameObject;
        }
        
    }
}