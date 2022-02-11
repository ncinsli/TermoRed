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
        private bool inActive;
        public IBehaviour BindDependencies(IBehaviourDependency context)
        {
            if (inActive) return this;
            
            this._dependencies = context as SleeveDependencies;
            _realisation.Destroy(_dependencies.lifetime);

            return this;
        }
        
        public IBehaviour Deactivate()
        {
            inActive = true;
            return this;
        }

        public IBehaviour Activate()
        {
            inActive = false;
            return this;
        }
    }
}