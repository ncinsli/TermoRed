using System.Collections;
using System.Collections.Generic;
using Definitions;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.VFX;

namespace ExternalDependencies
{
    [CreateAssetMenu]
    public class BulletDependencies : ScriptableObject
    {
        public float speed = 100f;
        public LayerMask destroyableBy;
        public BehaviourRealisation realisation;
        public GameObject gameObject;
    }
}
