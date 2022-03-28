using System;
using System.Collections.Generic;
using Definitions;
using Behaviours;
using Dependencies;
using UnityEngine;
using Realisations;

namespace Realisations
{
    public class PlayerHeadRealisation : BehaviourRealisation
    {
        private ViewBehaviour _viewBehaviour;
        public ViewDependencies _viewDependencies;

        private void Start()
        {
            SetupContainers(_viewDependencies);

            _viewBehaviour = new ViewBehaviour().BindDependencies(_viewDependencies) as ViewBehaviour;

            behaviours =  new List<IBehaviour>{_viewBehaviour};
        }

        public override void SetupContainers(params ScriptableObject[] dependencies)
        {
            var deps = dependencies[0] as ViewDependencies;
            deps.gameObject = gameObject;
            deps.realisation = this;
        }
    }
}