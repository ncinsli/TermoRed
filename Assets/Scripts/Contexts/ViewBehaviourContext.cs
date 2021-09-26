using Definitions;
using ExternalDependencies;
using UnityEngine;

namespace Contexts
{
    [System.Serializable]
    public class ViewBehaviourContext : IBehaviourContext
    {
        public readonly GameObject gameObject;

        public BehaviourRealisation realisation { get; set; }
        public Transform transform => gameObject.transform;
        public Vector3 currentRotation { get; set; }

        private float _speed;
        public ViewBehaviourContext(ViewDependencies deps)
        {
            _speed = deps.speed;
            gameObject = deps.gameObject;
        }
    }
}