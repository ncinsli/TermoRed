using System;
using System.Collections;
using System.Collections.Generic;
using Definitions;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.VFX;

namespace ExternalDependencies
{
    [CreateAssetMenu]
    public class BulletDependencies : ScriptableObject, IBehaviourDependency
    {
        public WeaponRealisation weaponShooted { get; set; }
        public GameObject gameObject { get; set; }
        public Rigidbody rigidbody { get; set; }

        public DirectionCounter directionCounter;

        public float speed = 100f;

        public LayerMask destroyableBy;
        public BehaviourRealisation realisation { get; set; }
    }
}
