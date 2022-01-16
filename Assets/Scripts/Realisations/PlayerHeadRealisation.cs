using System;
using System.Collections.Generic;
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
        [SerializeField] private ViewDependencies viewDependencies;
        public ViewDependencies _viewDependencies;

        private void Start()
        {
            SetupContainers(_viewDependencies);
            
            _viewBehaviour = new ViewBehaviour().BindDependencies(viewDependencies) as ViewBehaviour;
        }

        private void Update()
        {
            _viewBehaviour?.Update();
        }

        public override void SetupContainers(params ScriptableObject[] dependencies)
        {
            var deps = dependencies[0] as ViewDependencies;
            deps.gameObject = gameObject;
            deps.realisation = this;
        }
    }
}