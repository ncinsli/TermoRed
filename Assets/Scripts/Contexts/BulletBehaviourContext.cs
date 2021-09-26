using System;
using Definitions;
using ExternalDependencies;
using Realisations;
using UnityEngine;

namespace Contexts
{
    [Serializable]
    public class BulletBehaviourContext : IBehaviourContext
    {
        public GameObject gameObject { get; set; }
        public Rigidbody rigidbody { get; set; }

        public DirectionCounter directionCounter;

        public BehaviourRealisation realisation { get; set; }
        public BulletDependencies externalDependencies { get; set; }
        
        public Action<Collision> onCollision;
        public BulletBehaviourContext(BulletDependencies d)
        {
            gameObject = d.gameObject;
            externalDependencies = d;
            realisation = d.realisation;
            rigidbody = gameObject.GetComponent<Rigidbody>();
        }
    }
}