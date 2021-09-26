using Definitions;
using ExternalDependencies;
using UnityEngine;

namespace Contexts
{
    [System.Serializable]
    public class InputBehaviourContext : IBehaviourContext
    {
        public BehaviourRealisation realisation { get; set; }
        public readonly GameObject gameObject;
        public Vector3 axis { get; set; }
        public bool isJumping;
        public InputBehaviourContext(InputDependencies deps) => gameObject = deps.gameObject;
    }
}