using System;
using Behaviours;
using Definitions;
using ExternalDependencies;
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
        }

        private void OnTriggerEnter(Collider other)
        {
            _sleeveBehaviour.OnTriggerEnter(other);
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