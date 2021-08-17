using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu]
    public class BulletBehaviourSettings : ScriptableObject
    {
        public float speed = 100f;
        public LayerMask destroyableBy;
    }
}
