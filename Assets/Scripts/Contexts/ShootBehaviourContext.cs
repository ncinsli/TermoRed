using System;
using UnityEngine;
using System.Collections;
using ExternalDependencies;
using Definitions;
using Realisations;
using UnityEngine.VFX;

namespace Contexts
{
    public class ShootBehaviourContext : IBehaviourContext
    {
        public VisualEffect smokeEffect;
        public BehaviourRealisation realisation { get; set; }
        public GameObject gameObject;
        public ShootDependencies externalDependencies;
        public DirectionCounter directionCounter;
        public WeaponRealisation weaponRealisation;
        public ShootBehaviourContext(ShootDependencies deps)
        {
            gameObject = deps.gameObject;
            this.externalDependencies = deps;
            this.smokeEffect = deps.smokeEffect;
        }
    }
}