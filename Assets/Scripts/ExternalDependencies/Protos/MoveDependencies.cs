using Definitions;
using Modules;
using UnityEngine;

namespace ExternalDependencies
{
    [CreateAssetMenu]
    public class MoveDependencies : ScriptableObject, IBehaviourDependency
    {
        public float maxSpeed = 2.7f;
        public float jumpPower = 1f;
        public GameObject gameObject { get; set; }
        public BehaviourRealisation realisation { get; set; }
        
        public Vector3 direction;
        public Rigidbody body;
        public float deltaTime;
        public bool isJumping;
        public bool onGround;
        public DirectionCounter directionCounter;
    }
}