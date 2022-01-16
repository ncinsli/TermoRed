using Users;
using ExternalDependencies;
using Behaviours;
using Definitions;
using UnityEngine;

namespace Realisations
{
    public class PlayerRealisation : BehaviourRealisation
    {
        private MoveBehaviour _moveBehaviour;
        public MoveDependencies moveDependencies;

        [Space][Space][Space][Space][Space]
        
        private InputBehaviour _inputBehaviour;
        public InputDependencies inputDependencies;

        [Space][Space][Space]
        public GroundChecker groundChecker;
        public DirectionCounter directionCounter;
        
        private void Start()
        {
            SetupContainers(moveDependencies, inputDependencies);

            _moveBehaviour = new MoveBehaviour().BindDependencies(moveDependencies) as MoveBehaviour;
            _inputBehaviour = new InputBehaviour().BindDependencies(inputDependencies) as InputBehaviour;
        }

        public void Update()
        {
            moveDependencies.isJumping = inputDependencies.isJumping;
            moveDependencies.direction = inputDependencies.axis;
            _inputBehaviour?.Update();
        }

        public void FixedUpdate()
        {
            moveDependencies.onGround = groundChecker.touchingGround;
            moveDependencies.deltaTime = Time.deltaTime;
            _moveBehaviour?.FixedUpdate();
        }

        public override void SetupContainers(params ScriptableObject[] dependencies)
        {
            var moveDeps = dependencies[0] as MoveDependencies;
            var inputDeps = dependencies[1] as InputDependencies;

            moveDeps.gameObject = gameObject;
            moveDeps.realisation = this;
            moveDeps.body = GetComponent<Rigidbody>();
            moveDeps.directionCounter = directionCounter;
            
            inputDeps.gameObject = gameObject;
            inputDeps.realisation = this;
        }
    }
}