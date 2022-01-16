using Definitions;
using UnityEngine;

namespace ExternalDependencies
{
    [CreateAssetMenu]
    public class InputDependencies : ScriptableObject, IBehaviourDependency
    {
        public GameObject gameObject { get; set; }
        public Vector3 axis { get; set; }
        public bool isJumping;
        public BehaviourRealisation realisation { get; set; }
    }
}