using Users;
using Dependencies;
using Behaviours;
using Definitions;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using States;

namespace Realisations
{
    [ExecuteInEditMode]
    public class PlayerRealisation : BehaviourRealisation
    {
        private PlayerStateProvider _playerState;
        
        [SerializeField] private MoveBehaviour _moveBehaviour;
        public MoveDependencies moveDependencies;

        [Space]
        
        [SerializeField] private InputBehaviour _inputBehaviour;
        public InputDependencies inputDependencies;

        [Space]
        public GroundChecker groundChecker;
        public DirectionCounter directionCounter;        

        private void OnEnable()
        {
            _playerState = GetComponent<PlayerStateProvider>();
            
            SetupContainers(moveDependencies, inputDependencies);
            
            _moveBehaviour = new MoveBehaviour().BindDependencies(moveDependencies) as MoveBehaviour;
            _inputBehaviour = new InputBehaviour().BindDependencies(inputDependencies) as InputBehaviour;
           
            behaviours = new List<IBehaviour>{_moveBehaviour, _inputBehaviour};

            onUpdate = behaviour => 
            {
                moveDependencies.isJumping = inputDependencies.isJumping;
                moveDependencies.direction = inputDependencies.axis;
            };

            onFixedUpdate = behaviour => 
            {
                moveDependencies.onGround = groundChecker.touchingGround;
                moveDependencies.deltaTime = Time.deltaTime;
            };
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