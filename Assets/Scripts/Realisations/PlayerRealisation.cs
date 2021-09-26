using Users;
using Contexts;
using ExternalDependencies;
using Behaviours;
using Definitions;
using UnityEngine;

namespace Realisations
{
    public class PlayerRealisation : BehaviourRealisation
    {
        private MoveBehaviour _moveBehaviour;
        [SerializeField] private MoveBehaviourContext _moveBehaviourContext;
        public MoveDependencies moveDependencies;

        [Space][Space][Space][Space][Space]
        
        private InputBehaviour _inputBehaviour;
        [SerializeField] private InputBehaviourContext _inputBehaviourContext;
        public InputDependencies inputDependencies;

        [Space][Space][Space]
        public GroundChecker groundChecker;
        public DirectionCounter directionCounter;
        
        private void Start()
        {
            SetupContainers(moveDependencies, inputDependencies);
            
            _moveBehaviourContext = new MoveBehaviourContext(moveDependencies);
            _moveBehaviour = new MoveBehaviour().BindContext(_moveBehaviourContext) as MoveBehaviour;
            _moveBehaviourContext.directionCounter = directionCounter;
            
            _inputBehaviourContext = new InputBehaviourContext(inputDependencies);
            _inputBehaviour = new InputBehaviour().BindContext(_inputBehaviourContext) as InputBehaviour;
        }

        public void Update()
        {
            _moveBehaviourContext.isJumping = _inputBehaviourContext.isJumping;
            _moveBehaviourContext.direction = _inputBehaviourContext.axis;
            _inputBehaviour.Update();
        }

        public void FixedUpdate()
        {
            _moveBehaviourContext.onGround = groundChecker.touchingGround;
            _moveBehaviourContext.deltaTime = Time.deltaTime;
            _moveBehaviour.FixedUpdate();
        }

        public override void SetupContainers(params ScriptableObject[] dependencies)
        {
            var moveDeps = dependencies[0] as MoveDependencies;
            var inputDeps = dependencies[1] as InputDependencies;

            moveDeps.gameObject = gameObject;
            inputDeps.gameObject = gameObject;

        }
    }
}