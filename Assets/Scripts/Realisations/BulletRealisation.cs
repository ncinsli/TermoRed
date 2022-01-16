using System;
using System.Collections.Generic;
using Behaviours;
using Definitions;
using ExternalDependencies;
using UnityEngine;

namespace Realisations
{
    public class BulletRealisation : BehaviourRealisation
    {
        [SerializeField] private BulletDependencies _bulletDependencies;
        private BulletBehaviour _bulletBehaviour;
        public WeaponRealisation weaponShooted;
        private void Start()
        {
            SetupContainers(_bulletDependencies);
            
            _bulletBehaviour = new BulletBehaviour().BindDependencies(_bulletDependencies) as BulletBehaviour;
        }

        private void OnCollisionEnter(Collision collision) => _bulletBehaviour.OnCollisionEnter(collision);

        public void Destroy(float time) => Destroy(gameObject, time);

        public override void SetupContainers(params ScriptableObject[] dependencies)
        {
            // In our case we need to setup only one container
            var deps = dependencies[0] as BulletDependencies;
            deps.realisation = this;
            deps.gameObject = gameObject;
            deps.rigidbody = gameObject.GetComponent<Rigidbody>();
            deps.directionCounter = weaponShooted.directionCounter;
        }
        
    }
}