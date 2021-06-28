using System;
using Definitions;
using UnityEngine;

namespace Contexts
{
    [Serializable]
    public class BulletBehaviourContext : IBehaviourContext
    {
        public GameObject gameObject { get; set; }
        public Rigidbody rigidbody { get; set; }

        public DirectionCounter directionCounter;
        
        public Action<Collision> onCollision;
        public BulletBehaviourContext(GameObject t)
        {
            gameObject = t;
            rigidbody = gameObject.GetComponent<Rigidbody>();
        }
    }
}