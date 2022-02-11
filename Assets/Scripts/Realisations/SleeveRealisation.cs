using System;
using System.Collections.Generic;
using Behaviours;
using Definitions;
using Dependencies;
using UnityEngine;

namespace Realisations
{
    public class SleeveRealisation : BehaviourRealisation
    {
        [SerializeField] private SleeveDependencies _sleeveDependencies;
        private SleeveBehaviour _sleeveBehaviour { get; set; }
        [SerializeField] private float lifetime = 10f;

        private void Start()
        {
            SetupContainers(_sleeveDependencies);
            _sleeveBehaviour = new SleeveBehaviour().BindDependencies(_sleeveDependencies) as SleeveBehaviour;
            behaviours = new List<IBehaviour>{_sleeveBehaviour};
        }
        public void Destroy(float time) => Destroy(gameObject, time);
        private void SetupContainers(params IBehaviourDependency[] dependencies)
        {
            var sleeveDep = dependencies[0] as SleeveDependencies;
            if (sleeveDep != null)
            {
                sleeveDep.lifetime = lifetime;
                sleeveDep.realisation = this;
            }
        }
    }
}