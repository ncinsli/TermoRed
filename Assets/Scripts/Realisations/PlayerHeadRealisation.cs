using System;
using System.Collections.Generic;
using Contexts;
using Definitions;
using Modules;
using ExternalDependencies;
using UnityEngine;
using Realisations;

namespace Realisations
{
    public class PlayerHeadRealisation : BehaviourRealisation
    {
        private ViewBehaviour _viewBehaviour;
        [SerializeField] private ViewBehaviourContext _viewBehaviourContext;
        public ViewDependencies _viewDependencies;

        private void Start()
        {
            SetupContainers(_viewDependencies);
            
            _viewBehaviourContext = new ViewBehaviourContext(_viewDependencies);
            _viewBehaviour = new ViewBehaviour();
            _viewBehaviour.BindContext(_viewBehaviourContext);
        }

        private void Update()
        {
            _viewBehaviour.Update();
        }

        public override void SetupContainers(params ScriptableObject[] dependencies)
        {
            var deps = dependencies[0] as ViewDependencies;
            deps.gameObject = gameObject;
        }
    }
}