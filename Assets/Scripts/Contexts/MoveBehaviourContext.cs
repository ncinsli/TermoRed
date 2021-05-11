using Definitions;
using Settings;
using UnityEngine;

namespace Contexts
{
    [System.Serializable]
    public class MoveBehaviourContext : IBehaviourContext
    {
        public readonly GameObject gameObject;
        public Vector3 direction;
        public Rigidbody body;
        public float maxSpeed;
        public float deltaTime;
        public float jumpPower;
        public bool isJumping;
        public bool onGround;
        public DirectionCounter directionCounter;

        public MoveBehaviourContext(GameObject t, MoveBehaviourSettings settings)
        {
            gameObject = t;
            body = gameObject.GetComponent<Rigidbody>();
            maxSpeed = settings.maxSpeed;
            jumpPower = settings.jumpPower;
        }
    }
}