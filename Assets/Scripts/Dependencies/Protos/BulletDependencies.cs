using System;
using System.Collections;
using System.Collections.Generic;
using Definitions;
using GameState;
using Realisations;
using States;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.VFX;

namespace Dependencies
{
    [CreateAssetMenu(menuName="Dependencies/Bullet Dependencies")]
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
