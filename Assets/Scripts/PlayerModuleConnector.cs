using Contexts;
using Modules;
using Settings;
using UnityEngine;
using Users;

public class PlayerModuleConnector : MonoBehaviour
{
    private MoveBehaviour _moveBehaviour;
    [SerializeField] private MoveBehaviourContext _moveBehaviourContext;
    public MoveBehaviourSettings moveSettings;
    
    private InputBehaviour _inputModule;
    [SerializeField] private InputBehaviourContext _inputBehaviourContext;
    public InputBehaviourSettings inputSettings;

    public GroundChecker groundChecker;

    private void Start()
    {
        _moveBehaviourContext = new MoveBehaviourContext(gameObject, moveSettings);
        _moveBehaviour = new MoveBehaviour();
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
