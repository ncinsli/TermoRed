using Contexts;
using Modules;
using Settings;
using UnityEngine;
using Users;

namespace Realisations
{
    public class PlayerModuleConnector : MonoBehaviour
    {
        private MoveBehaviour _moveBehaviour;
        [SerializeField] private MoveBehaviourContext _moveBehaviourContext;
        public MoveBehaviourSettings moveSettings;

        [Space][Space][Space][Space][Space]
        
        private InputBehaviour _inputModule;
        [SerializeField] private InputBehaviourContext _inputBehaviourContext;
        public InputBehaviourSettings inputSettings;

        [Space][Space][Space]
        public GroundChecker groundChecker;
        public DirectionCounter directionCounter;
        
        private void Start()
        {
            _moveBehaviourContext = new MoveBehaviourContext(gameObject, moveSettings);
            _moveBehaviour = new MoveBehaviour();
            _moveBehaviourContext.directionCounter = directionCounter;
            _moveBehaviour.BindContext(_moveBehaviourContext);

            _inputBehaviourContext = new InputBehaviourContext(gameObject);
            _inputModule = new InputBehaviour();
            _inputModule.BindContext(_inputBehaviourContext);
        }

        private void Update()
        {
            _moveBehaviourContext.isJumping = _inputBehaviourContext.isJumping;
            _moveBehaviourContext.direction = _inputBehaviourContext.axis;
            _inputModule.Update();
        }

        private void FixedUpdate()
        {
            _moveBehaviourContext.onGround = groundChecker.touchingGround;
            _moveBehaviourContext.deltaTime = Time.deltaTime;
            _moveBehaviour.FixedUpdate();
        }
    }
}