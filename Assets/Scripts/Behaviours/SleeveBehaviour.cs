using Definitions;
using Dependencies;
using Realisations;
using UnityEngine;

namespace Behaviours
{
    public class SleeveBehaviour : IBehaviour
    {
        private SleeveDependencies _dependencies { get; set; }
        private SleeveRealisation _realisation => _dependencies.realisation as SleeveRealisation;
        
        public void Update(){}

        public void FixedUpdate(){}

        public void OnTriggerEnter(Collider col) { }

        public IBehaviour BindDependencies(IBehaviourDependency context)
        {
            this._dependencies = context as SleeveDependencies;
            _realisation.Destroy(_dependencies.lifetime);

            return this;
        }
    }
}