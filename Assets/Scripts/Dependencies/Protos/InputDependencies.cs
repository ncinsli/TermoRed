using Definitions;
using UnityEngine;
using Realisations;

namespace Dependencies
{
    [CreateAssetMenu(menuName="Dependencies/Input Dependencies")]
    public class InputDependencies : ScriptableObject, IBehaviourDependency
    {
        public GameObject gameObject { get; set; }
        public Vector3 axis { get; set; }
        public bool isJumping;
        public BehaviourRealisation realisation { get; set; }
    }
}