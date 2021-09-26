using Modules;
using UnityEngine;

namespace ExternalDependencies
{
    [CreateAssetMenu]
    public class MoveDependencies : ScriptableObject
    {
        public float maxSpeed = 2.7f;
        public float jumpPower = 1f;
        public GameObject gameObject;
    }
}