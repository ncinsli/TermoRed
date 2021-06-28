using Users;
using Contexts;
using Settings;
using Behaviours;
using Definitions;
using UnityEngine;

namespace Realisations
{
    public class PlayerRealisation : BehaviourRealisation
    {
        private MoveBehaviour _moveBehaviour;
        [SerializeField] private MoveBehaviourContext _moveBehaviourContext;
        public MoveBehaviourSettings moveSettings;

        [Space][Space][Space][Space][Space]
        
        private InputBehaviour _inputBehaviour;
        [SerializeField] private InputBehaviourContext _inputBehaviourContext;
        public InputBehaviourSettings inputSettings;

        [Space][Space][Space]
        public GroundChecker groundChecker;
        public DirectionCounter directionCounter;
        
        private void Start()
        {
            _moveBehaviourContext = new MoveBehaviourContext(gameObject, moveSettings);
            _moveBehaviour = new MoveBehaviour().BindContext(_moveBehaviourContext) as MoveBehaviour;
            _moveBehaviourContext.directionCounter = directionCounter;
            
            _inputBehaviourContext = new InputBehaviourContext(gameObject);
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
    }
}