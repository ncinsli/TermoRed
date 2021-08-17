using System;
using Definitions;
using Settings;
using UnityEngine;

namespace Contexts
{
    [Serializable]
    public class BulletBehaviourContext : IBehaviourContext
    {
        public GameObject gameObject { get; set; }
        public Rigidbody rigidbody { get; set; }

        public DirectionCounter directionCounter;

        public BulletBehaviourSettings settings { get; set; }
        
        public Action<Collision> onCollision;
        public BulletBehaviourContext(GameObject t, BulletBehaviourSettings s)
        {
            gameObject = t;
            settings = s;
            rigidbody = gameObject.GetComponent<Rigidbody>();
        }
    }
}