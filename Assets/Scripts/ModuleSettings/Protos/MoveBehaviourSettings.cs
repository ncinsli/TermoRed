using Modules;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu]
    public class MoveBehaviourSettings : ScriptableObject
    {
        public float maxSpeed = 2.7f;
        public float jumpPower = 1f;
    }
}