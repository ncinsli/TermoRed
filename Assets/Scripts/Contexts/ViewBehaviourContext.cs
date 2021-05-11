using Definitions;
using Settings;
using UnityEngine;

namespace Contexts
{
    [System.Serializable]
    public class ViewBehaviourContext : IBehaviourContext
    {
        public readonly GameObject gameObject;
        public Transform transform => gameObject.transform;
        public Vector3 currentRotation { get; set; }

        private float _speed;
        public ViewBehaviourContext(GameObject obj, ViewBehaviourSettings settings)
        {
            _speed = settings.speed;
            gameObject = obj;
        }
    }
}