using Definitions;
using Settings;
using UnityEngine;

namespace Contexts
{
    [System.Serializable]
    public class InputBehaviourContext : IBehaviourContext
    {
        public readonly GameObject gameObject;
        public Vector3 axis { get; set; }
        public bool isJumping;
        public InputBehaviourContext(GameObject t) => gameObject = t;
    }
}