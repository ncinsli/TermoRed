using Definitions;
using ExternalDependencies;
using UnityEngine;

namespace Contexts
{
    [System.Serializable]
    public class MoveBehaviourContext : IBehaviourContext
    {
        public BehaviourRealisation realisation { get; set; }
        public readonly GameObject gameObject;
        public Vector3 direction;
        public Rigidbody body;
        public float maxSpeed;
        public float deltaTime;
        public float jumpPower;
        public bool isJumping;
        public bool onGround;
        public DirectionCounter directionCounter;

        public MoveBehaviourContext(MoveDependencies deps)
        {
            gameObject = deps.gameObject;
            body = gameObject.GetComponent<Rigidbody>();
            maxSpeed = deps.maxSpeed;
            jumpPower = deps.jumpPower;
        }
    }
}