using Definitions;
using UnityEngine;
using Realisations;

namespace Dependencies
{
    [CreateAssetMenu]
    public class ViewDependencies : ScriptableObject, IBehaviourDependency
    {
        public float speed;
        public GameObject gameObject;
        public BehaviourRealisation realisation { get; set; }
        public Transform transform => gameObject.transform;
        public Vector3 currentRotation { get; set; }
    }
}